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
    public goToRoomAction(string theText, string theRoom)
    {
        text = theText;
        roomId = theRoom;
    }

    public override void Execute()
    {
        if (!string.IsNullOrEmpty(text))
        {
            Logger.WriteLn(text);
            Logger.WriteLn();
        }
        Context.Instance.CurrentRoom = Context.Instance.GetRoom(roomId);
    }
}
