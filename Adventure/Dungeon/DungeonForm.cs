using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure.Dungeon
{
    public partial class DungeonForm : TextInputForm
    {

        Context context;

        CommandEngine mCommandEngine { get; set; }

        public DungeonForm() : base()
        {
            context = Context.Instance;
            mCommandEngine = new CommandEngine();
            mCommandEngine.SubscribeOnKilledEvent(this.mCommandEngine_OnKilled);
            mCommandEngine.SubscribeMainHallEvent(this.mCommandEngine_OnReturnToMainHall);
        }
        public DialogResult Initialize(Character character)
        {
            if (!mCommandEngine.Initialize(character))
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            else
            {
                DialogResult = DialogResult.OK;
                mLblRoom.Text = context.CurrentRoom.Title;
                mRtxtWhatYouSee.Text = Logger.GetBuffer();
                Logger.ClearBuffer();
            }
            return DialogResult;
        }

        protected override
        void mBtnOk_Click(object sender, EventArgs e)
        {
            historyTextBox1.captureNode();

            mRtxtWhatYouSee.Text = "";

            mCommandEngine.ParseCommand(historyTextBox1.Text);

            mLblRoom.Text = context.CurrentRoom.Title;

            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();

            historyTextBox1.Text = "";
        }

        /// <summary>
        /// Handle hero death; query player to retry or let him rot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCommandEngine_OnKilled(object sender, EventArgs e)
        {
            mRtxtWhatYouSee.Text = Logger.GetBuffer();
            Logger.ClearBuffer();

            this.DialogResult = MessageBox.Show("You have died. Would you like to try again, or leave your corpse to be looted and defiled by the foul denizens of this wretched place?",
                "You are dead", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            this.Close();
        }

        /// <summary>
        /// Handle hero's triumphant return to the main hall!
        /// - show happy message and close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCommandEngine_OnReturnToMainHall(object sender, EventArgs e)
        {
            MessageBox.Show("You successfully ride off into the sunset.", "Congratulations!");
            this.DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cleanup and close the form.
        /// Uses "new" to forcibly override Form.close(), but calls it internally.
        /// </summary>
        new public void Close()
        {
            mCommandEngine.UnsubscribeOnKilledEvent(this.mCommandEngine_OnKilled);
            mCommandEngine.UnsubscribeMainHallEvent(this.mCommandEngine_OnReturnToMainHall);
            base.Close();
        }
    }
}
