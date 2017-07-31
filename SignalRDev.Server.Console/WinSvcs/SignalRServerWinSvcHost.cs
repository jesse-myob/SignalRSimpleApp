
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Common.Logging;


namespace SignalRDev.Server.WinSvc.WinSvcs
{
    public class SignalRServerWinSvcHost: Host
    {
        private static readonly ILog Log = LogManager.GetLogger<SignalRServerWinSvcHost>();

        public TopshelfExitCode Run()
        {
            const string METHOD_NAME = "Run";

            TopshelfExitCode topshelfExitCode = TopshelfExitCode.AbnormalExit;

            Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Executing");

            try
            {
                topshelfExitCode = HostFactory.Run(x =>
                {
                    x.UseAssemblyInfoForServiceInfo();

                    x.UseCommonLogging();

                    x.Service<SignalRServerWinSvc>(settings => new SignalRServerWinSvc(), s =>
                    {
                        s.BeforeStartingService(_ => BeforeStartingService());
                        s.BeforeStoppingService(_ => BeforeStoppingService());
                    });
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1} - {2}", METHOD_NAME, "Errored", ex.ToString());
            }
            finally
            {
                Log.DebugFormat("{0} - {1}", METHOD_NAME, "Executed");
            }

            return topshelfExitCode;
        }

        private void BeforeStartingService()
        {
            const string METHOD_NAME = "BeforeStartingService";

            Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Executing");
            try
            {
                // Do something
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1} - {2}", METHOD_NAME, "Errored", ex.ToString());
            }
            finally
            {
                Log.DebugFormat("{0} - {1}", METHOD_NAME, "Executed");
            }
        }

        private void BeforeStoppingService()
        {
            const string METHOD_NAME = "BeforeStoppingService";

            Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Executing");
            try
            {
                // Do something
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1} - {2}", METHOD_NAME, "Errored", ex.ToString());
            }
            finally
            {
                Log.DebugFormat("{0} - {1}", METHOD_NAME, "Executed");
            }
        }
    }
}
