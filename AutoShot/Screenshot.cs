using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Serilog;

namespace AutoShot
{
    class Screenshot
    {
        private static Bitmap CaptureCursor(ref int x, ref int y)
        {
            Bitmap bmp;
            IntPtr hIcon;
            var ci = new Native.CURSORINFO();
            Native.ICONINFO iconInfo;
            ci.cbSize = Marshal.SizeOf(ci);
            if (Native.GetCursorInfo(out ci)) {
                if (ci.flags == Native.CURSOR_SHOWING) {
                    hIcon = Native.CopyIcon(ci.hCursor);
                    if (Native.GetIconInfo(hIcon, out iconInfo)) {
                        x = ci.ptScreenPos.x - iconInfo.xHotspot;
                        y = ci.ptScreenPos.y - iconInfo.yHotspot;
                        Icon ic = Icon.FromHandle(hIcon);
                        bmp = ic.ToBitmap();
                        return bmp;
                    }
                }
            }
            return null;
        }

        private static void AddCursor(IntPtr hwnd, Graphics g, int xCropOffset)
        {
            // screen coordinates
            int cursorX = 0;
            int cursorY = 0;
            Bitmap cursorBmp = CaptureCursor(ref cursorX, ref cursorY);

            // client coordinates
            var cursorPoint = new Native.POINT();
            cursorPoint.x = cursorX;
            cursorPoint.y = cursorY;
            // magic #: 1, since we're giving it a single point
            var err = Native.MapWindowPoints(Native.GetDesktopWindow(), hwnd, ref cursorPoint, 1);
            if (err == 0) {
                if (Marshal.GetLastWin32Error() != 0) {
                    Log.Debug("Cursor map failed");
                    return; // cursor is probably off window
                }
            }

            // screen coordinates
            var winRect = new Native.RECT();
            Native.GetWindowRect(hwnd, out winRect);

            var windowOrigin = new Native.POINT { x = 0, y = 0 };
            Native.ClientToScreen(hwnd, ref windowOrigin);

            var offsetX = windowOrigin.x - winRect.Left - xCropOffset;
            var offsetY = windowOrigin.y - winRect.Top;

            var cursorRect = new Rectangle(cursorPoint.x + offsetX, cursorPoint.y + offsetY, cursorBmp.Width, cursorBmp.Height);
            g.DrawImage(cursorBmp, cursorRect);
        }

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
                    AddCursor(hwnd, g, (int)wininfo.cxWindowBorders);
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