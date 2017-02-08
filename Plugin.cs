using BotPlugin.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BotPlugin
{
    abstract public class BotRunner : IBotRunner
    {
        public abstract string GetAuthor();
        public abstract string GetDescription();
        public abstract string GetName();

        public OSEnv GetOSEnv()
        {
            return OSEnv.windowsDesktop;
        }

        public abstract string GetVersion();
        public abstract void onStart(IAPI api);
        public abstract void SetupSettingsGUI(Panel botPanel);

        public override string ToString()
        {
            return GetName();
        }
    }
}
