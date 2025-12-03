using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Adventure.Dungeon.Triggers;
using Helpers;

namespace Adventure.Dungeon
{
    public class DungeonLoader
    {
        private DungeonData dungeonData;

        private Dictionary<int, Monster> MonsterList;

        // If player can't take items into or out of this dungeon, hold his/her
        // items here for the duration of this adventure.
        private List<itemType> PlayerItemLocker;
        private int PlayerArmorLocker;

        public void LoadDungeonData(string fileName)
        {
            string xml = File.ReadAllText(fileName);
            Type[] additionalTypes = new Type[] { typeof(doorType), typeof(lockableDoorType), typeof(weaponData) };
            dungeonData = xml.ParseXML<DungeonData>(additionalTypes);

            MonsterList = new Dictionary<int, Monster>();
            foreach (MonsterType m in dungeonData.MonsterList)
            {
                Monster monster = new Monster(m);
                MonsterList.Add(m.ID, monster);

                List<itemType> items = new List<itemType>();
                if (m.Items.Item != null)
                {
                    foreach (int item in m.Items.Item)
                    {
                        items.Add(dungeonData.ItemList.First(i => { return i.id == item; }));
                    }
                }
                monster.Items = items;
                if (m.WeaponIDSpecified)
                {
                    monster.Weapon = (weaponData)dungeonData.ItemList.First(i => { return i.id == m.WeaponID; });
                }
            }
        }

        public string Intro()
        {
            return dungeonData.Intro;
        }

        /// <summary>
        /// Loads and initializes all rooms from the dungeon data, including their creatures, items, exits, and
        /// triggers.
        /// </summary>
        /// <remarks>This method processes the dungeon data to create a collection of rooms, populating
        /// each room with its associated creatures, items, and exits. It also sets up triggers for rooms, monsters, and
        /// items as defined in the dungeon data. The returned dictionary maps room names to their corresponding <see
        /// cref="IRoom"/> instances.</remarks>
        /// <returns>A dictionary where the keys are room names and the values are <see cref="IRoom"/> instances representing the
        /// initialized rooms.</returns>
        public Dictionary<string, IRoom> LoadRooms()
        {
            Dictionary<string, IRoom> rooms = new Dictionary<string, IRoom>();
            foreach (roomType room in dungeonData.RoomList)
            {
                Room newRoom = new Room(room.Name, room.Title, room.Description, room.ShortDescription, room.Light)
                {
                    Creatures = new List<Monster>()
                };

                foreach (int creatureId in room.Creatures)
                {
                    Monster monster = MonsterList[creatureId];
                    newRoom.Creatures.Add(monster);
                }
                rooms.Add(newRoom.Name, newRoom);

                List<itemType> items = new List<itemType>();
                if (room.Items != null)
                {
                    foreach (int item in room.Items)
                    {
                        items.Add(dungeonData.ItemList.First(i => { return i.id == item; }));
                    }
                }
                rooms[room.Name].Items = items;
            }

            foreach (roomType room in dungeonData.RoomList)
            {
                ExitRooms newExits = new ExitRooms();
                foreach (doorType exit in room.Exits)
                {
                    newExits.Add(exit.direction, ExitFactory.GetExit(exit, rooms));
                }
                rooms[room.Name].Exits = newExits;
            }
            foreach (Room room in rooms.Values)
            {
                roomType rm = dungeonData.RoomList.First(r => r.Name == room.Name);
                CreateRoomTriggers(dungeonData, rm.Trigger, room);
            }

            foreach (Monster monster in MonsterList.Values)
            {
                MonsterType dm = dungeonData.MonsterList.First(m => m.ID == monster.ID);
                CreateMonsterTriggers(dungeonData, dm.Trigger, monster);
                CreateAutoCorpse(dungeonData, monster, dm);
            }

            foreach (itemType item in dungeonData.ItemList)
            {
                item.Initialize(dungeonData);
                CreateItemTriggers(dungeonData, item);
            }
            return rooms;
        }

