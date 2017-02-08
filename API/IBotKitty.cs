using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    /// <summary>
    /// Some metadata about the botkitty program which is currently running.
    /// </summary>
    public interface IBotKitty
    {
        /// <summary>
        /// The version of BotKitty in the format in the main window title.
        /// Eg 0.5.0.0
        /// </summary>
        string Version
        {
            get;
        }

        /// <summary>
        /// The bitness under which BotKitty runs.
        /// This might be interesting if your other DLLs are of a certain bitness.
        /// </summary>
        Bitness Bitness
        {
            get;
        }

        /// <summary>
        /// The directory of which the current assembly is running in.
        /// Which is your plugin dll if you are not using any other.
        /// </summary>
        string CurrentAssemblyDir
        {
            get;
        }
    }
}
