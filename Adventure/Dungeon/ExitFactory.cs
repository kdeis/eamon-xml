using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    internal class ExitFactory
    {
        public static BaseExit GetExit(doorType door, Dictionary<string, IRoom> rooms)
        {
            lockableDoorType lockedDoor = door as lockableDoorType;
            if (lockedDoor != null)
            {
                return new LockableExit(lockedDoor, rooms);
            }

            return new BaseExit(door, rooms);
        }
    }
}
