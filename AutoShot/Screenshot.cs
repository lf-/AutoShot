using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace AutoShot
{
    class Screenshot
    {
        public static Bitmap Capture()
        {
            var hwnd = Native.GetForegroundWindow();
            var wininfo = new Native.WINDOWINFO();
            Native.GetWindowInfo(hwnd, ref wininfo);
            var rect = wininfo.rcWindow;
            rect.Left += (int)wininfo.cxWindowBorders;
            rect.Right -= (int)wininfo.cxWindowBorders;
            rect.Bottom -= (int)wininfo.cyWindowBorders;

            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            var res = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(res)) {
                g.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);

                if (Settings.Instance.IncludeCursor) {
                    // Go into a panic because Windows makes this crazy ridiculous
                }
            }
            return res;
        }

        public static void CaptureTo(string filename)
        {
            var bmp = Capture();
            bmp.Save(filename, ImageFormat.Png);
        }
    }
}