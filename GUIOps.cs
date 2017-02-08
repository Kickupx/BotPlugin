using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPlugin
{
    public static class GUIOps
    {
        // To support flashing.
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;

        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            internal IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        public static bool FlashWindow(Form form)
        {
            DLLOps.FunExists("user32.dll", "FlashWindowEx");

            form.Invoke((MethodInvoker)delegate
            {
                IntPtr hWnd = form.Handle;
                FLASHWINFO fInfo = new FLASHWINFO();

                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = hWnd;
                fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
                fInfo.uCount = UInt32.MaxValue;
                fInfo.dwTimeout = 0;
            });

            return true;
        }

        public static void SetPropThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetPropThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }

        private delegate void SetControlPropertyThreadSafeDelegate(
                Control control,
                string propertyName,
                object propertyValue);
    }
}
