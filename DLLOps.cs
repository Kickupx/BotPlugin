using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin
{
    [Serializable]
    public class DllMismatchException : Exception
    {
        public DllMismatchException(string dll, string fun)
            : base("Internal DLL mismatch. There are no DLL function named " + fun + " in dll " + dll)
        {
            this.Dll = dll;
            this.function = fun;
        }

        public string Dll
        {
            get;
        }

        public string function
        {
            get;
        }
    }

    public static class DLLOps
    {
        [DllImport("kernel32", SetLastError = true)]
        static extern UIntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32")]
        internal static extern UIntPtr GetProcAddress(UIntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        public static void FunExists(string dll, string name)
        {
            var lib = LoadLibrary(dll);
            if (lib == UIntPtr.Zero
                || GetProcAddress(lib, name) == UIntPtr.Zero)
                throw new DllMismatchException(dll, name);
        }
    }
}
