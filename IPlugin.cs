using BotPlugin.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPlugin
{
    public enum OSEnv
    {
        windowsDesktop
    }

    public interface IBotRunner
    {
        string GetName();
        string GetVersion();
        string GetDescription();
        string GetAuthor();
        OSEnv GetOSEnv();
        void SetupSettingsGUI(Panel botPanel);
        void onStart(IAPI api);

    }
}
