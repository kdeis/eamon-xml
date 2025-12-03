using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Adventure
{
    public partial class TextInputForm : Form
    {
        // Maximum number of lines that fit in the text box, leaving room for the [MORE] prompt
        int maxLinesDisplayed;
        int width;
        bool continueWriting = false;
        Graphics g;

        public TextInputForm()
        {
            InitializeComponent();
            //DisplayText();
            Logger.ClearBuffer();
            mRtxtWhatYouSee.TextChanged += mRtxtWhatYouSee_TextChanged;
            //mLblRoom.Text = context.CurrentRoom.Title;
            g = this.CreateGraphics();
        }

        // Source - https://stackoverflow.com/a
        // Posted by Reza Aghaei, modified by community. See post 'Timeline' for change history
        // Retrieved 2025-11-08, License - CC BY-SA 3.0

        const int EM_GETRECT = 0xB2;
        public const string PRESS_ANY_KEY = "PRESS ANY KEY TO CONTINUE";

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref RECT lParam);

        private void MeasureWindow()
        {
            if (mRtxtWhatYouSee.Visible == false) return;

            // Source - https://stackoverflow.com/a
            // Posted by Reza Aghaei, modified by community. See post 'Timeline' for change history
            // Retrieved 2025-11-08, License - CC BY-SA 3.0

            var rect = new RECT();
            SendMessage(this.mRtxtWhatYouSee.Handle, EM_GETRECT, IntPtr.Zero, ref rect);
            maxLinesDisplayed = (rect.Bottom - rect.Top) / this.mRtxtWhatYouSee.Font.Height - 1;
            width = rect.Right - rect.Left;
            //var lastLine = mRtxtWhatYouSee.GetLineFromCharIndex(mRtxtWhatYouSee.Text.Length - 1);
            //mRtxtWhatYouSee.Text += $"Max Visible Lines={maxLinesDisplayed}; Last line number={lastLine}\n";
        }

        protected void DisplayText()
        {
            if (maxLinesDisplayed == 0)
            {
                MeasureWindow();
            }

            if (continueWriting)
            {
                mRtxtWhatYouSee.Text = mRtxtWhatYouSee.Text.Remove(mRtxtWhatYouSee.Text.Length - 7, 7); // remove [MORE]
            }

            StringBuilder output = Logger.GetOutputBuilder();
            if (mRtxtWhatYouSee.Visible)
            {
                var lineCount = 0;

                while (output.Length > 0)
                {
                    int lastSpaceIndex = -1;
                    String nextLine = "";
                    // Build the next line to fit within the width
                    for (int i = 0; i < output.Length; i++)
                    {
                        char c = output[i];
                        if(Char.IsWhiteSpace(c))
                        {
                            lastSpaceIndex = i;
                        }
                        nextLine += c;
                        SizeF size = g.MeasureString(nextLine, mRtxtWhatYouSee.Font);
                        if (size.Width > width)
                        {
                            int endOfLine = (lastSpaceIndex != -1) ? lastSpaceIndex + 1 : i;
                            nextLine = nextLine.Remove(endOfLine);
                            break;
                        }
                        else if (c == '\n')
                        {
                            break;
                        }
                    }
                    lineCount++;

                    if (lineCount < maxLinesDisplayed ||
                        (lineCount == maxLinesDisplayed && nextLine.Length == output.Length))
                    {
                        mRtxtWhatYouSee.Text += nextLine;
                        output.Remove(0, nextLine.Length);
                    }
                    else
                    {
                        // Ask user to press any key to continue
                        mRtxtWhatYouSee.Text += "\n[MORE]";
                        historyTextBox1.Text = PRESS_ANY_KEY;
                        break;
                    }
                }
                continueWriting = output.Length > 0;
            }
        }

        protected virtual
        void mBtnOk_Click(object sender, EventArgs e)
        {
            historyTextBox1.captureNode();

            DisplayText();
            //Logger.ClearBuffer();

            historyTextBox1.Text = "";

        }

        /// <summary>
        /// bind this method to the TextChanged event handler to auto-scroll to the bottom.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mRtxtWhatYouSee_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            mRtxtWhatYouSee.SelectionStart = mRtxtWhatYouSee.Text.Length;
            // scroll it automatically
            mRtxtWhatYouSee.ScrollToCaret();
        }

        /// <summary>
        /// Cleanup and close the form.
        /// Uses "new" to forcibly override Form.close(), but calls it internally.
        /// </summary>
        new public void Close()
        {
            base.Close();
        }

        private void mRtxtWhatYouSee_SizeChanged(object sender, EventArgs e)
        {
            // Don't measure until the window is visible.
            if (maxLinesDisplayed != 0)
            {
                MeasureWindow();
            }
        }

        private void historyTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (continueWriting)
            {
                e.Handled = true; // suppress the key
                DisplayText();
                if (!continueWriting)
                {
                    historyTextBox1.Text = "";
                }
            }
        }
    }
}
