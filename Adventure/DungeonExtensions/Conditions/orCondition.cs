using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class orCondition
{
    public orCondition()
    {
    }

    public orCondition(List<conditionType> conditions)
    {
        this.condition = conditions.ToArray();
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Creature object from the deserialized id.
        foreach (conditionType c in condition)
        {
            c.Initialize(dungeonData, MonsterList);
        }
    }
    public override bool TestCondition()
    {
        foreach (conditionType c in condition)
        {
            if (c.TestCondition())
            {
                return true;
            }
        }
        return false;

    }
}
