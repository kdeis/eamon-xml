using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    [Serializable]
    public class ExitRooms : Dictionary<directionType, BaseExit>
    {

        public ExitRooms(IEnumerable<KeyValuePair<directionType, BaseExit>> enumerable)
        {
            foreach (KeyValuePair<directionType, BaseExit> kvp in enumerable)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        public ExitRooms()
        { }

        public void HideExit(directionType direction)
        {
            this[direction].Visible = false;
        }

        public void RevealExit(directionType direction)
        {
            this[direction].Visible = true;
        }
    }
}
