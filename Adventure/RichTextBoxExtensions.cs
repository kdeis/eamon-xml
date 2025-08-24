using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public static class RichTextBoxExtensions
    {
        /// <summary>
        /// Append text of the given color
        /// 
        ///Use The following code snippet to see all the named colors:
        ///     foreach (MemberInfo m in typeof(Color).GetMembers())
        ///     {
        ///         if (m.ReflectedType == typeof(Color))
        ///         {
        ///             String name = m.Name;
        ///             if (!name.StartsWith("get_"))
        ///             {
        ///                 Color c = Color.FromName(name);
        ///                 mRtbGreeting.AppendText(m.Name, c);
        ///             }
        ///         }
        ///     }
        ///
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        public static void AppendText(this RichTextBox box, string text, Color color, HorizontalAlignment alignment = HorizontalAlignment.Left)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionAlignment = alignment;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
