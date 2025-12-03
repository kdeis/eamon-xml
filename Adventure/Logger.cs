using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public static class Logger
    {
        static StringBuilder output;

        static Logger()
        {
            output = new StringBuilder();
        }

        public static void WriteLn(string text = "")
        {
            output.AppendLine(text);
        }

        public static void Write(string text)
        {
            output.Append(text);
        }

        public static string GetBuffer()
        {
            return output.ToString();
        }

        public static void ClearBuffer()
        {
            output.Clear();
        }

        public static StringBuilder GetOutputBuilder()
        {
            return output;
        }

        public static string GetNextChar()
        {
            if (output.Length == 0)
            {
                return null;
            }
            char nextChar = output[0];
            output.Remove(0, 1);
            return nextChar.ToString();
        }
    }
}
