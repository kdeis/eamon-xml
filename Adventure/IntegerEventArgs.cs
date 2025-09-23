using System;

namespace Adventure
{
    public class IntegerEventArgs : EventArgs
    {
        public int Arg { get; set; }
        public IntegerEventArgs(int arg)
        {
            Arg = arg;
        }
    }
}

