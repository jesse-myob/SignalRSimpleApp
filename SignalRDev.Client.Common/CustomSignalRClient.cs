using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR;
using SignalRDev.Client.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalRDev.Client.Common.Config;

namespace SignalRDev.Client.Common
{
    public class CustomSignalRClient : ISignalRClient
    {
        public IHubProxy Proxy { get; set; }

        private readonly ISignalRConfiguration _signalRConfig;

        public CustomSignalRClient(ISignalRConfiguration config)
        {
            _signalRConfig = config;
        }

        public async Task SetupSignalR(Action<IHubProxy> HubMessageConfiguration)
        {
            var vhubConnection = new HubConnection(_signalRConfig.SignalRServerUrl);

            Proxy = vhubConnection.CreateHubProxy("DashboardHub");

            HubMessageConfiguration(Proxy);

            await vhubConnection.Start();
        }
    }
}
