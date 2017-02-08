using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    /// <summary>
    /// Represents a filesystem from which actions you do will be reverted
    /// when the botrunner ends.
    /// </summary>
    public interface IFileSystem : IDisposable
    {
        /// <summary>
        /// Create file if does not exist.
        /// Creates sub directories if needed.
        /// If it exists. Simply return that.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string CreateFile(string path);

        /// <summary>
        /// Create a directory.
        /// Creating subdirectories if needed.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string CreateDir(string path);

        /// <summary>
        /// Gets a file.
        /// Makes sure it exists.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetFile(string path);
    }
}
