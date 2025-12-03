using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    public class Context
    {
        public const string CURRENT_ROOM_ID = "Current";

        private static Context instance;

        public string CharFile { get; set; }

        public string DungeonFile { get; set; }

        public Character Player { get; set; }

        public IRoom CurrentRoom { get; set; }

        public Dictionary<string, IRoom> rooms { get; set; }

        public Dictionary<string, string> Constants { get; set; }

        private Context()
        {
            Constants = new Dictionary<string, string>();
        }

        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Context();
                }
                return instance;
            }
        }

        public IRoom GetRoom(string name)
        {
            if (name == CURRENT_ROOM_ID)
            {
                return CurrentRoom;
            }
            else
            {
                return rooms[name];
            }
        }
    }
}
