using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SignalRDev.Client.Common;
using SignalRDev.Client.Common.Interface;
using SignalRDev.Client.Common.Config;
using SignalRDev.Svc.Common;

namespace SignalRDev.Client.WinApp
{
    public partial class Form1 : Form
    {
        public System.Threading.Thread Thread { get; set; }

        public bool Active { get; set; }

        private ISignalRClient signalRClient;

        public Form1()
        {
            InitializeComponent();

            // Do Dependency Injection binding on startup please. =)
            signalRClient = new CustomSignalRClient(new SignalRConfiguration());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Active = true;
            Thread = new System.Threading.Thread(() =>
            {
                signalRClient.SetupSignalR((Proxy) => {

                    /* Server Responses
                     
                    Proxy.On<string, string>("addMessage", (id, message) =>
                    {
                        textBox3.BeginInvoke(new InvokeDelegate(ServerCallbackDelegate));
                    });

                    Proxy.On("heartBeat", () =>
                    {
                        // Do Logging or whatever
                    });

                    Proxy.On<dynamic>("sendHelloObject", (dynParam) =>
                    {
                        // Do Logging or whatever
                    });

                    Proxy.On<UserLogInformation>("broadcastUserLog", (userInfo) =>
                    {
                        // Do Logging or whatever
                    });
                    */

                });

                while (Active)
                {
                    System.Threading.Thread.Sleep(10);
                }
            }) { IsBackground = true };

            Thread.Start();
        }

        private void ServerCallbackDelegate(string id, string message)
        {
            textBox3.Text = string.Format("{0} {2}", id, message);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await signalRClient.Proxy.Invoke("AddMessage", textBox1.Text, textBox2.Text);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var co = new
            {
                UserId = textBox2.Text,
                Message = "Hey this is a message"
            };

            await signalRClient.Proxy.Invoke("SendHelloObject", co);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await signalRClient.Proxy.Invoke("BroadcastUserLog", new UserLogInformation
            {
                UserId = "15274",
                LogDate = DateTime.Now,
                Message = "User has login"
            });
        }
    }
}
