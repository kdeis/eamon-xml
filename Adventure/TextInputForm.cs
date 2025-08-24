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
    public partial class TextInputForm : Form
    {

        public TextInputForm()
        {
            InitializeComponent();

            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();
            mRtxtWhatYouSee.TextChanged += mRtxtWhatYouSee_TextChanged;
            //mLblRoom.Text = context.CurrentRoom.Title;
        }

        protected virtual
        void mBtnOk_Click(object sender, EventArgs e)
        {
            historyTextBox1.captureNode();

            mRtxtWhatYouSee.Text = "";

            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();

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
    }
}
