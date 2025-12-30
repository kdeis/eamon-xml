using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class setTimerAction
{
    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
        foreach (actionType a in action)
        {
            a.Initialize(dungeonData, MonsterList);
        }
    }

    public override void Execute()
    {
        base.Execute();
        if (!TurnTimer.Timers.ContainsKey(name))
        {
            TurnTimer newTimer = new TurnTimer(name, duration, repeat);
            newTimer.Actions = action.ToList();
            TurnTimer.Timers.Add(name, newTimer);
        }
    }
}
