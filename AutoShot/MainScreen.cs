using System;
using System.Windows.Forms;

namespace AutoShot
{
    public partial class MainScreen : Form
    {
        private Hooks hooks;
        private bool capturing = false;

        public MainScreen()
        {
            InitializeComponent();
            Log("Initialized");

            this.hooks = new Hooks();
            this.hooks.Log = this.Log;

            this.FormClosing += this.CloseForm;

            //this.textBoxPath.Text = Settings.Instance.SaveDirectory;
            this.textBoxPath.DataBindings.Add(new Binding("Text", Settings.Instance, "SaveDirectory"));
            this.checkBoxIncludeCursor.DataBindings.Add(new Binding("Checked", Settings.Instance, "IncludeCursor"));
        }
        
        private void CloseForm(object sender, EventArgs e)
        {
            // semi horrible hack to ensure that path is saved if user forgets to deselect the box
            this.ActiveControl = null;

            Settings.Instance.Save();
            this.hooks.Unsubscribe();
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (this.capturing) {
                this.hooks.Unsubscribe();
                this.buttonStartStop.Text = "Start";
                Log("Unsubscribed");
            } else {
                this.hooks.Subscribe();
                this.buttonStartStop.Text = "Stop";
                Log("Subscribed");
            }
            this.capturing = !this.capturing;
        }

        private void textBoxPath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                // deselect textbox on enter press
                this.ActiveControl = null;
                e.Handled = true;
            }
        }

        private void buttonResetPath_Click(object sender, EventArgs e)
        {
            Settings.Instance.SaveDirectory = null;
        }

        private void Log(string line)
        {
            if (this.IsDisposed) {
                return;
            }
            this.textBoxLog.AppendText(line + "\n");
            this.textBoxLog.ScrollToCaret();
        }
    }
}
