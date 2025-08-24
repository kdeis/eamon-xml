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
    public healPlayerAction(String theText, int min, int max = 0)
    {
        text = theText;
        rangeLow = min;
        rangeHigh = max;
    }

    public override void Execute()
    {
        int heal = rangeLow;
        if (rangeHigh > 0)
        {
            Random r = new Random();
            heal += r.Next(rangeHigh - rangeLow + 1);
        }

        if (!String.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
            Logger.WriteLn();
        }
        Context.Instance.Player.Heal(heal);
    }
}
