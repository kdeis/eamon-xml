using System;

namespace Adventure
{
    public class StringEventArgs : EventArgs
    {
        public string Arg { get; set; }
        public StringEventArgs(string arg)
        {
            Arg = arg;
        }
    }
}

