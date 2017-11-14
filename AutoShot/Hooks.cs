using Gma.System.MouseKeyHook;
using System;
using System.IO;

namespace AutoShot
{
    class Hooks
    {
        private IKeyboardMouseEvents GlobalHook;

        public delegate void LogType(string line);
        public LogType Log;

        public Hooks()
        {
            this.Log = x => { };
        }

        public void Subscribe()
        {
            this.GlobalHook = Hook.GlobalEvents();
            this.GlobalHook.MouseDownExt += this.GlobalHookMouseDownExt;
        }

        public void Unsubscribe()
        {
            if (this.GlobalHook != null) {
                this.GlobalHook.MouseDownExt -= this.GlobalHookMouseDownExt;
                this.GlobalHook.Dispose();
            }
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            // XXX: race condition may cause crashes due to user attempting to break program
            var dir = Settings.Instance.EnsureSaveDirectory();
            var savePath = Path.Combine(dir, e.Timestamp + ".png");
            this.Log("Saved " + savePath);
            Screenshot.CaptureTo(savePath);
        }
    }
}
