using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    public class Room : IRoom
    {
        public string Name { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string ShortDescription { get; private set; }

        public ExitRooms Exits { get; set; }

        public bool FirstLook { get; set; }

        public bool FirstVisit { get; set; }

        public bool Light { get; set; }

        public event EventHandler OnFirstEnter;

        public event EventHandler OnEachEnter;

        public event EventHandler onExamine;

        public event EventHandler<StringEventArgs> onMagicWord;

        public event EventHandler onPower;

        public List<Monster> Creatures { get; set; }

        public List<itemType> Items { get; set; }
        public Room(string name, string title, string description, string shortDescription, bool light)
        {
            Name = name;
            Title = title;
            Description = description;
            ShortDescription = shortDescription;
            Light = light;
            FirstLook = true;
            FirstVisit = true;
        }

        public void DoFirstVisitIfNeeded()
        {
            if (FirstVisit)
            {
                OnFirstEnter?.Invoke(this, EventArgs.Empty);
                FirstVisit = false;
            }
        }

        public void DoEachVisit()
        {
            OnEachEnter?.Invoke(this, EventArgs.Empty);
        }

        public void DoExamine()
        {
            onExamine?.Invoke(this, EventArgs.Empty);
        }

        public void DoMagicWord(string word)
        {
            onMagicWord?.Invoke(this, new StringEventArgs(word));
        }

        public bool DoPower()
        {
            if (onPower != null)
            {
                onPower(this, EventArgs.Empty);
                return true;
            }
            return false;
        }

    }


}
