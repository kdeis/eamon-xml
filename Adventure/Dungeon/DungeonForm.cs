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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // mRtxtWhatYouSee
            // 
            this.mRtxtWhatYouSee.Size = new System.Drawing.Size(1305, 446);
            // 
            // mLblCommand
            // 
            this.mLblCommand.Location = new System.Drawing.Point(53, 552);
            // 
            // mLblRoom
            // 
            this.mLblRoom.Size = new System.Drawing.Size(1305, 28);
            // 
            // historyTextBox1
            // 
            this.historyTextBox1.Location = new System.Drawing.Point(129, 548);
            this.historyTextBox1.Size = new System.Drawing.Size(1592, 26);
            // 
            // mBtnOk
            // 
            this.mBtnOk.Location = new System.Drawing.Point(1730, 545);
            // 
            // DungeonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(1424, 559);
            this.Name = "DungeonForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            mLblRoom.Text = context.CurrentRoom.Title;
            DisplayText();
        }
    }
}
