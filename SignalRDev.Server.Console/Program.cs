using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Ninject;
using SignalRDev.DataAccess.Dashboard.Interface;
using SignalRDev.DataAccess.Dashboard;
using SignalRDev.Server.WinSvc.WinSvcs;
using Common.Logging;


namespace SignalRDev.Server
{
    class Program
    {
        private static readonly ILog _log = LogManager.GetLogger<Program>();

        static int Main(string[] args)
        {
            var host = new SignalRServerWinSvcHost();

            var exitCode = (int)host.Run();

            return exitCode;
        }
    }
}
