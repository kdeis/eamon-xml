using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class playerInRoomCondition
{
    public playerInRoomCondition()
    {
    }

    public playerInRoomCondition(String inRoomId)
    {
        roomId = inRoomId;
    }

    public override bool TestCondition()
    {
        return Context.Instance.CurrentRoom.Name == roomId;
    }
}
