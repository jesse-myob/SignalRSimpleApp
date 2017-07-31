using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.Client.Common.Config
{
    public class SignalRConfiguration: ISignalRConfiguration
    {
        public string SignalRServerUrl { get; set; }

        public SignalRConfiguration()
        {
            var rawSignalRUrl = ConfigurationManager.AppSettings["signalRURL"];
            SignalRServerUrl = rawSignalRUrl;
        }
    }
}
