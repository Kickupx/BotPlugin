using System.Collections.Generic;

namespace BotPlugin.API
{
    /// <summary>
    /// The bitnesses which is supported on desktop platforms.
    /// </summary>
    public enum Bitness
    {
        X32,
        X64,
        Both
    }

    /// <summary>
    /// Represesents all processes on the system.
    /// </summary>
    public interface IProcesses
    {
        /// <summary>
        /// Retrieves the bot process.
        /// </summary>
        IProcess CurrentProcess
        {
            get;
        }

        /// <summary>
        /// Constructs a process from a process id.
        /// </summary>
        /// <exception cref="Exception">If pid does not exist.</exception>
        /// <param name="pid"></param>
        /// <returns></returns>
        IProcess ByPid(int pid);

        /// <summary>
        /// Returns the processes which matches the name exactly.
        /// You can also specify what bitness the application is running as.
        /// As X86 or X64.
        /// </summary>
        /// <remarks>
        /// If bot is running as 32bit then it can not handle 64bit processes.
        /// Therefore if you call it with Bitness.X64 it will throw. Because
        /// no process can ever be found.
        /// </remarks>
        /// <exception cref="Exception">If bitness is one which BotKitty can not handle.</exception>
        /// <param name="name"></param>
        /// <param name="bitness"></param>
        /// <returns></returns>
        IList<IProcess> ByName(string name, Bitness bitness = Bitness.Both);

        /// <summary>
        /// Returns the processes which matches the name exactly.
        /// You can also specify what bitness the application is running as.
        /// As X86 or X64.
        /// </summary>
        /// <remarks>
        /// If bot is running as 32bit then it can not handle 64bit processes.
        /// Therefore if you call it with Bitness.X64 it will throw. Because
        /// no process can ever be found.
        /// </remarks>
        /// <exception cref="Exception">If bitness is one which BotKitty can not handle.</exception>
        /// <param name="names">Array implements IEnumerable so you can pass an array</param>
        /// <param name="bitness"></param>
        /// <returns></returns>
        IList<IProcess> ByNames(IEnumerable<string> names, Bitness bitness = Bitness.Both);

        /// <summary>
        /// Figures out the process owning a window <see cref="IProcess"/> from an <see cref="IWindow"/>.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        IProcess ByWindow(IWindow window);

        /// <summary>
        /// Constructs an <see cref="IProcess"/> instance from an <see cref="System.Diagnostics.Process"/>
        /// instance.
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        IProcess FromDotNetProcess(System.Diagnostics.Process process);

        IList<IProcess> All
        {
            get;
        }
    }
}