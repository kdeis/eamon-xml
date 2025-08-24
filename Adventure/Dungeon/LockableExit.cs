using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    internal class LockableExit : BaseExit, Adventure.Dungeon.ILockable
    {
        lockableDoorType wrappedExit;
        event EventHandler onLock;
        event EventHandler onUnlock;

        public string KeyItemId
        {
            get
            {
                return wrappedExit.keyItemId;
            }
        }

        /// <remarks/>
        public string KeyItemAction
        {
            get
            {
                return wrappedExit.keyItemAction;
            }
        }

        public LockableExit(lockableDoorType door, Dictionary<string, IRoom> rooms)
            : base(door, rooms)
        {
            wrappedExit = door;
        }

        public override IRoom Go(IRoom currentRoom)
        {
            if (wrappedExit.locked)
            {
                Logger.WriteLn(wrappedExit.LockedDescription);
                return currentRoom;
            }
            else
            {
                Logger.WriteLn(wrappedExit.UnlockedDescription);
                return base.Go(currentRoom);
            }
        }

        public string ToggleLock()
        {
            if (wrappedExit.locked)
            {
                return Unlock();
            }
            else
            {
                return Lock();
            }
        }

        public string Lock()
        {
            wrappedExit.locked = true;
            onLock?.Invoke(this, EventArgs.Empty);
            return wrappedExit.LockPhrase;
        }

        public string Unlock()
        {
            wrappedExit.locked = false;
            onUnlock?.Invoke(this, EventArgs.Empty);
            return wrappedExit.UnlockPhrase;
        }

    }
}
