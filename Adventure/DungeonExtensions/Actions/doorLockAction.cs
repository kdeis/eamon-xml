using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure;
using Adventure.Dungeon;

public partial class doorLockAction
{
    public doorLockAction()
    {
    }

    public doorLockAction(directionType exitDirection, String theText, String theRoomId, bool lockFlag)
    {
        direction = exitDirection;
        text = theText;
        roomId = theRoomId;
        lockIt = lockFlag;
    }

    public override void Execute()
    {
        ILockable door = (ILockable)(Context.Instance.GetRoom(roomId).Exits[direction]);
        Logger.WriteLn(text);
        if (lockIt)
        {
            _ = door.Lock();
        }
        else
        {
            _ = door.Unlock();
        }
    }
}
