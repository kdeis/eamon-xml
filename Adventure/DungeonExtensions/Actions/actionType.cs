using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Dungeon;

public partial class actionType
{
    public abstract void Execute();

    public virtual void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    { }
}
