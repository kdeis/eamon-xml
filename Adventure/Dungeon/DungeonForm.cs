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
            mCommandEngine.SubscribeOnKilledEvent(mCommandEngine_OnKilled);
            mCommandEngine.SubscribeMainHallEvent(mCommandEngine_OnReturnToMainHall);
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
            }
            return DialogResult;
        }

        protected override
        void mBtnOk_Click(object sender, EventArgs e)
        {
            if (!historyTextBox1.Text.StartsWith(PRESS_ANY_KEY))
            {
                historyTextBox1.captureNode();

                //mRtxtWhatYouSee.Text = "";

                mCommandEngine.ParseCommand(historyTextBox1.Text);

                mLblRoom.Text = context.CurrentRoom.Title;
            }

            historyTextBox1.Text = "";

            DisplayText();
        }

        /// <summary>
        /// Handle hero death; query player to retry or let him rot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mCommandEngine_OnKilled(object sender, EventArgs e)
        {
            DisplayText();
            Logger.ClearBuffer();

            DialogResult = MessageBox.Show("You have died. Would you like to try again, or leave your corpse to be looted and defiled by the foul denizens of this wretched place?",
                "You are dead", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            Close();
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
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Cleanup and close the form.
        /// Uses "new" to forcibly override Form.close(), but calls it internally.
        /// </summary>
        new public void Close()
        {
            mCommandEngine.UnsubscribeOnKilledEvent(mCommandEngine_OnKilled);
            mCommandEngine.UnsubscribeMainHallEvent(mCommandEngine_OnReturnToMainHall);
            base.Close();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // mRtxtWhatYouSee
            // 
            mRtxtWhatYouSee.Location = new System.Drawing.Point(57, 76);
            mRtxtWhatYouSee.Size = new System.Drawing.Size(1262, 416);
            // 
            // mLblCommand
            // 
            mLblCommand.Location = new System.Drawing.Point(53, 524);
            // 
            // mLblRoom
            // 
            mLblRoom.Size = new System.Drawing.Size(1262, 28);
            // 
            // historyTextBox1
            // 
            historyTextBox1.Location = new System.Drawing.Point(129, 520);
            historyTextBox1.Size = new System.Drawing.Size(1190, 26);
            // 
            // mBtnOk
            // 
            mBtnOk.Location = new System.Drawing.Point(1680, 545);
            // 
            // DungeonForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            ClientSize = new System.Drawing.Size(1374, 559);
            Name = "DungeonForm";
            ResumeLayout(false);
            PerformLayout();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            mLblRoom.Text = context.CurrentRoom.Title;
            DisplayText();
        }
    }
}
