using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BotPlugin.API
{
    public enum VirtualKey
    {
        LBUTTON = 0x01,
        RBUTTON = 0x02,
        CANCEL = 0x03,
        MBUTTON = 0x04,
        XBUTTON1 = 0x05,
        XBUTTON2 = 0x06,
        BACK = 0x08,
        TAB = 0x09,
        CLEAR = 0x0C,
        RETURN = 0x0D,
        SHIFT = 0x10,
        CONTROL = 0x11,
        MENU = 0x12,
        PAUSE = 0x13,
        CAPITAL = 0x14,
        KANA = 0x15,
        HANGUEL = 0x15,
        HANGUL = 0x15,
        JUNJA = 0x17,
        FINAL = 0x18,
        HANJA = 0x19,
        KANJI = 0x19,
        ESCAPE = 0x1B,
        CONVERT = 0x1C,
        NONCONVERT = 0x1D,
        ACCEPT = 0x1E,
        MODECHANGE = 0x1F,
        SPACE = 0x20,
        PRIOR = 0x21,
        NEXT = 0x22,
        END = 0x23,
        HOME = 0x24,
        LEFT = 0x25,
        UP = 0x26,
        RIGHT = 0x27,
        DOWN = 0x28,
        SELECT = 0x29,
        PRINT = 0x2A,
        EXECUTE = 0x2B,
        SNAPSHOT = 0x2C,
        INSERT = 0x2D,
        DELETE = 0x2E,
        HELP = 0x2F,
        Key0 = 0x30,
        Key1 = 0x31,
        Key2 = 0x32,
        Key3 = 0x33,
        Key4 = 0x34,
        Key5 = 0x35,
        Key6 = 0x36,
        Key7 = 0x37,
        Key8 = 0x38,
        Key9 = 0x39,
        KeyA = 0x41,
        KeyB = 0x42,
        KeyC = 0x43,
        KeyD = 0x44,
        KeyE = 0x45,
        KeyF = 0x46,
        KeyG = 0x47,
        KeyH = 0x48,
        KeyI = 0x49,
        KeyJ = 0x4A,
        KeyK = 0x4B,
        KeyL = 0x4C,
        KeyM = 0x4D,
        KeyN = 0x4E,
        KeyO = 0x4F,
        KeyP = 0x50,
        KeyQ = 0x51,
        KeyR = 0x52,
        KeyS = 0x53,
        KeyT = 0x54,
        KeyU = 0x55,
        KeyV = 0x56,
        KeyW = 0x57,
        KeyX = 0x58,
        KeyY = 0x59,
        KeyZ = 0x5A,
        LWIN = 0x5B,
        RWIN = 0x5C,
        APPS = 0x5D,
        SLEEP = 0x5F,
        NUMPAD0 = 0x60,
        NUMPAD1 = 0x61,
        NUMPAD2 = 0x62,
        NUMPAD3 = 0x63,
        NUMPAD4 = 0x64,
        NUMPAD5 = 0x65,
        NUMPAD6 = 0x66,
        NUMPAD7 = 0x67,
        NUMPAD8 = 0x68,
        NUMPAD9 = 0x69,
        MULTIPLY = 0x6A,
        ADD = 0x6B,
        SEPARATOR = 0x6C,
        SUBTRACT = 0x6D,
        DECIMAL = 0x6E,
        DIVIDE = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        NUMLOCK = 0x90,
        SCROLL = 0x91,
        LSHIFT = 0xA0,
        RSHIFT = 0xA1,
        LCONTROL = 0xA2,
        RCONTROL = 0xA3,
        LMENU = 0xA4,
        RMENU = 0xA5,
        BROWSER_BACK = 0xA6,
        BROWSER_FORWARD = 0xA7,
        BROWSER_REFRESH = 0xA8,
        BROWSER_STOP = 0xA9,
        BROWSER_SEARCH = 0xAA,
        BROWSER_FAVORITES = 0xAB,
        BROWSER_HOME = 0xAC,
        VOLUME_MUTE = 0xAD,
        VOLUME_DOWN = 0xAE,
        VOLUME_UP = 0xAF,
        MEDIA_NEXT_TRACK = 0xB0,
        MEDIA_PREV_TRACK = 0xB1,
        MEDIA_STOP = 0xB2,
        MEDIA_PLAY_PAUSE = 0xB3,
        LAUNCH_MAIL = 0xB4,
        LAUNCH_MEDIA_SELECT = 0xB5,
        LAUNCH_APP1 = 0xB6,
        LAUNCH_APP2 = 0xB7,
        OEM_1 = 0xBA,
        OEM_PLUS = 0xBB,
        OEM_COMMA = 0xBC,
        OEM_MINUS = 0xBD,
        OEM_PERIOD = 0xBE,
        OEM_2 = 0xBF,
        OEM_3 = 0xC0,
        OEM_4 = 0xDB,
        OEM_5 = 0xDC,
        OEM_6 = 0xDD,
        OEM_7 = 0xDE,
        OEM_8 = 0xDF,
        OEM_102 = 0xE2,
        PROCESSKEY = 0xE5,
        PACKET = 0xE7,
        ATTN = 0xF6,
        CRSEL = 0xF7,
        EXSEL = 0xF8,
        EREOF = 0xF9,
        PLAY = 0xFA,
        ZOOM = 0xFB,
        NONAME = 0xFC,
        PA1 = 0xFD,
        OEM_CLEAR = 0xFE
    }

    public enum MouseKey
    {
        Left = 0x01,
        Right = 0x02,
        Middle = 0x04,
        X1 = 0x05,
        X2 = 0x06,
    }

    [Flags]
    public enum Modifier
    {
        None = 0x1,
        Shift = 0x2,
        Ctrl = 0x4,
        Alt = 0x8
    }

    public delegate void MouseMoveHandler(Modifier modifiers, double x, double y);
    public delegate void MousePressHandler(MouseKey key, Modifier modifiers, double x, double y);
    public delegate void KeyboardPressHandler(VirtualKey key, Modifier modifiers);

    /// <summary>
    /// Represents a window from which you can send commands, do mouse movements relative to the
    /// window, write text and listen for user input on this window.
    /// </summary>
    /// <remarks>
    /// These operations require that the window has focus.
    /// If it has not it will log an warning to the user and wait.
    /// If you do not want to wait and just try to send an event you can use
    /// the Try[NAME] or Do[NAME] versions instead.
    /// </remarks>
    public interface IWindow
    {

        /// <summary>
        /// Does a keyboard command on this window.
        /// Waits until window has focus.
        /// </summary>
        /// <exception cref="Exception">If window does not exist</exception>
        /// <param name="key"></param>
        /// <param name="modifiers">To use both Shift and Ctrl at once. | modifiers together.</param>
        void KeyboardCommand(VirtualKey key, Modifier modifiers = Modifier.None);

        /// <summary>
        /// Tries to do a keyboard command.
        /// Throws if it could not.
        /// </summary>
        /// <exception cref="Exception">If window does not exist or try command failed.</exception>
        /// <param name="key"></param>
        /// <param name="modifiers"></param>
        void TryKeyboardCommand(VirtualKey key, Modifier modifiers = Modifier.None);

        /// <summary>
        /// Does a keyboard command instantly.
        /// Returns a bool if it was successful or not.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="key"></param>
        /// <param name="modifiers"></param>
        /// <returns>Whether the keyboard command was sent or not.</returns>
        bool DoKeyboardCommand(VirtualKey key, Modifier modifiers = Modifier.None);

        /// <summary>
        /// Writes text to the currently focused element.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="text"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void WriteText(string text, int time_between_each_char = 20);

        /// <summary>
        /// Writes text to the currently focused element.
        /// Throws if window does not have focus.
        /// </summary>
        /// <exception cref="Exception">If window does not exist or does not have focus.</exception>
        /// <param name="text"></param>
        void TryWriteText(string text, int time_between_each_char = 20);

        /// <summary>
        /// Writes text to the currently focused element.
        /// </summary>
        /// <exception cref="Exception">If window does not exist.</exception>
        /// <param name="text"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>Whether the text was written or not.</returns>
        bool DoWriteText(string text, int time_between_each_char = 20);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Waits for window to become active.
        /// </summary>
        /// <exception cref="Exception">If window does not exist or x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void MouseClick(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Throws if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window does not exist or if window is not focused. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseClick(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>Returns if mouse click was made.</returns>
        bool DoMouseClick(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses absolute pixels relative to the window.
        /// Use this if elements in window does not scale exactly with the window size.
        /// Waits for window to become focused.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void MouseClickAbs(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses absolute pixels relative to the window.
        /// Use this if elements in window does not scale exactly with the window size.
        /// Throws if window is not focused.
        /// </summary>
        /// <exception cref="Exception">If window does not exist or if window is not focused. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseClickAbs(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Does a mouse click on the window.
        /// Uses absolute pixels relative to the window.
        /// Use this if elements in window does not scale exactly with the window size.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="key"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>If mouse click could be made.</returns>
        bool DoMouseClickAbs(MouseKey key, double x, double y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Waits if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void MouseMove(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Waits if window is not active.
        /// </summary>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="time_it_should_take"></param>
        void MouseMoveAbs(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Throws if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window is not active or if window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseMove(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Throws if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window is not active or if window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseMoveAbs(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>If window is focused and mouse operation could be done.</returns>
        bool DoMouseMove(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Moves the mouse from the current position to the new.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>If window is focused and mouse operation could be done.</returns>
        bool DoMouseMoveAbs(double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Waits if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void MouseDrag(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Waits if window is not active.
        /// </summary>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="time_it_should_take"></param>
        void MouseDragAbs(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Throws if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window is not active or if window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseDrag(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// Throws if window is not active.
        /// </summary>
        /// <exception cref="Exception">If window is not active or if window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        void TryMouseDragAbs(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses normalized positioning meaning x == 1000 is the far right side
        /// and 500 is in the middle of the screen.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>If window is focused and mouse operation could be done.</returns>
        bool DoMouseDrag(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// Holds a key while moving the mouse.
        /// Uses absolute pixels relative to the window.
        /// Counted from top left. Or position (0, 0) is the top left corner of the window.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if x or y is not between 0 and 1000.</exception>
        /// <param name="to_x"></param>
        /// <param name="to_y"></param>
        /// <param name="timeline"></param>
        /// <param name="time_it_should_take">In milliseconds</param>
        /// <returns>If window is focused and mouse operation could be done.</returns>
        bool DoMouseDragAbs(MouseKey key, double to_x, double to_y, int time_it_should_take = 200);

        /// <summary>
        /// The title of the window.
        /// </summary>
        /// <returns></returns>
        string Caption
        {
            get;
        }

        /// <summary>
        /// Whether the window is actually visible to the user or not.
        /// </summary>
        bool Visible
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the colors of the window. Allowing easy enumeration.
        /// Waits for window to become active before actually taking the picture.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if window never gets activated by the user.</exception>
        /// 
        /// <returns></returns>
        IEasyBitmap GetPixels();

        /// <summary>
        /// Gets the colors of the window. Allowing easy enumeration.
        /// Throws if window is not activated.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if window never gets activated by the user. Or if window is not activated.</exception>
        /// <param name="format"></param>
        /// <returns></returns>
        IEasyBitmap TryGetPixels(PixelFormat format = PixelFormat.Format32bppArgb);

        /// <summary>
        /// Gets the colors of the window. Allowing easy enumeration.
        /// Waits for window to become active before actually taking the picture.
        /// Returns null if window is not activated.
        /// </summary>
        /// <exception cref="Exception">If window does not exist. Or if window never gets activated by the user.</exception>
        /// <param name="format"></param>
        /// <returns>Null if window is not activated.</returns>
        IEasyBitmap DoGetPixels(PixelFormat format = PixelFormat.Format32bppArgb);

        /// <summary>
        /// Gets the color of a single pixel.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The color.</returns>
        Color ColorAt(double x, double y);

        /// <summary>
        /// The PID (Process id) of the process associated with this window.
        /// </summary>
        int Pid
        {
            get;
        }

        IntPtr HWND
        {
            get;
        }

        /// <summary>
        /// Listen for keyboard presses.
        /// </summary>
        /// <remarks>
        /// The action will run in another thread.
        /// So make sure to take actions accordingly.
        /// </remarks>
        event KeyboardPressHandler OnKeyboardEvent;


        /// <summary>
        /// Listen for mouse presses.
        /// </summary>
        /// <remarks>
        /// The action will run in another thread.
        /// So make sure to take actions accordingly.
        /// </remarks>
        event MousePressHandler OnMousePress;

        /// <summary>
        /// Listen mouse moves.
        /// </summary>
        /// <remarks>
        /// The action will run in another thread.
        /// So make sure to take actions accordingly.
        /// </remarks>
        event MouseMoveHandler OnMouseMove;

        /// <summary>
        /// Tells if the window currently exists.
        /// And have not been closed.
        /// </summary>
        bool Exists
        {
            get;
        }

        /// <summary>
        /// The position of the mouse converted to normalized units.
        /// </summary>
        /// <returns>Null if cursor is not within window.</returns>
        NormalizedPoint RelativeMousePos();
    }
}