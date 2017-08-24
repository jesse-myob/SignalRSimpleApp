using System;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using Ninject;
using Common.Logging;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SignalRDev.Server.WinSvc.Startup))]

namespace SignalRDev.Server.WinSvc
{
    public class Startup
    {
        private static readonly ILog Log = LogManager.GetLogger<Startup>();
        
        public void Configuration(IAppBuilder app)
        {
            const string METHOD_NAME = "Configuration";

            Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Owin Server, Dependencies being Configured.");

            try
            {
                app.Map("/signalr", map =>
                {
                    var kernel = new StandardKernel();
                    var resolver = new NinjectSignalRDependencyResolver(kernel);

                    #region Dependency Resolving Bindings
                    
                    //kernel.Bind<IUserLogDataAccess>().To<UserLogDataAccess>().InSingletonScope();


                    #endregion

                    map.UseCors(CorsOptions.AllowAll);
                    var hubConfiguration = new HubConfiguration
                    {
                        Resolver = resolver
                    };

                    hubConfiguration.EnableDetailedErrors = true;
                    map.RunSignalR(hubConfiguration);
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("[{0}] {1}", METHOD_NAME, ex.Message);
            }
            finally
            {
                Log.DebugFormat("[{0}] {1}", METHOD_NAME, "Server Configured");
            }
        }
    }
}
