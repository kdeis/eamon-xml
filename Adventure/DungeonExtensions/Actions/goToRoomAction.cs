using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class goToRoomAction
{
    public goToRoomAction()
    {
    }
    public goToRoomAction(String theText, String theRoom)
    {
        text = theText;
        roomId = theRoom;
    }

    public override void Execute()
    {
        if (!String.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
            Logger.WriteLn();
        }
        Context.Instance.CurrentRoom = Context.Instance.GetRoom(roomId);
    }
}
