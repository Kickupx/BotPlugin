namespace BotPlugin.API
{
    public enum LogType
    {
        Error,
        Warning,
        Success,
        Normal,
        Notification
    }

    /// <summary>
    /// The object on which you can display logged messages to the user.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Red message.
        /// </summary>
        /// <param name="msg"></param>
        void LogError(string msg);

        /// <summary>
        /// Yellow message.
        /// </summary>
        /// <param name="msg"></param>
        void LogWarning(string msg);

        /// <summary>
        /// Green message.
        /// </summary>
        /// <param name="msg"></param>
        void LogSuccess(string msg);

        /// <summary>
        /// Black message.
        /// </summary>
        /// <param name="msg"></param>
        void LogNormal(string msg);

        /// <summary>
        /// Blue message.
        /// </summary>
        /// <param name="msg"></param>
        void LogNotification(string msg);

        /// <summary>
        /// Display a message but specify message type using an enum instead.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="msg"></param>
        void Log(LogType type, string msg);
    }
}