using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
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

        public async Task<Connection> ActivateAsync(CancellationToken token)
        {
            await Task.Yield();
            Connection connection= null;
            try
            {
                Process process = _languageServerClientProcess?.Create() ?? new LanguageServerClientProcess().Create();

                // TODO: Log
                if (process.Start())
                {
                    connection = new Connection(reader: process.StandardOutput.BaseStream, writer: process.StandardInput.BaseStream);
                }
                else
                {
                    // TODO: Log
                }
            }
            catch(Exception ex)
            {
                // TOOD: Log
                throw ex;
            }
            return connection;
        }

        public async Task OnLoadedAsync()
        {
            if (StartAsync != null)
            {
                await StartAsync.InvokeAsync(this, EventArgs.Empty);
            }
        }

        public async Task StopServerAsync()
        {
            if (StopAsync != null)
            {
                await StopAsync.InvokeAsync(this, EventArgs.Empty);
            }
        }

        public async Task OnServerInitializedAsync()
        {
            await Task.CompletedTask;
        }

        // TODO: Check x64
        public Task<InitializationFailureContext> OnServerInitializeFailedAsync(ILanguageClientInitializationInfo initializationState)
        {
            return Task.FromResult(new InitializationFailureContext
            {
                FailureMessage = initializationState.StatusMessage
            });
        }

        private readonly ILanguageServerClientProcess _languageServerClientProcess;
    }
}
