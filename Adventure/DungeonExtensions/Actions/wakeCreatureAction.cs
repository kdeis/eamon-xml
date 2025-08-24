using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class wakeCreatureAction
{
    Monster Creature = null;
    public wakeCreatureAction()
    {
    }

    public wakeCreatureAction(Monster creature, String theText, String inRoomId)
    {
        Creature = creature;
        text = theText;
        roomId = inRoomId;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Creature object from the deserialized id.
        if (Creature == null)
        {
            Creature = MonsterList[monsterId];
        }
    }
    public override void Execute()
    {
        Logger.WriteLn(text);
        Context.Instance.GetRoom(roomId).Creatures.Add(Creature);
    }
}