        /// <summary>
        /// Creates a corpse item for the specified monster and sets it to be revealed upon the monster's death.
        /// </summary>
        /// <remarks>This method generates a new corpse item based on the metadata provided by the <paramref name="dm"/>
        /// parameter. The corpse is hidden by default and will be revealed when the <paramref name="monster"/> is
        /// killed.</remarks>
        /// <param name="dungeonData">The dungeon data containing the list of items and triggers.</param>
        /// <param name="monster">The monster for which the corpse will be created.</param>
        /// <param name="dm">The monster type definition that provides corpse-related metadata.</param>
        private void CreateAutoCorpse(DungeonData dungeonData, Monster monster, MonsterType dm)
        {
            if (dm.AutoCorpse != null)
            {
                // Get the max item id of all existing items, and add 1.
                // This will be the item id of the new corpse.
                int itemNum = dungeonData.ItemList.Select<itemType, int>(i => i.id).Max() + 1;

                // Create the corpse
                itemType corpse = new itemType();
                corpse.id = itemNum;
                corpse.name = "dead " + dm.Name;
                corpse.description = dm.AutoCorpse.Description;
                corpse.baseValue = 0;
                corpse.weight = -999;
                corpse.revealed = false;

                // Add the onKill trigger to reveal it.
                revealItemAction action = new revealItemAction(corpse, corpse.description, "Current");

                TriggeredActionsHandler handler = CreateTrigger(dungeonData, new actionType[] { action });
                monster.onKill += handler.HandleEvent;
            }
        }

