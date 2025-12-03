using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Adventure.Dungeon
{
    internal class CommandEngine
    {
        private readonly List<string> COMMAND_LIST = new List<string>() { "north", "northeast", "northwest","east",
                                                                       "south", "southeast", "southwest", "west", "up", "down", "flee",
                                                                       "look", "attack", "get", "use", "drop", "inventory", "read", "ready", "smile",
                                                                       "wave", "help", "blast", "heal", "power", "speed", "light", "unlight",
                                                                       "extinguish", "examine", "drink", "open", "close", "put", "say", "wait",
                                                                       "wear", "remove" };
        private readonly List<string> ABBREV_LIST = new List<string>() { "ne", "nw", "se", "sw" };

        private readonly List<string> FLEE_PHRASES = new List<string>() { "You bolt to the nearest exit, to escape to more tactically advantageous ground!",
                                                                          "You bravely turn your tail and run!",
                                                                          "Again? And people are hard on the French!" };
        private int fleePhraseIndex = 0;

        private List<string> ALL_COMMANDS;

        private event EventHandler OnKilled;

        DungeonLoader loader;

        private Context currentContext;

        private List<int> repeatEncounters { get; set; }

        private CombatEngine combatEngine { get; set; }

        private Character player { get; set; }

        private string roomFileName { get; set; }

        List<int> tempMonstersInRoom = new List<int>();

        private Random rand = new Random();
        private int speedCountDown = 0;

        public bool Initialize(Character character)
        {
            ALL_COMMANDS = new List<string>();
            ALL_COMMANDS.AddRange(COMMAND_LIST);
            ALL_COMMANDS.AddRange(ABBREV_LIST);

            bool retVal = true;
            currentContext = Context.Instance;
            loader = new DungeonLoader();
            currentContext.Player = character;
            player = character;

            using (OpenFileDialog dungeonFileDial = new OpenFileDialog())
            {
                dungeonFileDial.Title = "Select your Adventure";
                dungeonFileDial.InitialDirectory = @"..\..";
                dungeonFileDial.Filter = "XML files|*.xml";
                dungeonFileDial.ShowDialog();

                roomFileName = dungeonFileDial.FileName;
            }
            if (string.IsNullOrEmpty(roomFileName))
            {
                retVal = false;
            }
            else
            {
                currentContext.DungeonFile = roomFileName;
                LoadDungeon(loader, roomFileName);
                combatEngine = new CombatEngine();
                SubscribeMainHallEvent(onReturnToMainHall);
            }

            return retVal;
        }

        private void LoadDungeon(DungeonLoader loader, string roomFileName)
        {
            loader.LoadDungeonData(roomFileName);
            currentContext.rooms = loader.LoadRooms();
            loader.PrepCharacter(player);
            currentContext.CurrentRoom = currentContext.rooms["Entrance"];
            Logger.WriteLn(loader.Intro());
            Logger.Write(currentContext.CurrentRoom.Description);
            AppendCreaturesToOutput();
            AppendItemsToOutput();

            currentContext.CurrentRoom.FirstLook = false;
            repeatEncounters = new List<int>();
        }

        public void ReinitializeDungeon()
        {
            DungeonLoader loader = new DungeonLoader();
            LoadDungeon(loader, currentContext.DungeonFile);
        }

        public void ParseCommand(string commandStr)
        {
            // Remember the monsters in the room at start of this turn;
            // if any are awakened during the turn, we don't want them
            // attacking or dying before they've been properly introduced.
            tempMonstersInRoom.Clear();
            tempMonstersInRoom.AddRange(currentContext.CurrentRoom.Creatures.Select<Monster, int>((m, i) => i = m.ID));

            string[] command = commandStr.Split(new char[] { ' ' });
            if (string.IsNullOrWhiteSpace(command[0]))
            {
                 return;
            }

            string resolvedCommand = ALL_COMMANDS.Find((s) => { return CompareNames(command[0], s); });

            Logger.WriteLn();
            Logger.Write(string.Format("YOUR COMMAND: {0}", resolvedCommand));
            switch (resolvedCommand)
            {
                case "help":
                    Logger.WriteLn("\n");
                    Logger.WriteLn("You can use any of the following commands:");
                    Logger.WriteLn(string.Join(", ", COMMAND_LIST));
                    Logger.WriteLn();
                    Logger.WriteLn("You can also abbreviate the direction commands, such as:");
                    Logger.WriteLn(string.Join(", ", ABBREV_LIST));
                    Logger.WriteLn();
                    Logger.WriteLn("For most commands, you can just type the first one or two letters.");
                    break;
                case "north":
                    {
                        MoveCommand(directionType.n);

                        break;
                    }
                case "northeast":
                case "ne":
                    {
                        MoveCommand(directionType.ne);

                        break;
                    }
                case "east":
                    {
                        MoveCommand(directionType.e);

                        break;
                    }
                case "southeast":
                case "se":
                    {
                        MoveCommand(directionType.se);

                        break;
                    }
                case "south":
                    {
                        MoveCommand(directionType.s);

                        break;
                    }
                case "southwest":
                case "sw":
                    {
                        MoveCommand(directionType.sw);

                        break;
                    }
                case "west":
                    {
                        MoveCommand(directionType.w);

                        break;
                    }
                case "northwest":
                case "nw":
                    {
                        MoveCommand(directionType.nw);

                        break;
                    }
                case "down":
                    {
                        MoveCommand(directionType.d);

                        break;
                    }
                case "up":
                    {
                        MoveCommand(directionType.u);

                        break;
                    }
                case "flee":
                    {
                        Logger.WriteLn("\n");
                        if (GetHostiles(tempMonstersInRoom).Count > 0)
                        {
                            if (rand.Next(100) > 50)
                            {
                                Logger.WriteLn("You try to flee, but can't get away!");
                            }
                            else
                            {
                                Logger.WriteLn(FLEE_PHRASES[fleePhraseIndex]);
                                fleePhraseIndex++;
                                if (fleePhraseIndex >= FLEE_PHRASES.Count)
                                {
                                    fleePhraseIndex = 0;
                                }

                                int exitIndex = rand.Next(currentContext.CurrentRoom.Exits.Where(p => p.Value.Visible).Count() - 1);

                                MoveCommand(currentContext.CurrentRoom.Exits.Keys.ToArray()[exitIndex], true);
                            }
                        }
                        else
                        {
                            Logger.WriteLn("There is nothing to flee from.");
                        }
                        break;
                    }
                case "look":
                    {
                        DoLook(command, false);
                        PostAction();
                        break;
                    }
                case "examine":
                    {
                        DoLook(command, true);
                        PostAction();
                        break;
                    }
                case "attack":
                    {
                        Monster target = null;
                        if (command.Count() < 2)
                        {
                            Logger.WriteLn("\n");
                            Logger.WriteLn("Attack who?");
                        }
                        else
                        {
                            target = currentContext.CurrentRoom.Creatures.Find(m => { return CompareNames(command[1], m.Name); });

                            if (target == null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write(string.Format("{0} is not here.", command[1]));
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", target.Name));
                                if (player.ReadyWeap == null)
                                {
                                    Logger.WriteLn("\n");
                                    Logger.WriteLn("You have no weapon ready!");
                                }
                                else
                                {
                                    combatEngine.Attack(currentContext.CurrentRoom, player, target);
                                    if (target.HP != 0)
                                    {
                                        CheckDisposition(target);
                                    }
                                }
                            }
                        }
                        PostAction();
                        break;
                    }
                case "get":
                    {
                        int totWeight = 0;
                        foreach (itemType item in player.Items)
                        {
                            totWeight += item.Weight;
                        }
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Get what?");
                        }
                        else if (command[1] == "all")
                        {
                            Logger.WriteLn(" all\n");
                            for (int idx = currentContext.CurrentRoom.Items.Count - 1; idx >= 0; idx--)
                            {
                                itemType i = currentContext.CurrentRoom.Items[idx];
                                if (i.weight != -999 && i.weight != 999 && totWeight + i.weight <= player.MaxWeight)
                                {
                                    totWeight += i.weight;
                                    player.Items.Add(i);
                                    currentContext.CurrentRoom.Items.Remove(i);
                                    Logger.Write(string.Format("{0} taken\n", i.name));
                                    i.DoGet();
                                }
                                else
                                {
                                    Logger.Write(string.Format("{0} is too heavy!\n", i.name));
                                }
                            }
                        }
                        else
                        {
                            bool found = false;
                            foreach (itemType i in currentContext.CurrentRoom.Items)
                            {
                                if (CompareNames(command[1], i.name))
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", i.name));
                                    if (i.Weight == -999)
                                    {
                                        Logger.WriteLn("You can't get that.");
                                    }
                                    else if (i.Weight == 999)
                                    {
                                        Logger.WriteLn("Don't be absurd!");
                                    }
                                    else if (totWeight + i.Weight > player.MaxWeight)
                                    {
                                        Logger.Write(string.Format("{0} is too heavy!\n", i.name));
                                    }
                                    else
                                    {
                                        player.Items.Add(i);
                                        currentContext.CurrentRoom.Items.Remove(i);
                                        Logger.Write(string.Format("{0} taken", i.name));
                                        i.DoGet();
                                    }
                                    found = true;
                                    break;
                                }
                                else if (i.storage != null)
                                {
                                    found = GetItemFromContainer(command, i, totWeight, false);
                                }

                            }

                            if (!found)
                            {
                                foreach (itemType i in player.Items)
                                {
                                    if (CompareNames(command[1], i.name))
                                    {
                                        found = true;
                                        Logger.WriteLn(string.Format(" {0}\n", i.name));
                                        Logger.WriteLn("You are already holding it.");
                                    }
                                    else if (i.storage != null)
                                    {
                                        found = GetItemFromContainer(command, i, totWeight, true);
                                    }
                                    if (found)
                                    {
                                        break;
                                    }
                                }
                            }

                            if (!found)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write("You don't see that here.");
                            }
                        }
                        PostAction();
                        break;
                    }
                case "use":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Use what?");
                        }
                        else
                        {
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (item != null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                if (item.HasUseEvent())
                                {
                                    item.DoUse();
                                }
                                else if (!unlockExits(resolvedCommand, item))
                                {
                                    Logger.Write("You can't use that here.");
                                }
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write(string.Format("You don't have a {0}.", command[1]));
                            }
                        }
                        PostAction();
                        break;
                    }
                case "drop":
                    {
                        DoDrop(command);
                        PostAction();
                        break;
                    }
                case "drink":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Drink what?");
                        }
                        else
                        {
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (item != null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                if (item.HasDrinkEvent())
                                {
                                    item.DoDrink();
                                }
                                else if (!unlockExits(resolvedCommand, item))
                                {
                                    Logger.Write("You can't drink that.");
                                }
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write(string.Format("You don't have a {0}.", command[1]));
                            }
                        }
                        PostAction();
                        break;
                    }
                case "inventory":
                    {
                        Logger.WriteLn();
                        if (player.Items.Count == 0)
                        {
                            Logger.Write("You aren't carrying anything.");
                        }
                        else
                        {
                            Logger.Write("You are holding:");
                            foreach (itemType i in player.Items)
                            {
                                Logger.Write("\n  " + i.name);
                                if (i.isLit)
                                {
                                    Logger.Write(" (providing light)");
                                }
                                if (player.WornItems.Contains(i))
                                {
                                    Logger.Write(" (worn)");
                                }
                                if (player.ReadyWeap == i)
                                {
                                    Logger.Write(" (readied)");
                                }
                            }
                        }
                        break;
                    }
                case "ready":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Ready which weapon?");
                        }
                        else
                        {
                            // Search inventory for a weapon of that name
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name) && i as weaponData != null; });
                            if (item != null)
                            {
                                unlockExits(resolvedCommand, item);
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                player.ReadyWeap = (weaponData)item;
                                Logger.Write(string.Format("{0} Readied.", player.ReadyWeap.name));
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.WriteLn("Don't be ridiculous.");
                            }
                            PostAction();
                        }
                        break;
                    }
                case "read":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Read what?");
                        }
                        else
                        {
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (item != null)
                            {
                                // Found the item. Complete the command echo and read it.
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                ReadItem(item);
                            }
                            else
                            {
                                item = currentContext.CurrentRoom.Items.Find(i => { return CompareNames(command[1], i.name); });
                                if (item != null)
                                {
                                    // Found the item. Complete the command echo.
                                    Logger.WriteLn(string.Format(" {0}\n", item.name));
                                    // If it is something you can not hold (furniture, a sign on
                                    // the wall, etc., read it.
                                    // Otherwise, you need to pick it up first.
                                    if (item.weight == 999 || item.weight == -999)
                                    {
                                        ReadItem(item);
                                    }
                                    else
                                    {
                                        Logger.Write("You aren't holding that.");
                                    }
                                }
                                else
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                    Logger.Write(string.Format("You don't have a {0}.", command[1]));
                                }
                            }
                        }
                        PostAction();
                        break;
                    }
                case "smile":
                case "wave":
                    {
                        Logger.WriteLn("\n");
                        foreach (Monster m in currentContext.CurrentRoom.Creatures)
                        {
                            string response = "";

                            UpdateDisposition(m);

                            switch (m.Disposition)
                            {
                                case DispositionType.Angry:
                                    response = "growls at you.";
                                    break;
                                case DispositionType.Friendly:
                                    response = resolvedCommand + "s back.";
                                    break;
                                default:
                                    response = "ignores you.";
                                    break;
                            }
                            Logger.WriteLn(string.Format("{0} {1}", m.Name, response));
                        }
                        break;
                    }
                case "blast":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.WriteLn("Blast what?");
                        }
                        else
                        {
                            Creature targetCreature = currentContext.CurrentRoom.Creatures.Find(m => { return CompareNames(command[1], m.Name); });
                            Logger.WriteLn(string.Format(" {0}\n", targetCreature.Name));

                            if (targetCreature != null)
                            {
                                if (tryCast(spellType.Blast))
                                {
                                    castBlast(command, targetCreature);
                                }
                            }
                            else
                            {
                                itemType targetItem = currentContext.CurrentRoom.Items.Find(i => { return CompareNames(command[1], i.name); });
                                if (targetItem == null)
                                {
                                    targetItem = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                                }
                                if (targetItem != null)
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", targetItem.name));
                                    if (tryCast(spellType.Blast))
                                    {
                                        targetItem.DoBlast();
                                    }
                                }
                                else
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                    Logger.Write("You don't see that here.");
                                }
                            }
                            PostAction();
                        }
                        break;
                    }
                case "heal":
                    {
                        Logger.WriteLn("\n");
                        if (tryCast(spellType.Heal))
                        {
                            castHeal(command);
                        }
                        PostAction();
                        break;
                    }
                case "power":
                    {
                        Logger.WriteLn("\n");
                        if (tryCast(spellType.Power))
                        {
                            castPower();
                        }
                        PostAction();
                        break;
                    }
                case "speed":
                    {
                        Logger.WriteLn("\n");
                        if (tryCast(spellType.Speed))
                        {
                            castSpeed();
                        }
                        PostAction();
                        break;
                    }
                case "light":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.WriteLn("Light what?");
                        }
                        else
                        {
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (item != null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                if (item.isLit)
                                {
                                    Logger.WriteLn("It's already lit.");
                                }
                                else if (item.canLight)
                                {
                                    Logger.WriteLn("Light fills the room.\n");
                                    item.isLit = true;
                                    DescribeRoom();
                                }
                                else
                                {
                                    Logger.Write("You can't light that.");
                                }
                            }
                            else
                            {
                                Logger.Write(string.Format("You don't have a {0}.", command[1]));
                            }
                        }
                        PostAction();
                        break;
                    }
                case "unlight":
                case "extinguish":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("I don't know how to do that.");
                        }
                        else
                        {
                            itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (item != null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", item.name));
                                if (item.isLit)
                                {
                                    Logger.WriteLn("It ceases to give its light.");
                                    item.isLit = false;
                                    if (!checkLight())
                                    {
                                        Logger.WriteLn("It's too dark to see.");
                                    }
                                }
                                else
                                {
                                    Logger.WriteLn("\nIt isn't lit.");
                                }
                            }
                            else
                            {
                                Logger.WriteLn(string.Format("You don't have a {0}.", command[1]));
                            }
                        }
                        PostAction();
                        break;
                    }
                case "open":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Open what?");
                        }
                        else
                        {
                            bool found = false;
                            itemType theContainer = null;
                            foreach (itemType i in currentContext.CurrentRoom.Items)
                            {
                                if (CompareNames(command[1], i.name))
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", i.name));
                                    // If it's something that cannot be carried (i.e. a large chest), try to open it in place
                                    if (i.weight == -999)
                                    {
                                        theContainer = i;
                                    }
                                    else if (i.weight == 999)
                                    {
                                        theContainer = i;
                                    }
                                    else
                                    {
                                        // If it's a portable container (a small chest or sack), you need to be holding it to open it.
                                        Logger.WriteLn(string.Format("Try picking it up first."));
                                    }
                                    found = true;
                                    break;
                                }
                            }

                            if (!found)
                            {
                                theContainer = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                                if (theContainer != null)
                                {
                                    found = true;
                                }
                            }

                            if (found)
                            {
                                if (theContainer != null)
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", theContainer.name));
                                    if (theContainer.storage == null)
                                    {
                                        Logger.WriteLn("You can't open that.");
                                    }
                                    else if (theContainer.storage.isOpen)
                                    {
                                        Logger.WriteLn("It's already open.");
                                    }
                                    else if (theContainer.HasOpenEvent())
                                    {
                                        theContainer.DoOpen();
                                        theContainer.storage.isOpen = true;
                                    }
                                    else if (!theContainer.storage.openable)
                                    {
                                        if (theContainer.storage.CantOpenPhrase != null)
                                        {
                                            Logger.WriteLn(theContainer.storage.CantOpenPhrase);
                                        }
                                        else
                                        {
                                            Logger.WriteLn("You can't open that.");
                                        }
                                    }
                                    else
                                    {
                                        theContainer.storage.isOpen = true;
                                        Logger.WriteLn(string.Format("You open the {0}.", theContainer.name));
                                    }
                                }
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write("You don't see that here.");
                            }
                        }
                        PostAction();
                        break;
                    }
                case "close":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.Write("Close what?");
                        }
                        else
                        {
                            bool found = false;
                            itemType theContainer = null;
                            foreach (itemType i in currentContext.CurrentRoom.Items)
                            {
                                if (CompareNames(command[1], i.name))
                                {
                                    Logger.WriteLn(string.Format(" {0}\n", i.name));
                                    // If it's something that cannot be carried (a large chest or cabinet), try to close it in place
                                    if (i.weight == -999)
                                    {
                                        theContainer = i;
                                    }
                                    else if (i.weight == 999)
                                    {
                                        theContainer = i;
                                    }
                                    else
                                    {
                                        // If it's a portable container (a small chest or sack), you need to be holding it to close it.
                                        Logger.WriteLn(string.Format("Try picking it up first."));
                                    }
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                if (theContainer != null)
                                {
                                    if (theContainer.storage == null || !theContainer.storage.closable)
                                    {
                                        Logger.WriteLn(string.Format("You can't close that."));
                                    }
                                    else if (!theContainer.storage.isOpen)
                                    {
                                        Logger.WriteLn(string.Format("It's already closed."));
                                    }
                                    else if (theContainer.HasCloseEvent())
                                    {
                                        theContainer.DoClose();
                                        theContainer.storage.isOpen = false;
                                    }
                                    else
                                    {
                                        theContainer.storage.isOpen = false;
                                        Logger.WriteLn(string.Format("You close the {0}.", theContainer.name));
                                    }
                                }
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.Write("You don't see that here.");
                            }
                        }
                        PostAction();
                        break;
                    }
                case "put":
                    {
                        if (command.Length < 2)
                        {
                            Logger.WriteLn("\n");
                            Logger.WriteLn("Put what?");
                        }
                        else
                        {
                            itemType toPut = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (toPut == null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toPut.name));
                                Logger.WriteLn(string.Format("You don't have a {0}.", command[1]));
                            }
                            else if (command.Length < 3)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toPut.name));
                                Logger.WriteLn("Where do you want to put it?");
                            }
                            else if ("down".Equals(command[2], StringComparison.CurrentCultureIgnoreCase))
                            {
                                Logger.WriteLn(string.Format(" {0} down\n", toPut.name));
                                DoDrop(command);
                            }
                            else if ("in".Equals(command[2], StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (command.Length < 4)
                                {
                                    Logger.WriteLn(string.Format(" {0} in\n", toPut.name));
                                    Logger.WriteLn("What do you want to put it in?");
                                }
                                else
                                {
                                    itemType theContainer = player.Items.Find(i => { return CompareNames(command[3], i.name); });
                                    if (theContainer == null)
                                    {
                                        theContainer = currentContext.CurrentRoom.Items.Find(i => { return CompareNames(command[3], i.name); });
                                    }

                                    if (theContainer == null)
                                    {
                                        Logger.WriteLn(string.Format(" {0} in {1}\n", toPut.name, command[3]));
                                        Logger.WriteLn(string.Format("You don't see a {0} here.", command[3]));
                                    }
                                    else
                                    {
                                        if (theContainer.storage == null)
                                        {
                                            Logger.WriteLn(string.Format(" {0} in {1}\n", toPut.name, theContainer.name));
                                            Logger.WriteLn("You can't put anything in that.");
                                        }
                                        else if (!theContainer.storage.isOpen)
                                        {
                                            Logger.WriteLn(string.Format(" {0} in {1}\n", toPut.name, theContainer.name));
                                            Logger.WriteLn("You'll have to open it first.");
                                        }
                                        else
                                        {
                                            if (theContainer.storage.Add(toPut))
                                            {
                                                Logger.WriteLn(string.Format(" {0} in {1}\n", toPut.name, theContainer.name));
                                                player.Items.Remove(toPut);
                                                toPut.DoPut(theContainer.id);
                                            }
                                            else
                                            {
                                                Logger.WriteLn("It's too big.");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        PostAction();
                        break;
                    }

                case "wait":
                    {
                        Logger.WriteLn("\nTime passes.");
                        PostAction();
                        break;
                    }

                case "wear":
                    {
                        if (command.Length < 2)
                        {
                            Logger.WriteLn("Wear what?");
                        }
                        else
                        {
                            itemType toWear = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                            if (toWear == null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.WriteLn(string.Format("You don't have a {0}.", command[1]));
                            }
                            else if (!toWear.isWearable)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toWear.name));
                                Logger.WriteLn(string.Format("You can't wear that."));
                            }
                            else if (player.WornItems.Contains(toWear))
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toWear.name));
                                Logger.WriteLn(string.Format("You are already wearing that."));
                            }
                            else if (toWear.isArmor && player.ArmorClass > 1)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toWear.name));
                                Logger.WriteLn(string.Format("You are already wearing armor."));
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toWear.name));
                                Logger.WriteLn(string.Format("You put it on."));
                                player.WearItem(toWear);
                                unlockExits(resolvedCommand, toWear);

                            }
                        }
                        PostAction();
                        break;
                    }

                case "remove":
                    {
                        if (command.Length < 2)
                        {
                            Logger.WriteLn("Remove what?");
                        }
                        else
                        {
                            itemType toRemove = player.WornItems.Find(i => { return CompareNames(command[1], i.name); });
                            if (toRemove == null)
                            {
                                Logger.WriteLn(string.Format(" {0}\n", command[1]));
                                Logger.WriteLn("You aren't wearing that.");
                            }
                            else
                            {
                                Logger.WriteLn(string.Format(" {0}\n", toRemove.name));
                                Logger.WriteLn("You take it off.");
                                player.RemoveItem(toRemove);
                                unlockExits(resolvedCommand, toRemove);
                            }
                        }
                        break;
                    }

                case "say":
                    {
                        if (command.Length == 1)
                        {
                            Logger.WriteLn("\n");
                            Logger.WriteLn("Say what?");
                        }
                        else
                        {
                            string words = string.Join(" ", command.Skip(1));
                            Logger.WriteLn(" " + words);
                            Logger.WriteLn("\nOk. \"" + words + "\"\n");
                            currentContext.CurrentRoom.DoMagicWord(words);

                            foreach (Monster m in currentContext.CurrentRoom.Creatures)
                            {
                                m.MagicWord(words);
                            }
                            foreach (itemType m in player.Items)
                            {
                                m.DoMagicWord(words);
                            }
                            foreach (itemType m in currentContext.CurrentRoom.Items)
                            {
                                m.DoMagicWord(words);
                            }
                        }
                        PostAction();
                        break;
                    }
                /// TODO:
                /// multiple monsters
                /// blast doors?
                /// light:
                ///  limited charges
                /// actions:
                ///  Boost Monster Stat (target (monster id), stat, value)
                default:
                    {
                        Logger.WriteLn("\n");
                        Logger.Write("I don't know what that means.");
                        break;
                    }
            }

            if (player.HP <= 0)
            {
                OnKilled?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                AppendCreaturesToOutput();
                AppendItemsToOutput();
            }
        }

        private bool unlockExits(string resolvedCommand, itemType item)
        {
            var exitsToUnlock = currentContext.CurrentRoom.Exits.Where((pair) =>
            {
                LockableExit temp = pair.Value as LockableExit;
                if (temp != null)
                {
                    if (temp.KeyItemId == item.id.ToString() && temp.KeyItemAction == resolvedCommand)
                    {
                        return true;
                    }
                }
                return false;
            });
            ILockable toUnlock = null;
            if (exitsToUnlock.Count() == 1)
            {
                toUnlock = (ILockable)exitsToUnlock.First().Value;
                if (toUnlock != null)
                {
                    Logger.Write(toUnlock.Unlock());
                    return true;
                }
            }
            ///TODO: specify a door
            //else if (exitsToUnlock.Count() > 1)
            //{

            //}
            return false;
        }

        private static void ReadItem(itemType item)
        {
            if (item.HasReadEvent())
            {
                item.DoRead();
            }
            else
            {
                Logger.Write("You don't see any writing on it.");
            }
        }

        private bool GetItemFromContainer(string[] command, itemType i, int totWeight, bool holdingContainer)
        {
            bool found = false;
            for (int i1 = 0; i1 < i.storage.ContentsList.Count && !found; i1++)
            {
                itemType storedItem = i.storage.ContentsList[i1];
                if (CompareNames(command[1], storedItem.name))
                {
                    found = true;
                    if (holdingContainer || totWeight + i.weight <= player.MaxWeight)
                    {
                        i.storage.Remove(storedItem);
                        player.Items.Add(storedItem);
                        Logger.WriteLn(string.Format(" {0}\n", storedItem.name));
                        Logger.WriteLn("Taken.");
                    }
                    else
                    {
                        Logger.Write(string.Format("{0} is too heavy!\n", storedItem.name));
                    }
                }
                else if (storedItem.storage != null)
                {
                    found = GetItemFromContainer(command, storedItem, totWeight, holdingContainer);
                }
            }

            return found;
        }

        private void DoDrop(string[] command)
        {
            if (command.Length == 1)
            {
                Logger.WriteLn("\n");
                Logger.Write("Drop what?");
            }
            else if (command[1] == "all")
            {
                Logger.WriteLn(" all\n");
                while (player.Items.Count > 0)
                {
                    itemType i = player.Items.First();
                    currentContext.CurrentRoom.Items.Add(i);
                    player.Items.Remove(i);
                    Logger.Write(string.Format("{0} dropped\n", i.name));
                    i.DoDrop();
                }
            }
            else
            {
                itemType item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                if (item != null)
                {
                    Logger.WriteLn(string.Format(" {0}\n", item.name));
                    player.Items.Remove(item);
                    currentContext.CurrentRoom.Items.Add(item);
                    Logger.Write("Dropped.");
                    item.DoDrop();
                }
                else
                {
                    Logger.WriteLn(string.Format(" {0}\n", command[1]));
                    Logger.Write(string.Format("You don't have a {0}.", command[1]));
                }
            }
        }

        private void UpdateDisposition(Monster m)
        {
            if (m.Disposition == DispositionType.Neutral)
            {
                if (rand.Next(100) < (player.Charisma - 10) * 2 + m.Friendliness)
                {
                    m.Disposition = DispositionType.Friendly;
                }
                else
                {
                    m.Disposition = DispositionType.Angry;
                }
            }
        }

        private void DoLook(string[] command, bool examine)
        {
            if (command.Length > 1 && !string.IsNullOrEmpty(command[1]))
            {
                itemType item = currentContext.CurrentRoom.Items.Find(i => { return CompareNames(command[1], i.name); });
                if (item != null)
                {
                    Logger.WriteLn(string.Format(" {0}\n", item.name));
                    ItemLookCommand(item);
                    if (examine)
                    {
                        Logger.WriteLn("\n");
                        item.DoExamine();
                    }
                }
                else
                {
                    item = player.Items.Find(i => { return CompareNames(command[1], i.name); });
                    if (item != null)
                    {
                        Logger.WriteLn(string.Format(" {0}\n", item.name));
                        ItemLookCommand(item);
                        if (examine)
                        {
                            Logger.WriteLn("\n");
                            item.DoExamine();
                        }
                    }
                    else
                    {
                        Monster monster = currentContext.CurrentRoom.Creatures.Find(c => { return CompareNames(command[1], c.Name); });
                        if (monster != null)
                        {
                            Logger.WriteLn(string.Format(" {0}\n", monster.Name));
                            MonsterLookCommand(monster);
                        }
                        else
                        {
                            Logger.WriteLn("\n");
                            if (checkLight())
                                Logger.WriteLn("You don't see that here.");
                        }
                    }
                }
            }
            else
            {
                Logger.WriteLn("\n");
                RoomLookCommand();
                if (examine)
                {
                    Logger.WriteLn("\n");
                    currentContext.CurrentRoom.DoExamine();
                }
            }
        }

        private void DescribeRoom()
        {
            if (currentContext.CurrentRoom.FirstLook)
            {
                Logger.WriteLn(currentContext.CurrentRoom.Description);
                currentContext.CurrentRoom.FirstLook = false;

            }
            else
            {
                Logger.WriteLn(currentContext.CurrentRoom.ShortDescription);
            }
        }

        private void castBlast(string[] command, Creature target)
        {
            if (target == null)
            {
                Logger.WriteLn("\n");
                Logger.Write(string.Format("{0} is not here.", command[1]));
            }
            else
            {
                diceType blastDice = new diceType();
                blastDice.Count = 2;
                blastDice.Sides = 5;
                target.TakeDamage(blastDice.Roll());

                target.blast();
                // If the target is a creature in the room and it died, remove it
                if (target.HP == 0)
                {
                    currentContext.CurrentRoom.Creatures.Remove((Monster)target);
                }
            }
        }

        private void castHeal(string[] command)
        {
            Creature target = null;
            if (string.IsNullOrEmpty(command[1]))
            {
                target = player;
            }
            else
            {
                target = currentContext.CurrentRoom.Creatures.Find(m => { return CompareNames(command[1], m.Name); });
            }

            if (target == null)
            {
                Logger.WriteLn("\n");
                Logger.Write(string.Format("{0} is not here.", command[1]));
            }
            else
            {
                target.Heal(rand.Next(10) + 2);
            }
        }

        private void castSpeed()
        {
            player.Agility *= 2;
            speedCountDown = rand.Next(25) + 10;
        }

        private void castPower()
        {
            bool poweredSomething = currentContext.CurrentRoom.DoPower();
            foreach (Monster m in currentContext.CurrentRoom.Creatures)
            {
                if (m.power())
                {
                    poweredSomething = true;
                    break;
                }
            }
            foreach (itemType m in currentContext.CurrentRoom.Items)
            {
                if (m.DoPower())
                {
                    poweredSomething = true;
                    break;
                }
            }
            foreach (itemType m in player.Items)
            {
                if (m.DoPower())
                {
                    poweredSomething = true;
                    break;
                }
            }
            if (!poweredSomething)
            {
                int result = rand.Next(100);
                if (result <= 10)
                {
                    // Player fully healed
                    Logger.WriteLn("Your wounds heal!");
                    player.Heal(player.MaxHP);
                }
                else if (result > 90 && currentContext.CurrentRoom.Creatures.Count > 0)
                {
                    // Monsters fully healed
                    foreach (Monster m in currentContext.CurrentRoom.Creatures)
                    {
                        Logger.WriteLn(m.Name + " heals!");
                        m.Heal(m.MaxHP);
                    }
                }
                else
                {
                    Logger.WriteLn("You hear a very loud sonic boom that echoes through the tunnels.");
                }
            }
        }

        /// <summary>
        /// Determine whether player's attempt to cast the spell is successful.
        /// Handles any changes in spell skill level.
        /// </summary>
        /// <param name="spell"></param>
        /// <returns></returns>
        private bool tryCast(spellType spell)
        {
            if (player.CurrentSpellSkills[spell] == 0)
            {
                Logger.WriteLn("You have not learned the " + spell + " spell.");
                return false;
            }

            bool success = false;
            int roll = rand.Next(100);

            // Succeed if roll < current skill level.
            // Minimum of 5% chance of success, Maximum of 95%.
            if ((roll < player.CurrentSpellSkills[spell] || roll < 5) && roll < 95)
            {
                success = true;

                // Random number to check for skill increase
                roll = rand.Next(100);
                if (roll > player.SpellSkills[spell])
                {
                    player.SpellSkills[spell] += 2;
                    player.CurrentSpellSkills[spell] += 2;
                }

                //Diminish current skill level by 20% (fatigue from repeat casting)
                player.CurrentSpellSkills[spell] = Math.Round(player.CurrentSpellSkills[spell] * 0.8, 1);
            }
            else if (roll == 100)
            {
                Logger.WriteLn("SPELL BACKLASH!! YOUR ABILITY TO CAST THIS SPELL TEMPORARILY DIMINISHES!");
                player.CurrentSpellSkills[spell] = Math.Round(player.CurrentSpellSkills[spell] * 0.1, 1); ;
            }
            else
            {
                Logger.WriteLn("Nothing happens.");
            }

            return success;
        }

        private static void CheckDisposition(Monster target)
        {
            if (target.Disposition == DispositionType.Neutral)
            {
                target.Disposition = DispositionType.Angry;
                Logger.WriteLn(string.Format("\n{0} joins the fray against you!", target.Name));
            }
            else if (target.Disposition == DispositionType.Friendly)
            {
                target.Disposition = DispositionType.Neutral;
                Logger.WriteLn(string.Format("\n{0} is suddenly less enamoured with you.", target.Name));
            }
        }

        private void PostAction()
        {
            List<string> timersToRemove = new List<string>();

            // Monsters take their actions
            foreach (int i in tempMonstersInRoom)
            {
                // Make sure this monster wasn't already killed
                // (it would have been removed from the room's creature list)
                Monster monster = currentContext.CurrentRoom.Creatures.Find(m => m.ID == i);
                if (monster != null)
                {
                    if (monster.CourageTest(rand))
                    {
                        switch (monster.Disposition)
                        {
                            case DispositionType.Angry:
                                // Hostiles attack, if player is still alive
                                if (player.HP > 0)
                                {
                                    // Check to see if it needs to pick up a weapon. If it does, don't use it until next turn
                                    if (!monster.PickupWeapon(currentContext.CurrentRoom.Items))
                                    {
                                        // List the friendly creatures and attack one at random
                                        List<ICreature> friendlies = GetFriendlies(tempMonstersInRoom).ConvertAll<ICreature>(o => (ICreature)o);
                                        friendlies.Add(player);
                                        int numfriendlies = friendlies.Count;
                                        int idx = new Random().Next(numfriendlies);
                                        combatEngine.Attack(currentContext.CurrentRoom, monster, friendlies[idx]);
                                    }
                                }
                                break;
                            case DispositionType.Friendly:
                                //Friendlies attack hostiles
                                // Check to see if it needs to pick up a weapon. If it does, don't use it until next turn
                                if (!monster.PickupWeapon(currentContext.CurrentRoom.Items))
                                {
                                    // List the hostile creatures and attack one at random
                                    List<Monster> hostiles = GetHostiles(tempMonstersInRoom);
                                    int numHostiles = hostiles.Count;
                                    if (numHostiles > 0)
                                    {
                                        int idx = new Random().Next(numHostiles);
                                        combatEngine.Attack(currentContext.CurrentRoom, monster, hostiles[idx]);
                                    }
                                }
                                break;
                            default:
                                // Neutrals watch the fight
                                break;
                        }
                    }
                    else if (monster.Disposition != DispositionType.Friendly || GetHostiles(tempMonstersInRoom).Count > 0)
                    {
                        // Monster flees
                        BaseExit[] exits = currentContext.CurrentRoom.Exits.Values.Where((e) => !e.ToMainHall).ToArray();
                        int exitIndex = rand.Next(exits.Count() - 1);
                        IRoom fleeExit = exits[exitIndex].Go(currentContext.CurrentRoom);
                        fleeExit.Creatures.Add(monster);
                        currentContext.CurrentRoom.Creatures.Remove(monster);
                        Logger.WriteLn(string.Format("\n{0} flees!", monster.Name));
                    }
                }
            }

            // Spell abilities recover
            foreach (spellType s in Enum.GetValues(typeof(spellType)))
            {
                if (player.CurrentSpellSkills[s] < player.SpellSkills[s])
                {
                    player.CurrentSpellSkills[s] = player.CurrentSpellSkills[s] * 1.1;
                    if (player.CurrentSpellSkills[s] > player.SpellSkills[s])
                    {
                        player.CurrentSpellSkills[s] = player.SpellSkills[s];
                    }
                }
            }

            if (speedCountDown > 0)
            {
                speedCountDown -= 1;
                if (speedCountDown == 0)
                {
                    Logger.WriteLn("\nYour speed spell has expired.");
                    player.Agility /= 2;
                }
            }

            for (int i=0; i < TurnTimer.Timers.Count; i++)
            {
                TurnTimer t = TurnTimer.Timers.Values.ElementAt(i);
                if (t.Tick())
                {
                    timersToRemove.Add(t.Name);
                }
            }
            foreach (string tname in timersToRemove)
                TurnTimer.Timers.Remove(tname);
            timersToRemove.Clear();
        }

        private List<Monster> GetHostiles(IEnumerable<int> tempMonsters)
        {
            List<Monster> hostiles = currentContext.CurrentRoom.Creatures.FindAll((mon) =>
            {
                return mon != null
                    && tempMonsters.Contains(mon.ID)
                    && mon.Disposition == DispositionType.Angry;
            });
            return hostiles;
        }

        private List<Monster> GetFriendlies(IEnumerable<int> tempMonsters)
        {
            List<Monster> friendlies = currentContext.CurrentRoom.Creatures.FindAll((mon) =>
            {
                return mon != null
                    && tempMonsters.Contains(mon.ID)
                    && mon.Disposition == DispositionType.Friendly;
            });
            return friendlies;
        }

        private void MoveCommand(directionType direction, bool fleeing = false)
        {
            // Finish logging the resolved command line (if fleeing, we already did)
            if (!fleeing)
            {
                Logger.WriteLn("\n");
            }

            if (fleeing || GetHostiles(tempMonstersInRoom).Count == 0)
            {
                BaseExit exit;
                if (currentContext.CurrentRoom.Exits.TryGetValue(direction, out exit) && exit.Visible)
                {
                    IRoom nextRoom = exit.Go(currentContext.CurrentRoom);

                    if (nextRoom != currentContext.CurrentRoom)
                    {
                        // Friendly creatures follow you
                        List<Monster> movers = currentContext.CurrentRoom.Creatures.FindAll(c => c.Disposition == DispositionType.Friendly && !c.NoFollow);
                        // If you are fleeing, there are Hostile creatures and they hunt you.
                        if (fleeing)
                        {
                            movers.AddRange(currentContext.CurrentRoom.Creatures.FindAll(c => c.Disposition == DispositionType.Angry && !c.NoFollow && c.CourageTest(rand)));
                        }
                        nextRoom.Creatures.AddRange(movers);
                        currentContext.CurrentRoom.Creatures.RemoveAll(o => movers.Contains(o));

                        currentContext.CurrentRoom = nextRoom;
                        if (checkLight())
                        {
                            DescribeRoom();
                        }
                        else
                        {
                            Logger.Write("It's too dark to see.");
                        }
                        currentContext.CurrentRoom.DoFirstVisitIfNeeded();
                        currentContext.CurrentRoom.DoEachVisit();
                    }
                }
                else
                {
                    Logger.WriteLn("You can't go that way.");
                    if (checkLight())
                    {
                        DescribeRoom();
                        AppendExitsToOutput();
                        PostAction();
                    }
                }
            }
            else
            {
                Logger.WriteLn("You dare not turn your back on your enemies!");
            }
        }

        private bool checkLight()
        {
            bool light = currentContext.CurrentRoom.Light;
            if (!light)
            {
                var lightSource = currentContext.CurrentRoom.Items.Find((i) => i.isLit);
                light = (lightSource != null);
            }
            if (!light)
            {
                var lightSource = player.Items.Find((i) => i.isLit);
                light = (lightSource != null);
            }
            return light;
        }

        private void ItemLookCommand(itemType item)
        {
            if (checkLight())
            {
                Logger.Write(string.Format("{0}", item.description));
                if (item.storage == null)
                {
                    Logger.WriteLn("");
                }
                else if (item.storage.isOpen && item.storage.Contents != null && item.storage.Contents.Length > 0)
                {
                    Logger.WriteLn("\nInside, you see:");
                    foreach (itemType i in item.storage.ContentsList)
                    {
                        Logger.WriteLn("\n  " + i.name);
                    }
                }
                else if (item.storage.isOpen)
                {
                    Logger.WriteLn("\nIt's empty.");
                }
                else
                {
                    Logger.WriteLn(" (closed)");
                }
            }
            else
            {
                Logger.Write("It's too dark to see.");
            }
        }

        private void RoomLookCommand()
        {
            if (checkLight())
            {
                Logger.WriteLn(currentContext.CurrentRoom.Description);
            }
            else
            {
                Logger.Write("It's too dark to see.");
            }
        }

        private void MonsterLookCommand(Monster monster)
        {
            if (checkLight())
            {
                Logger.WriteLn(monster.Description);
            }
            else
            {
                Logger.Write("It's too dark to see.");
            }
        }

        /// <summary>
        /// Tell player who else is in the room, formally introducing first-time encounters.
        /// They know the monsters are in the room, even when it is dark.
        /// Note that this will introduce any new monsters, even when it is dark.
        /// </summary>
        private void AppendCreaturesToOutput()
        {
            // Append creature descriptions for first encounters
            foreach (Monster monster in currentContext.CurrentRoom.Creatures.FindAll(c => !repeatEncounters.Contains(c.ID)))
            {
                if (monster.Intro != null)
                {
                    Logger.WriteLn(string.Format("\n{0}", monster.Intro));
                }
                else
                {
                    Logger.WriteLn(string.Format("\n{0}", monster.Description));
                }
            }

            // List previously encountered creatures that are still here
            foreach (Monster monster in currentContext.CurrentRoom.Creatures.FindAll(c => repeatEncounters.Contains(c.ID)))
            {
                Logger.WriteLn(string.Format("\n{0} is here.", monster.Name));
            }

            // Add first encounters to the repeat encounters list for future references
            foreach (Monster monster in currentContext.CurrentRoom.Creatures.FindAll(c => !repeatEncounters.Contains(c.ID)))
            {
                repeatEncounters.Add(monster.ID);
            }

        }

        /// <summary>
        /// Tell player what items they can see in the room.
        /// They can't see any if it is dark.
        /// </summary>
        private void AppendItemsToOutput()
        {
            if (checkLight())
            {
                foreach (itemType i in currentContext.CurrentRoom.Items)
                {
                    Logger.WriteLn("\nYou see " + i.name);
                }
            }
        }

        private void AppendExitsToOutput()
        {
            ExitRooms visibleExits = new ExitRooms(currentContext.CurrentRoom.Exits.Where(kvp => kvp.Value.Visible));
            if (visibleExits.Count == 0)
            {
                Logger.WriteLn("\nThere is no way out.");
            }
            else if (visibleExits.Count > 1)
            {
                Logger.WriteLn("\nYou see exits " + string.Join(", ", visibleExits.Keys) + ".");
            }
            else
            {
                directionType dir = visibleExits.First().Key;
                switch (dir)
                {
                    case directionType.d:
                        Logger.WriteLn("\nYou can see a way down.");
                        break;
                    case directionType.u:
                        Logger.WriteLn("\nYou can see a way up.");
                        break;
                    default:
                        Logger.WriteLn(string.Format("\nYou see an exit to the {0}.", dir));
                        break;
                }
            }
        }

        bool CompareNames(string valToFind, string name)
        {
            foreach (string n in name.Split(new char[] { ' ' }))
            {
                if (n.ToLower().StartsWith(valToFind.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Handle leaving the adventure.
        /// Remove temporary effects, etc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onReturnToMainHall(object sender, EventArgs e)
        {
            if (speedCountDown > 0)
            {
                player.Agility /= 2;
            }
            loader.EmptyLocker(player);
        }

        /// <summary>
        /// Subscribe handler for the returnToMainHall event
        /// </summary>
        /// <param name="handler"></param>
        public void SubscribeMainHallEvent(EventHandler handler)
        {
            BaseExit.returnToMainHall += handler;
        }

        /// <summary>
        /// Subscribe handler for the returnToMainHall event
        /// </summary>
        /// <param name="handler"></param>
        public void UnsubscribeMainHallEvent(EventHandler handler)
        {
            BaseExit.returnToMainHall -= handler;
        }

        /// <summary>
        /// Unsubscribe handler from the onKilled event
        /// </summary>
        /// <param name="handler"></param>
        public void SubscribeOnKilledEvent(EventHandler handler)
        {
            OnKilled += handler;
        }

        /// <summary>
        /// Unsubscribe handler from the onKilled event
        /// </summary>
        /// <param name="handler"></param>
        public void UnsubscribeOnKilledEvent(EventHandler handler)
        {
            OnKilled -= handler;
        }

    }

}
