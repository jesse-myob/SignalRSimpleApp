using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.Client.Common.Config
{
    public interface ISignalRConfiguration
    {
        string SignalRServerUrl { get; set; }
    }
}
