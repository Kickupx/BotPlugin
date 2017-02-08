using System;
using System.Collections.Generic;
using System.Text;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents the base interface from which all other API objects can be retrieved from.
    /// All APIs are threadsafe unless other is specified.
    /// Many APIs are wrappers ontop of others. And in those cases there is an method named
    /// "Internal" when you want to have more control.
    /// </summary>
    public interface IAPI
    {
        /// <summary>
        /// An HTTP session manager. Read more about it <see cref="IHTTPClient"/>.
        /// </summary>
        /// <returns></returns>
        IHTTPClient HttpClient
        {
            get;
        }

        /// <summary>
        /// Some metadata about botkitty. Read more <see cref="IBotKitty"/>.
        /// </summary>
        /// <returns></returns>
        IBotKitty BotKitty
        {
            get;
        }

        /// <summary>
        /// The logger facility. Allows you to show logging messages to the user.
        /// </summary>
        /// <returns></returns>
        ILogger Logger
        {
            get;
        }

        /// <summary>
        /// Wraps the filesystem.
        /// Allowing you to make changes which will be reverted when the botrunner exits.
        /// </summary>
        /// <returns></returns>
        IFileSystem FileSystem
        {
            get;
        }
    }
}
