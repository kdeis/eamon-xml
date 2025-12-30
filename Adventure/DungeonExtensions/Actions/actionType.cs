using Adventure;
using Adventure.Dungeon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class actionType
{
    public virtual void Execute()
    {
        if (!string.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
        }
    }

    public virtual void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    { }
}
