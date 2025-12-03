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
        string StringArg = "";
        int? IntArg;

        public TriggeredActionsHandler() { }
        public TriggeredActionsHandler(string arg)
        {
            StringArg = arg;
        }
        public TriggeredActionsHandler(int arg)
        {
            IntArg = arg;
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
            if (string.IsNullOrEmpty(StringArg) || args.Arg.ToUpper().Contains(StringArg.ToUpper()))
            {
                ExecuteActions();
            }
        }

        public void HandleIntegerArgsEvent(object sender, IntegerEventArgs args)
        {
            if (IntArg == null || args.Arg == IntArg)
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
