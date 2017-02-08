using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlugin.API
{
    [Serializable]
    public class RestorationException : Exception
    {

        private RestorationException(string msg, List<string> failed_dirs, List<string> failed_files)
            : base(msg)
        {
            Files = failed_files;
            Dirs = failed_dirs;
        }

        public List<string> Files
        {
            get;
        }

        public List<string> Dirs
        {
            get;
        }

        public static void Throw(List<string> failed_dirs, List<string> failed_files)
        {
            var sb = new StringBuilder();
            sb.Append("Failed to restore files or directories:\n");
            sb.Append("Directories:\n");

            foreach(var dir in failed_dirs)
            {
                sb.Append("\t");
                sb.Append(dir);
                sb.Append("\n");
            }

            sb.Append("Files: \n");
            foreach(var file in failed_files)
            {
                sb.Append("\t");
                sb.Append(file);
                sb.Append("\n");
            }

            throw new RestorationException(sb.ToString(), failed_dirs, failed_files);
        }
    }
}
