using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class monsterInRoomCondition
{
    Monster Creature = null;
    public monsterInRoomCondition()
    {
    }

    public monsterInRoomCondition(Monster creature, String inRoomId)
    {
        Creature = creature;
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
    public override bool TestCondition()
    {
        return Context.Instance.GetRoom(roomId).Creatures.Contains(Creature);
    }
}
