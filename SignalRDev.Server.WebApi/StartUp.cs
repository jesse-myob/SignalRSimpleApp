using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using System.Reflection;

[assembly: OwinStartup(typeof(SignalRDev.Server.WebApi.Startup))]

namespace SignalRDev.Server.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(CreateKernel);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
