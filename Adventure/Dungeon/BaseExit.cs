using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    public class BaseExit
    {
        public static event EventHandler returnToMainHall;

        private IRoom Room;

        public bool ToMainHall;

        public bool Visible;

        public BaseExit(doorType door, Dictionary<string, IRoom> rooms)
        {
            Room = rooms[door.roomName];
            ToMainHall = door.toMainHall;
            Visible = door.visible;
        }

        public virtual IRoom Go(IRoom currentRoom)
        {
            if (ToMainHall)
            {
                returnToMainHall?.Invoke(this, EventArgs.Empty);
            }
            return Room;
        }
    }
}
