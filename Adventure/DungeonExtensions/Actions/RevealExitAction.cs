using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;
using Helpers;

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
        base.Execute();
        IRoom room = Context.Instance.GetRoom(roomId);
        room.Exits.RevealExit(direction);

        if (description != null && description.Length > 0)
        {
            room.Description = description;
        }
        if (shortDescription != null && shortDescription.Length > 0)
        {
            room.ShortDescription = shortDescription;
        }
    }
}
