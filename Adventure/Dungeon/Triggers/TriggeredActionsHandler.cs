using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Dungeon.Triggers
{
    public class TriggeredActionsHandler
    {
        List<actionType> Actions = new List<actionType>();
        string Arg = "";

        public TriggeredActionsHandler() { }
        public TriggeredActionsHandler(string arg)
        {
            Arg = arg;
        }
        private void ExecuteActions()
        {
            if (Actions != null)
            {
                foreach (actionType a in Actions)
                {
                    a.Execute();
                }
            }
        }

        public void HandleEvent(object sender, EventArgs args)
        {
            ExecuteActions();
        }

        public void HandleStringArgsEvent(object sender, StringEventArgs args)
        {
            if (Arg == null || args.Arg.ToUpper().Contains(Arg.ToUpper()))
            {
                ExecuteActions();
            }
        }

        public void Add(actionType action)
        {
            Actions.Add(action);
        }
    }
}
