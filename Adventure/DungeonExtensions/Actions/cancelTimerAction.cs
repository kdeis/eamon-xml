using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class cancelTimerAction
{
    public override void Initialize(DungeonData dungeonData, Dictionary<int, Monster> MonsterList)
    {
    }

    public override void Execute()
    {
        base.Execute();

        TurnTimer cancelledTimer;
        if (TurnTimer.Timers.TryGetValue(name, out cancelledTimer))
        {
            TurnTimer.Timers.Remove(name);
            cancelledTimer.Pause();
        }
    }
}
