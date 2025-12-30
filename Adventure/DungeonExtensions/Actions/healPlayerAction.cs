using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class healPlayerAction
{
    public healPlayerAction()
    {
    }
    public healPlayerAction(string theText, int min, int max = 0)
    {
        text = theText;
        rangeLow = min;
        rangeHigh = max;
    }

    public override void Execute()
    {
        base.Execute();
        int heal = rangeLow;
        if (rangeHigh > 0)
        {
            Random r = new Random();
            heal += r.Next(rangeHigh - rangeLow + 1);
        }
        Context.Instance.Player.Heal(heal);
    }
}
