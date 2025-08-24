using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class notCondition
{
    public notCondition()
    {
    }

    public notCondition(conditionType condition)
    {
        this.condition = condition;
    }

    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        // If this instance was deserialized, we need to get the Creature object from the deserialized id.
        condition.Initialize(dungeonData, MonsterList);
    }
    public override bool TestCondition()
    {
        return !condition.TestCondition();
    }
}