        /// <summary>
        /// Configures and attaches event triggers to a specified room based on the provided trigger definitions.
        /// </summary>
        /// <remarks>This method iterates through the provided trigger definitions and associates the
        /// corresponding event handlers with the appropriate room events, such as entering the room, examining it, or
        /// using a magic word. If a trigger action is not defined or the trigger type is unsupported, the trigger is
        /// skipped or logged as unsupported.</remarks>
        /// <param name="dungeonData">The dungeon data context used to create and configure triggers.</param>
        /// <param name="triggers">An array of trigger definitions specifying the actions and conditions for the room events. Can be <see
        /// langword="null"/>.</param>
        /// <param name="room">The room to which the triggers will be attached. Cannot be <see langword="null"/>.</param>
        private void CreateRoomTriggers(DungeonData dungeonData, roomTriggerType[] triggers, Room room)
        {
            if (triggers != null)
            {
                foreach (roomTriggerType trigger in triggers)
                {
                    if (trigger.action != null)
                    {
                        TriggeredActionsHandler handler = CreateTrigger(dungeonData, trigger.action, trigger.trigger.arg);
                        switch (trigger.trigger.Value)
                        {
                            case roomTriggerNameType.OnFirstEnter:
                                room.OnFirstEnter += handler.HandleEvent;
                                break;
                            case roomTriggerNameType.OnEachEnter:
                                room.OnEachEnter += handler.HandleEvent;
                                break;
                            case roomTriggerNameType.OnExamine:
                                room.onExamine += handler.HandleEvent;
                                break;
                            case roomTriggerNameType.OnMagicWord:
                                room.onMagicWord += handler.HandleStringArgsEvent;
                                break;
                            case roomTriggerNameType.OnPower:
                                room.onPower += handler.HandleEvent;
                                break;
                            default:
                                Console.WriteLine("Unsupported Room trigger: {0}", trigger.trigger);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configures and attaches event handlers to a monster based on the specified triggers.
        /// </summary>
        /// <remarks>This method iterates through the provided triggers and associates the appropriate
        /// event handlers with the corresponding monster events. Supported events include <see
        /// cref="monsterTriggerNameType.OnBlast"/>, <see cref="monsterTriggerNameType.OnWound"/>, <see
        /// cref="monsterTriggerNameType.OnPower"/>, <see cref="monsterTriggerNameType.OnKill"/>, and <see
        /// cref="monsterTriggerNameType.OnMagicWord"/>. If a trigger's action is null, it is ignored. Unsupported
        /// trigger types are logged to the console.</remarks>
        /// <param name="dungeonData">The dungeon data used to create the trigger handlers.</param>
        /// <param name="triggers">An array of triggers that define the conditions and actions to be associated with the monster. Each trigger
        /// specifies the event type and the corresponding action to execute.</param>
        /// <param name="monster">The monster to which the triggers and their handlers will be attached.</param>
        private void CreateMonsterTriggers(DungeonData dungeonData, monsterTriggerType[] triggers, Monster monster)
        {
            if (triggers != null)
            {
                foreach (monsterTriggerType trigger in triggers)
                {
                    if (trigger.action != null)
                    {
                        TriggeredActionsHandler handler = CreateTrigger(dungeonData, trigger.action, trigger.trigger.arg);
                        switch (trigger.trigger.Value)
                        {
                            case monsterTriggerNameType.OnBlast:
                                monster.OnBlast += handler.HandleEvent;
                                break;
                            case monsterTriggerNameType.OnWound:
                                monster.onWound += handler.HandleEvent;
                                break;
                            case monsterTriggerNameType.OnPower:
                                monster.OnPower += handler.HandleEvent;
                                break;
                            case monsterTriggerNameType.OnKill:
                                monster.onKill += handler.HandleEvent;
                                break;
                            case monsterTriggerNameType.OnMagicWord:
                                monster.OnMagicWord += handler.HandleStringArgsEvent;
                                break;
                            default:
                                Console.WriteLine("Unsupported Monster trigger: {0}", trigger.trigger);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configures and associates event triggers for the specified item based on its defined triggers.
        /// </summary>
        /// <remarks>This method iterates through the triggers defined for the item and associates them
        /// with the corresponding event handlers. Each trigger is mapped to a specific event on the item, such as <see
        /// cref="itemType.onBlast"/>, <see cref="itemType.onGet"/>, or <see cref="itemType.onUse"/>. If a trigger
        /// requires arguments, they are passed to the handler during association.</remarks>
        /// <param name="dungeonData">The dungeon data context used to create and manage triggers.</param>
        /// <param name="item">The item for which triggers are being created and associated. The item must have a non-null <see
        /// cref="itemType.Trigger"/> collection to process triggers.</param>
        private void CreateItemTriggers(DungeonData dungeonData, itemType item)
        {
            if (item.Trigger != null)
            {
                foreach (itemTriggerType trigger in item.Trigger)
                {
                    if (trigger.action != null)
                    {
                        TriggeredActionsHandler handler = CreateTrigger(dungeonData, trigger.action, trigger.trigger.arg);
                        switch (trigger.trigger.Value)
                        {
                            case itemTriggerNameType.OnBlast:
                                item.onBlast += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnGet:
                                item.onGet += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnDrop:
                                item.onDrop += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnExamine:
                                item.onExamine += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnPower:
                                item.onPower += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnMagicWord:
                                item.onMagicWord += handler.HandleStringArgsEvent;
                                break;
                            case itemTriggerNameType.OnPut:
                                item.onPut += handler.HandleIntegerArgsEvent;
                                break;
                            case itemTriggerNameType.OnDrink:
                                item.onDrink += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnRead:
                                item.onRead += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnUse:
                                item.onUse += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnOpen:
                                item.onOpen += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnClose:
                                item.onClose += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnWear:
                                item.onWear += handler.HandleEvent;
                                break;
                            case itemTriggerNameType.OnRemove:
                                item.onRemove += handler.HandleEvent;
                                break;
                                //default:
                                //    Console.WriteLine("Unsupported Item trigger: {0}", trigger.trigger);
                                //    break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="TriggeredActionsHandler"/> instance and initializes it with the specified actions.
        /// </summary>
        /// <remarks>Each action in the <paramref name="actions"/> array is initialized with the provided
        /// <paramref name="dungeonData"/>  and added to the returned <see cref="TriggeredActionsHandler"/>. The
        /// optional <paramref name="arg"/> parameter  can be used to configure the handler during its
        /// creation.</remarks>
        /// <param name="dungeonData">The dungeon data used to initialize the actions.</param>
        /// <param name="actions">An array of actions to be added to the handler. Each action will be initialized with the provided dungeon
        /// data.</param>
        /// <param name="arg">An optional argument used to configure the <see cref="TriggeredActionsHandler"/>. Can be <see
        /// langword="null"/>.</param>
        /// <returns>A <see cref="TriggeredActionsHandler"/> containing the initialized actions.</returns>
        private TriggeredActionsHandler CreateTrigger(DungeonData dungeonData, actionType[] actions, string arg = null)
        {
            TriggeredActionsHandler handler = new TriggeredActionsHandler(arg);
            foreach (actionType a in actions)
            {
                a.Initialize(dungeonData, MonsterList);
                handler.Add(a);
            }
            return handler;
        }

        /// <summary>
        /// Prepares the specified player character for entering the dungeon by adjusting their items and armor based on
        /// the dungeon's rules and requirements.
        /// </summary>
        /// <remarks>If the dungeon enforces the "Can't Take It With You" rule, the player's current items
        /// and armor are stored and replaced with the dungeon's starting items and armor. Otherwise, the player's
        /// existing items are validated to ensure no conflicts with the dungeon's item IDs, and any necessary triggers
        /// are initialized.</remarks>
        /// <param name="player">The player character to prepare. This parameter cannot be null.</param>
        public void PrepCharacter(Character player)
        {
            if (dungeonData.CantTakeItWithYou != null)
            {
                PlayerItemLocker = player.Items;
                PlayerArmorLocker = player.ArmorClass;
                player.Items = new List<itemType>();

                if (dungeonData.CantTakeItWithYou.StartingItem != null)
                {
                    foreach (int item in dungeonData.CantTakeItWithYou.StartingItem)
                    {
                        player.Items.Add(dungeonData.ItemList.First(i => { return i.id == item; }));
                    }
                }
                player.ArmorClass = dungeonData.CantTakeItWithYou.StartingArmorClass;
            }
            else
            {
                // If the player brings their own items into this dungeon, we need to ensure that
                // their item ids do not conflict with items in the dungeon, and any triggers on
                // their items are initialized.
                var dungeonItems = dungeonData.ItemList.Select((itemType i, int d) => i.id);
                int nextId = dungeonItems.Max();
                foreach (itemType item in player.Items)
                {
                    if (dungeonItems.Contains(item.id))
                    {
                        item.id = ++nextId;
                        item.Initialize(dungeonData);
                    }
                    CreateItemTriggers(dungeonData, item);
                }
            }
        }

        /// <summary>
        /// If this was a "You Can't Take It With You" adventure, transfer any money collected
        /// to the player's bank account and return their items.
        /// </summary>
        /// <param name="player"></param>
        public void EmptyLocker(Character player)
        {
            if (dungeonData.CantTakeItWithYou != null)
            {
                // The value of money collected will be added to the player's bank account.
                int moneyValue = 0;
                try
                {
                    moneyValue = player.Items.FindAll((i) => i.isMoney).Select((j) => j.baseValue).Aggregate((sum, next) => sum += next);
                }
                catch (InvalidOperationException)
                {
                    // The sequence of "money" items was empty;
                    // Continue with moneyValue = 0.
                }
                player.Items = PlayerItemLocker;
                player.ArmorClass = PlayerArmorLocker;
                if (moneyValue > 0)
                {
                    player.GoldInBank += (ulong)moneyValue;
                    Logger.WriteLn("The value of all currency you collected has been transferred, at current exchange rates, to your account at the Bank of Eamon.\n");
                }
                Logger.WriteLn("Your weapons and armor have been returned.\n");
            }
        }
    }
}