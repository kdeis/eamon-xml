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
        base.Execute();
        Context.Instance.CurrentRoom = Context.Instance.GetRoom(roomId);

        if (description != null && description.Length > 0)
        {
            Context.Instance.CurrentRoom.Description = description;
        }
        if (shortDescription != null && shortDescription.Length > 0)
        {
            Context.Instance.CurrentRoom.ShortDescription = shortDescription;
        }
    }
}
