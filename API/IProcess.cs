
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace BotPlugin.API
{
    public enum Unicode
    {
        UTF8,
        UTF16,
        UTF32
    }

    /// <summary>
    /// Represents a class. On which you can do any manipulation of it's memory, hooking etc.
    /// </summary>
    public abstract class IProcess : IDisposable
    {
        /// <summary>
        /// The file path to the executable which this process is running.
        /// </summary>
        public abstract string ExePath
        {
            get;
        }

        /// <summary>
        /// The directory path to the directory in which the executable resides.
        /// </summary>
        public abstract string ExeDir
        {
            get;
        }

        /// <summary>
        /// The bitness which the process runs in. As 32 bit (x86) or 64 bit (x64).
        /// </summary>
        /// <exception cref="Exception">If process is no longer running or is not running on a Windows desktop.</exception>
        public abstract Bitness Bitness
        {
            get;
        }

        /// <summary>
        /// The main module (dll/exe) of the process
        /// </summary>
        /// <exception cref="Exception">If process is not longer running.</exception>
        public abstract ProcessModule MainModule
        {
            get;
        }

        /// <summary>
        /// All modules of the process.
        /// </summary>
        public abstract ProcessModuleCollection Modules
        {
            get;
        }

        /// <summary>
        /// Get module by name.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="Exception">If module does not exist or if process is no longer running.</exception>
        /// <returns></returns>
        public abstract ProcessModule ModuleByName(string name);

        /// <summary>
        /// Gets the process identifier used by the OS of the process.
        /// </summary>
        public abstract int Pid
        {
            get;
        }

        /// <summary>
        /// Gets the internal handle which is used with OS calls.
        /// </summary>
        public abstract IntPtr Internal
        {
            get;
        }

        /// <summary>
        /// The exit code if the process has terminated.
        /// </summary>
        /// <exception cref="Exception">If process is running.</exception>
        public abstract int ExitCode
        {
            get;
        }

        /// <summary>
        /// The time when the process exited if it has terminated.
        /// </summary>
        /// <exception cref="Exception">If process is running.</exception>
        public abstract DateTime ExitTime
        {
            get;
        }

        /// <summary>
        /// Alias for <see cref="Internal"/>.
        /// </summary>
        public abstract IntPtr Handle
        {
            get;
        }

        /// <summary>
        /// Alias for <see cref="Pid"/>.
        /// </summary>
        public abstract int Id
        {
            get;
        }

        /// <summary>
        /// The main window of the application.
        /// </summary>
        /// <exception cref="Exception">If process has not main window.</exception>
        public abstract IWindow MainWindow
        {
            get;
        }

        /// <summary>
        /// Get windows with a certain caption.
        /// </summary>
        /// <param name="caption">The substring which the caption has to contain.</param>
        /// <returns></returns>
        public abstract IList<IWindow> WindowsWithCaption(string caption);

        /// <summary>
        /// The maximum working set for the application.
        /// Allows you to set it or just get it.
        /// </summary>
        public abstract IntPtr MaxWorkingSet
        {
            get;
            set;
        }

        /// <summary>
        /// The minimum working set for the application.
        /// Allows you to set it or just get it.
        /// </summary>
        public abstract IntPtr MinWorkingSet
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the process as is shown by resource manager.
        /// </summary>
        public abstract string ProcessName
        {
            get;
        }

        /// <summary>
        /// The standard output stream which sends errors to the console by default.
        /// </summary>
        public abstract StreamReader StandardError
        {
            get;
        }

        /// <summary>
        /// The standard output stream which sends normal messages to the console by default.
        /// </summary>
        public abstract StreamWriter StandardInput
        {
            get;
        }

        /// <summary>
        /// Used to read all normal output of the program.
        /// </summary>
        public abstract StreamReader StandardOutput
        {
            get;
        }

        /// <summary>
        /// Kills the application.
        /// If it is already killed then nothing will happen.
        /// </summary>
        /// <exception cref="Exception">If process could not be killed</exception>
        public abstract void Kill();

        /// <summary>
        /// Wait for application to exit.
        /// Potentially indefinily.
        /// </summary>
        public abstract void WaitForExit();

        /// <summary>
        /// Wait for application to exit.
        /// But only a short while.
        /// </summary>
        /// <param name="millisecs"></param>
        /// <returns>Whether the application exited.</returns>
        public abstract bool WaitForExit(int millisecs);

        /// <summary>
        /// Wait for the process to enter the input <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa383561(v=vs.85).aspx">idle state</see>.
        /// Potentially indefinily.
        /// </summary>
        public abstract void WaitForInputIdle();

        /// <summary>
        /// Wait for the process to enter the input <see href="https://msdn.microsoft.com/en-us/library/windows/desktop/aa383561(v=vs.85).aspx">idle state</see>.
        /// </summary>
        /// <param name="time"></param>
        /// <returns>Whether the application is in the idle state.</returns>
        public abstract bool WaitForInputIdle(int time);

        /// <summary>
        /// Read the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not readable it will try to make it readable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemRead<T>(IntPtr address, out T buffer) where T : struct;

        /// <summary>
        /// Read the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not readable it will try to make it readable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemRead<T>(IntPtr address, IList<T> buffer) where T : struct;

        /// <summary>
        /// Read the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not readable it will try to make it readable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemRead<T>(IntPtr address, ref T[] buffer) where T : struct;

        /// <summary>
        /// Reads out a string of a pointer pointing in the middle of it.
        /// Useful when searching for substrings and want to read in the whole thing.
        /// Can be <see href="http://www.w3schools.com/charsets/ref_html_utf8.asp">UTF</see> 8, 16 or 32.
        /// </summary>
        /// <remarks>
        /// If memory is not readable when it will fail. It does not make sense for a program to have their
        /// strings which change to not be readable.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <param name="ptr"></param>
        /// <param name="unicode_type"></param>
        /// <returns></returns>
        public abstract string MemReadString(IntPtr ptr, Unicode unicode_type = Unicode.UTF8);

        /// <summary>
        /// Writes to the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not writable it will try to make it writeable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemWriteList<T>(IntPtr address, IEnumerable<T> buffer) where T : struct;

        /// <summary>
        /// Writes to the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not writable it will try to make it writeable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemWrite<T>(IntPtr address, T buffer) where T : struct;

        /// <summary>
        /// Writes to the process memory. 
        /// You can pass in an value type, an array of value types or an IList of value types.
        /// This will write their binary representations.
        /// </summary>
        /// <remarks>
        /// If memory is not writable it will try to make it writeable before.
        /// Notice that this function may fail randomly every one million call if memory page protection are set frequently
        /// by the target process.
        /// </remarks>
        /// <exception cref="Exception">If process is not running, or memory address does not exist.</exception>
        /// <typeparam name="T"></typeparam>
        /// <param name="address"></param>
        /// <param name="buffer"></param>
        public abstract void MemWrite<T>(IntPtr address, T[] buffer) where T : struct;

        /// <summary>
        /// Writes a string into process memory using a specific UTF encoding.
        /// </summary>
        /// <remarks>
        /// If memory is not writable it will try to make it writeable before.
        /// </remarks>
        /// <param name="ptr"></param>
        /// <param name="v"></param>
        /// <param name="unicode_type"></param>
        public abstract void MemWriteString(IntPtr ptr, string v, Unicode unicode_type = Unicode.UTF8);

        /// <summary>
        /// Finds a string in memory. Can be unicode string with widths of <see cref="https://en.wikipedia.org/wiki/Unicode">UTF-8</see>, 16 and 32.
        /// Searches through the whole memory space.
        /// </summary>
        /// <remarks>
        /// By specifying a mask you can tell the memory finder to ignore a character.
        /// Eg: MemFind("hello", "CXCCX") will ignore the characters e and o.
        /// Allowing you to match "htllp" or "hqllq" instead.
        /// </remarks>
        /// <param name="v"></param>
        /// <param name="uncode"></param>
        /// <returns></returns>
        public abstract IntPtr[] MemFind(string pattern, string mask = "", Unicode uncode = Unicode.UTF8);

        /// <summary>
        /// Finds an array in memory.
        /// Searches through the whole memory space.
        /// </summary>
        /// <remarks>
        /// By specifying a mask you can tell the memory finder to ignore a character.
        /// Eg: MemFind("hello", "CXCCX") will ignore the characters e and o.
        /// Allowing you to match "htllp" or "hqllq" instead.
        /// </remarks>
        /// <param name="v"></param>
        /// <param name="uncode"></param>
        /// <returns></returns>
        public abstract IntPtr[] MemFind<T>(T[] pattern, string mask = "") where T : struct;

        /// <summary>
        /// Finds a array in memory. 
        /// Searches through the whole memory space.
        /// </summary>
        /// <remarks>
        /// By specifying a mask you can tell the memory finder to ignore a character.
        /// Eg: MemFind("hello", "CXCCX") will ignore the characters e and o.
        /// Allowing you to match "htllp" or "hqllq" etc instead.
        /// </remarks>
        /// <param name="v"></param>
        /// <param name="uncode"></param>
        /// <returns></returns>
        public abstract IntPtr[] MemFindList<T>(IEnumerable<T> pattern, string mask = "") where T : struct;

        /// <summary>
        /// Allocates memory in the process.
        /// Remember to <see cref="MemDeallocate(IntPtr)"/> after.
        /// </summary>
        /// <param name="size"></param>
        /// <exception cref="Exception">If allocation could not happen. Mostly because process is not running.</exception>
        /// <returns></returns>
        public abstract IntPtr MemAllocate(int size);

        /// <summary>
        /// Deallocates memory in the process.
        /// </summary>
        /// <exception cref="Exception">If process is not running or if the memory has not been allocated before.</exception>
        /// <param name="ptr"></param>
        public abstract void MemDeallocate(IntPtr ptr);

        /// <summary>
        /// Pauses the process.
        /// Never forget to resume after.
        /// Pro tip: Always call <see cref="Resume"/> in a finally block.
        /// </summary>
        /// <remarks>
        /// Calling this while process is paused has no effect.
        /// </remarks>
        /// <exception cref="Exception">If process is not running.</exception>
        public abstract void Pause();

        /// <summary>
        /// Resumes the process if it is not already resumed.
        /// </summary>
        /// <remarks>
        /// Calling this while process is running has no effect.
        /// </remarks>
        /// <exception cref="Exception">If process is not running.</exception>
        public abstract void Resume();

        /// <summary>
        /// Tests whether the process is running.
        /// </summary>
        /// <remarks>
        /// Notice that this will only notice if the process has been paused by <see cref="Pause"/>
        /// and not by any extern factors.
        /// </remarks>
        /// <exception cref="Exception">If process is not running.</exception>
        public abstract bool IsPaused
        {
            get;
        }

        /// <summary>
        /// Reads a pointer chain from memory.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="offsets"></param>
        /// <exception cref="Exception">If process is not running. Any of the offsets does not redirect us to an pointer</exception>
        /// <returns>The resulting address which the pointers point to.</returns>
        public abstract IntPtr MemReadPointers(IntPtr start, int[] offsets);

        /// <summary>
        /// Reads a pointer chain from memory.
        /// Given the module name which it uses as the base pointer.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="offsets"></param>
        /// <exception cref="Exception">If process is not running. Any of the offsets does not redirect us to an pointer or if the module does not exist.</exception>
        /// <returns></returns>
        public abstract IntPtr MemReadPointers(string module, int[] offsets);

        /// <summary>
        /// Reads a pointer chain from memory.
        /// Given the module which it uses as the base pointer.
        /// </summary>
        /// <param name="module"></param>
        /// <param name="offsets"></param>
        /// <exception cref="Exception">If process is not running. Any of the offsets does not redirect us to an pointer or if the module does not exist/is not owned by this process.</exception>
        /// <returns></returns>
        public abstract IntPtr MemReadPointers(ProcessModule module, int[] offsets);

        /// <summary>
        /// Closes the handle used for accessing this process.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Finds out if the process is no longer running.
        /// </summary>
        public abstract bool HasExited
        {
            get;
        }

        /// <summary>
        /// Finds out if the process is running.
        /// The negation of <see cref="HasExited"/>.
        /// </summary>
        public abstract bool IsRunning
        {
            get;
        }
    }
}