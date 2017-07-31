using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.Client.Common.Interface
{
    public interface ISignalRClient
    {
        /// <summary>
        /// Ser pang tawag ni sa server hub functions
        /// </summary>
        IHubProxy Proxy { get; set; }

        /// <summary>
        /// Ser pang setup ni sa server responses
        /// </summary>
        /// <param name="HubMessageConfiguration"></param>
        /// <returns></returns>
        Task SetupSignalR(Action<IHubProxy> HubMessageConfiguration);
    }
}
