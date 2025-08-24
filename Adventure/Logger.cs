﻿using System;
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

        public static void WriteLn(String text = "")
        {
            output.AppendLine(text);
        }

        public static void Write(String text)
        {
            output.Append(text);
        }

        public static String GetBuffer()
        {
            return output.ToString();
        }

        public static void ClearBuffer()
        {
            output.Clear();
        }
    }
}
