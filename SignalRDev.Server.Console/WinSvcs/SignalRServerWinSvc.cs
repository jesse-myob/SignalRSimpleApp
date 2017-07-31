using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace SignalRDev.Server.WinSvc.WinSvcs
{
    public class SignalRServerWinSvc : ServiceControl
    {
        private static readonly LogWriter Log = HostLogger.Get<SignalRServerWinSvc>();

        public bool Start(HostControl hostControl)
        {
            const string METHOD_NAME = "Start";

            Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Starting");

            try
            {
                var rawURLConfig = ConfigurationManager.AppSettings["SignalRserverURL"];

                /*
                StartOptions options = new StartOptions();
                options.Urls.Add(rawURLConfig);
                options.Urls.Add("http://127.0.0.1:7654");
                options.Urls.Add(string.Format("http://{0}:7654", Environment.MachineName));
                 */

                using (WebApp.Start<Startup>(url: rawURLConfig))
                //using (WebApp.Start<Startup>(options: options))
                {
                    string key = Console.ReadLine();
                }

                Log.DebugFormat("[{0}] Server URL: {1}", METHOD_NAME, rawURLConfig); 

                return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1}", METHOD_NAME, ex.Message);
            }
            finally
            {
                Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Started");
            }
            
            return false;
        }

        public bool Stop(HostControl hostControl)
        {
            const string METHOD_NAME = "Stop";

            try
            {
                Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Service Stopped");
                return true;
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1} - {2}", METHOD_NAME, "Errored", ex.ToString());
            }

            return false;
        }
    }
}
