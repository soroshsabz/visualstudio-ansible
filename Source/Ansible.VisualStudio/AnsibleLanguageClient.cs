using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ansible.VisualStudio
{
    [ContentType("ansible")]
    [Export(typeof(ILanguageClient))]
    public class AnsibleLanguageClient : ILanguageClient
    {
        public string Name => "Ansible Language Extension";

        public IEnumerable<string> ConfigurationSections => null;

        public object InitializationOptions => null;

        public IEnumerable<string> FilesToWatch => null;

        public bool ShowNotificationOnInitializeFailed => true;

        public event AsyncEventHandler<EventArgs> StartAsync;
        public event AsyncEventHandler<EventArgs> StopAsync;

        public Task<Connection> ActivateAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task OnLoadedAsync()
        {
            throw new NotImplementedException();
        }

        public Task OnServerInitializedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<InitializationFailureContext> OnServerInitializeFailedAsync(ILanguageClientInitializationInfo initializationState)
        {
            throw new NotImplementedException();
        }
    }
}
