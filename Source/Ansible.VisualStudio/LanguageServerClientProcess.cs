using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ansible.VisualStudio
{
    internal class LanguageServerClientProcess : ILanguageServerClientProcess
    {
        public Process Create()
        {
            var assembly = Assembly.GetAssembly(typeof(LanguageServerClientProcess));
            string arguments = null;
            var exe = @"node.exe";
            var logPath = $"server.log";

#if DEBUG
            Node.EnsureVersion(exe);
            var path = Path.GetDirectoryName(assembly.Location) + @"\ansible-language-server\server.js";

            if (!File.Exists(path))
            {
                // TODO: Log
                throw new FileNotFoundException(path);
            }

            arguments = $@" ""{path}"" --stdio --log={logPath}";
#endif

            return ProcessFactory.Create(fileName: exe, arguments: arguments);
        }
    }
}
