using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansible.VisualStudio
{
    internal class ProcessFactory
    {
        public static Process Create(string fileName, string arguments)
        {
            if (fileName == null) throw new ArgumentNullException(nameof(fileName));
            if (arguments != null)
            {
                if (arguments.Contains("ansible"))
                {
                    return CreateOnWsl(fileName, arguments);
                }
            }
            var info = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            };

            var process = new Process()
            {
                StartInfo = info
            };

            return process;
        }

        private static Process CreateOnWsl(string fileName, string arguments)
        {
            if (fileName.Contains(".exe"))
                fileName = fileName.Replace(".exe", "");

            if (arguments.Contains("C:"))
            {
                arguments = arguments.Replace(@"C:\", @"/mnt/c/");
                arguments = arguments.Replace(@"\",@"/");
            }

            PrepareDependencies(path: arguments.Remove(arguments.IndexOf("ansible-lan")).Replace("\"","").Trim(' '));

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"cmd.exe",
                    Arguments = $@"/c wsl {fileName} {arguments}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            return process;
        }

        private static void PrepareDependencies(string path)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"cmd.exe",
                    Arguments = "/c wsl cd " + path.Replace(" ", "\\ ") + "; npm install .",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
        }
    }
}
