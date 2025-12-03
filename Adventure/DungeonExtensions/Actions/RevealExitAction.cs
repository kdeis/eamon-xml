using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class revealExitAction
{
    public revealExitAction()
    {
    }

    public revealExitAction(directionType exitDirection, string theText, string toRoomId)
    {
        direction = exitDirection;
        text = theText;
        roomId = toRoomId;
    }

    public override void Execute()
    {
        Logger.WriteLn(text);
        Context.Instance.GetRoom(roomId).Exits.RevealExit(direction);
    }
}
