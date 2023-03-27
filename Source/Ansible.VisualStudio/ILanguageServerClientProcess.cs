using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ansible.VisualStudio
{
    public interface ILanguageServerClientProcess
    {
        Process Create();
    }
}
