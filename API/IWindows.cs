using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    /// <summary>
    /// Query alive windows here.
    /// </summary>
    public interface IWindows
    {
        /// <summary>
        /// The windows by name.
        /// Including hidden ones.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IList<IWindow> ByName(string name);

        /// <summary>
        /// Get windows by name.
        /// Including hidden ones.
        /// There will not be any duplicates in the result.
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        IList<IWindow> ByNames(IEnumerable<string> names);

        IWindow ForegroundWindow
        {
            get;
        }
    }
}
