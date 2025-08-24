using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class hideExitAction
{
    public hideExitAction()
    {
    }

    public hideExitAction(directionType exitDirection, String theText, String toRoomId)
    {
        text = text;
        direction = exitDirection;
        roomId = toRoomId;
    }

    public override void Execute()
    {
        Logger.WriteLn(text);
        Context.Instance.GetRoom(roomId).Exits.HideExit(direction);
    }
}
