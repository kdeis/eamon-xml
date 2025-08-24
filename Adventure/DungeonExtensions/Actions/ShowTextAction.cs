using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;

public partial class showTextAction
{
    public showTextAction()
    {
    }

    public showTextAction(String theText)
    {
        text = text;
    }

    public override void Execute()
    {
        Logger.WriteLn(text);
    }
}
