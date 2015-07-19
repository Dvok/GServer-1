using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Data.Entity;
using System.Diagnostics;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System.Threading;
using GServer.Server;

namespace GServer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //StartServer();sds
        }

        private async Task GetPlayers()
        {         
            /*if ( entities.player.Select( x => x.Name == "test").Count() == 0 )
                entities.player.Add( new player() { Name = "test" });
            */

            Func<List<player>> result = delegate()
            {
                gdbEntities entities = new gdbEntities();
                return entities.player.ToList();
            };

            List<player> playerCollection = await Task.Run(result);

            foreach ( var player in playerCollection )
            {
                InfoBox.Text += String.Format("\n\t{0}\t{1}",
                    player.idPlayer, player.Name);
            }

            InfoBox.Text += "1 second delay!";

            //await entities.SaveChangesAsync();
        }
        //http://www.asp.net/mvc/overview/older-versions-1/models-(data)/creating-model-classes-with-the-entity-framework-cs
        //http://habrahabr.ru/company/microsoft/blog/133316/


        private async void StartServer_Click(object sender, EventArgs e)
        {
            UdpServer();

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Task getPlayers = GetPlayers();
            
            watch.Stop();
            TimeSpan ts = watch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            InfoBox.Text += elapsedTime;

            await getPlayers;
        }

        public void UdpServer()
        {
            GameServer server = new GameServer();
            server.TestUdpServer();
        }

        static void _NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
        {
            switch (requestInfo.Key.ToUpper())
            {
                case("ECHO"):
                    session.Send(requestInfo.Body);
                    break;

                case ("ADD"):
                    session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
                    break;

                case ("MULT"):

                    var result = 1;

                    foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
                    {
                        result *= factor;
                    }

                    session.Send(result.ToString());
                    break;
            }
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            InfoBox.Text += "Server Stopped";
        }

    }

}
