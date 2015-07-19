using GServer.Common;
using GServer.Packages;
using GServer.Server.CommunicationProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GServer
{
    public class TestClient
    {

        private EndPoint serverAddress;
        private Encoding m_Encoding;

        public TestClient( string IpAdress, int port )
        {
            serverAddress = new IPEndPoint( IPAddress.Parse( IpAdress ), port );
            m_Encoding = new System.Text.UTF8Encoding();
        }

        public void SendMsg()
        {

            using ( Socket socket = new Socket( AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp ) )
            {

                StringBuilder sb = new StringBuilder();

                string sessionID = Guid.NewGuid().ToString();

                for ( int i = 0; i < 1; i++ )
                {
                    sb.Append( "$" ); //Protocol Header
                    sb.Append( "005" ); //Operation length
                    sb.Append( "LogIn" ); //Operation name
                    
                    string command = sb.ToString();

                    Player user = new Player( "test", "123qqq" );
                    byte [] Object = Utils.ObjectToBytes( user );

                    MyRequestInfo Info = new MyRequestInfo( command, sessionID, Object );

                    socket.SendTo( Info.ToData(), serverAddress );

                    //socket.ReceiveTimeout = 1000;
                    string[] res = m_Encoding.GetString( ReceiveMessage( socket, serverAddress ).ToArray() ).Split( ' ' );

                }
            }
        }

        /// <summary>
        ///  Works only when message passed filter.
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="serverAddress"></param>
        /// <returns></returns>
        private List<byte> ReceiveMessage( Socket socket, EndPoint serverAddress )
        {
            int length = 1024;
            byte[] buffer = new byte[ length ];
            int read = socket.ReceiveFrom( buffer, ref serverAddress );
            if ( read < length )
                return buffer.Take( read ).ToList();
            else
            {
                var total = buffer.ToList();
                total.AddRange( ReceiveMessage( socket, serverAddress ) );
                return total;
            }
        }
    
    }
}
