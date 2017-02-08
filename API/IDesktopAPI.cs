using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents the API which is available on the Windows desktop
    /// </summary>
    public interface IDesktopAPI : IAPI
    {
        /// <summary>
        /// Use this object to query processes by name and window.
        /// </summary>
        IProcesses Processes
        {
            get;
        }

        /// <summary>
        /// The object on which window queries can be made.
        /// </summary>
        IWindows Windows
        {
            get;
        }
    }
}
