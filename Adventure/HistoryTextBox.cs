using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class HistoryTextBox : System.Windows.Forms.TextBox
    {
        protected LinkedList<String> InputHistory { get; set; }

        protected LinkedListNode<String> CurrentHistoryNode { get; set; }

        public HistoryTextBox()
        {
            CurrentHistoryNode = null;
            InputHistory = new LinkedList<string>();

            InitializeComponent();
        }

        /// <summary>
        /// Override IsInputKey to make the up/down arrows treated as normal input keys
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool IsInputKey(Keys keyData)
        {
            if ((keyData == Keys.Up) || (keyData == Keys.Down))
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        public void captureNode()
        {
            InputHistory.AddLast(Text);
            CurrentHistoryNode = null;
        }

        private void mTxtBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                if (CurrentHistoryNode == null)
                {
                    CurrentHistoryNode = InputHistory.Last;
                }
                else if (CurrentHistoryNode != InputHistory.First)
                {
                    CurrentHistoryNode = CurrentHistoryNode.Previous;
                }

                if (CurrentHistoryNode != null)
                {
                    Text = CurrentHistoryNode.Value;
                }
            }
            if (e.KeyData == Keys.Down)
            {
                if (CurrentHistoryNode != null)
                {
                    CurrentHistoryNode = CurrentHistoryNode.Next;
                }

                if (CurrentHistoryNode != null)
                {
                    Text = CurrentHistoryNode.Value;
                }
            }
        }
    }
}
