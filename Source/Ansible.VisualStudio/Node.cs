﻿/// ITNOA
/// 
/// This file copy from https://github.com/TeamCodeStream/codestream

using System;
using System.Text;


namespace Ansible.VisualStudio
{
	public class NodeDummy { }
	public static class Node {

		/// <summary>
		/// Method that ensures that the Node version meets the lowest required version
		/// </summary>
		/// <param name="nodeExe"></param>
		/// <param name="major"></param>
		/// <param name="minor"></param>
		/// <param name="build"></param>
		/// <returns></returns>
		public static bool EnsureVersion(string nodeExe, int major = 16, int minor = 13, int build = 2)
		{
			var sb = new StringBuilder();
			System.Diagnostics.Process process = null;
			try
			{
				process = new System.Diagnostics.Process();
				process.StartInfo.FileName = nodeExe;
				process.StartInfo.Arguments = "-v";
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.CreateNoWindow = true;
				process.OutputDataReceived += (sender, args) => sb.AppendLine(args.Data);
				process.StartInfo.UseShellExecute = false;
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.WaitForExit();
				// node doesn't use the same version format as .NET
				var nodeVersion = $"{sb.ToString().Substring(1)}.0";
				if (Version.TryParse(nodeVersion, out var result))
				{
					if (result < new Version(major, minor, build, 0))
					{
						throw new InvalidOperationException($"Node version incompatible ({result})");
					}

					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				// TODO: Log this problem
				throw;
			}
			finally
			{
				process?.Dispose();
			}
		}
	}
}
