using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon
{
    public class TurnTimer
    {
        public static Dictionary<String, TurnTimer> Timers = new Dictionary<String, TurnTimer>();
        public String Name { get; set; }
        public int Duration { get; set; }
        public int Current { get; set; }
        private bool Paused { get; set; }
        private List<actionType> mActions = new List<actionType>();

        public List<actionType> Actions { get; set; }
        bool repeat = false;
        public TurnTimer(String name, int duration, bool repeat = false)
        {
            Name = name;
            Duration = duration;
            Current = Duration;
            this.repeat = repeat;
        }
        public bool Tick()
        {
            bool remove = false;
            if (Current > 0 && !Paused)
            {
                Current--;
                if (Current == 0)
                {
                    foreach (actionType a in Actions)
                    {
                        a.Execute();
                    }
                    if (repeat)
                    {
                        Current = Duration;
                    }
                    else
                    {
                        remove = true;
                    }
                }
            }
            return remove;
        }
        public void Pause()
        {
            Paused = true;
        }
        public void Resume()
        {
            Paused = false;
        }
    }

}
