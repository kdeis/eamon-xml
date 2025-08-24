using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class permaBoostPlayerStatAction
{
    public permaBoostPlayerStatAction()
    {
    }

    public permaBoostPlayerStatAction(String theText, String statToBoost, int addValue)
    {
        text = theText;
        stat = statToBoost;
        value = addValue;
    }

    public override void Execute()
    {
        switch (stat)
        {
            case "Agility":
                Context.Instance.Player.Agility += value;
                break;
            case "Charisma":
                Context.Instance.Player.Charisma += value;
                break;
            case "Hardiness":
                Context.Instance.Player.Hardiness += value;
                break;
            default:
                break;
        }
        Logger.WriteLn(text);
    }
}
