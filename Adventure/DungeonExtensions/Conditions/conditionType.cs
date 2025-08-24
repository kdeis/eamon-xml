using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Dungeon;

public partial class conditionType
{
    public abstract Boolean TestCondition();

    public virtual void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    { }

}
