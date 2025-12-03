using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class setConstantAction
{
    public setConstantAction()
    {
    }

    public setConstantAction(string theText, string theName, string theValue)
    {
        text = theText;
        name = theName;
        value = theValue;
    }

    public override void Execute()
    {
        if (!string.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
            Logger.WriteLn();
        }
        if (Context.Instance.Constants.ContainsKey(name))
        {
            Context.Instance.Constants[name] = value;
        }
        else
        {
            Context.Instance.Constants.Add(name, value);
        }
    }
}
