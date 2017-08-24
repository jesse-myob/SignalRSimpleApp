using Microsoft.AspNet.SignalR;
using System;
using Ninject;
using Common.Logging;
using SignalRDev.Svc.Dashboard.Users;
using SignalRDev.BusinessLogic.Interfaces.Users;

namespace SignalRDev.Server.CustomHub
{
    public class DashboardHub: Hub
    {
        private static readonly ILog Log = LogManager.GetLogger<DashboardHub>();

        [Inject]
        public IDashboardBll _uLogDataAccess { get; set; }

        public void AddMessage(string name, string message)
        {
            Console.WriteLine("Hub AddMessage");
            Clients.All.addMessage(name, message);
        }

        public void Heartbeat()
        { 
            Console.WriteLine("Hub Heartbeat.");
            Clients.All.heartBeat();
        }

        public void SendHelloObject(dynamic hello)
        {
            var a = hello.UserId;
            Console.WriteLine("Hub hello {0} {1}\n", hello.UserId, hello.Message);

            Clients.All.sendHelloObject(hello);
        }

        public void BroadcastUserLog(UserLogInformationVM userLoginInfo)
        {
            const string METHOD_NAME = "BroadcastUserLog";

            try
            {
                Console.WriteLine("{0} {1} on {2}", userLoginInfo.Message, userLoginInfo.UserId, userLoginInfo.LogDate);

                // You can do save messages here?
                _uLogDataAccess.AddNewUserLog(new UserLogInformationVM());
            }
            catch (ArgumentException ax)
            {
                Console.WriteLine(ax.Message);
            }
            catch (Exception ex)
            {
                // Do logging here
                Console.WriteLine(ex.Message);

                Log.ErrorFormat("[{0}] {1}", METHOD_NAME, ex.Message);
            }

            Clients.All.BroadcastUserLog(userLoginInfo);
        }
    }
}
