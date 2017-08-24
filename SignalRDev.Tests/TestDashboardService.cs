using Microsoft.AspNet.SignalR.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SignalRDev.Server.WinSvc.WinSvcs;
using SignalRDev.Svc.Dashboard.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SignalRDev.Tests
{
    [TestClass]
    public class TestDashboardService
    {
        [TestMethod]
        public void TestClientGetUserLogFromHub()
        { 
            SignalRServerWinSvc service = new SignalRServerWinSvc();
            PrivateObject privateObject = new PrivateObject(service);
            privateObject.Invoke("Start", new HostControl[] { null });

            UserLogInformationVM userInfo = null;

            using (HubConnection hub = new HubConnection("http://localhost:7654"))
            {
                IHubProxy proxy = hub.CreateHubProxy("DashboardHub");
                hub.Start().Wait();

                proxy.Invoke<UserLogInformationVM>("BroadcastUserLog", new UserLogInformationVM {
                    UserId = "15274",
                    LogDate = DateTime.Now,
                    Message = "User has login"
                });

                proxy.On<UserLogInformationVM>("BroadcastUserLog", (userinfo) =>
                {
                    userInfo = userinfo;
                });

                //Assert.IsNotNull(userInfo);
            }
        }
    }
}
