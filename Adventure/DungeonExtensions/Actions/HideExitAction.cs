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

    public hideExitAction(directionType exitDirection, string theText, string toRoomId)
    {
        text = text;
        direction = exitDirection;
        roomId = toRoomId;
    }

    public override void Execute()
    {
        base.Execute();
        IRoom room = Context.Instance.GetRoom(roomId);
        room.Exits.HideExit(direction);

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
