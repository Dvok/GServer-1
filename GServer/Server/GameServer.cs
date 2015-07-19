using GServer.Server.CommunicationProtocol;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server
{
    public class GameServer
    {
        private IServerConfig m_Config;
        private IRootConfig m_RootConfig;
        private Encoding m_Encoding;
        private MyServer server;

        private IServerConfig DefaultServerConfig
        {
            get
            {
                return new ServerConfig
                {
                    Ip = "192.168.0.101",
                    LogCommand = true,
                    MaxConnectionNumber = 1000,
                    Mode = SocketMode.Udp,
                    Name = "Udp Test Socket Server",
                    Port = 4444,
                    ClearIdleSession = true,
                    ClearIdleSessionInterval = 1,
                    IdleSessionTimeOut = 5,
                    SendingQueueSize = 100
                };
            }
        }

        public GameServer()
        {
            m_Config = DefaultServerConfig;
            m_RootConfig = new RootConfig();
            m_Encoding = new System.Text.UTF8Encoding();
            server = new MyServer();
            server.NewSessionConnected += server_NewSessionConnected;
            server.SessionClosed += server_SessionClosed;
        }

        private void server_SessionClosed( MySession session, CloseReason value )
        {
            throw new NotImplementedException();
        }

        void server_NewSessionConnected( MySession session )
        {
            session.Send( "Hello there." );
        }

        public void RunTestUdpServer()
        {
            ( ( MySetup )server ).Setup( m_RootConfig, m_Config );

            server.Start();          
        }

        public void StopServer()
        {
            server.Stop();
        }


    }
}
