using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace luau.visualstudio.lsp {
    /// <summary>
    /// <see href="https://learn.microsoft.com/en-us/visualstudio/extensibility/adding-an-lsp-extension?view=vs-2022"/>
    /// </summary>
    [ContentType(Constants.CONTENT_TYPE)]
    [Export(typeof(ILanguageClient))]
    internal class LuauLanguageClient : ILanguageClient {
        public string Name => "Luau Language Server Client";

        public IEnumerable<string> ConfigurationSections => null;

        public object InitializationOptions => null;

        public IEnumerable<string> FilesToWatch => null;

        public bool ShowNotificationOnInitializeFailed => true;

        public event AsyncEventHandler<EventArgs> StartAsync;
        public event AsyncEventHandler<EventArgs> StopAsync;

        public async Task<Connection> ActivateAsync(CancellationToken token) {
            await Task.Yield();

            // TODO: support for .luarc, definitions, docs files
            List<string> args = new List<string>() {
                "lsp"
            };

            Process process = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "luau-lsp.exe"),
                    Arguments = string.Join(" ", args),
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            return process.Start() ? new Connection(process.StandardOutput.BaseStream, process.StandardInput.BaseStream) : null;
        }

        public async Task OnLoadedAsync() {
            await StartAsync.InvokeAsync(this, EventArgs.Empty);
        }

        public Task OnServerInitializedAsync() {
            return Task.CompletedTask;
        }

        public Task<InitializationFailureContext> OnServerInitializeFailedAsync(ILanguageClientInitializationInfo initializationState) {
            return (Task<InitializationFailureContext>) Task.CompletedTask;
        }
    }
}
