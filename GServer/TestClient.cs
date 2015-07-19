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
                char[] chars = new char[] { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h', 'H' };

                Random rd = new Random( 1 );

                StringBuilder sb = new StringBuilder();

                var sessionID = Guid.NewGuid().ToString();

                for ( int i = 0; i < 1; i++ )
                {
                    sb.Append( chars[ rd.Next( 0, chars.Length - 1 ) ] );
                    string command = sb.ToString();

                    Console.WriteLine( "Client prepare sent:" + command );

                    //cmdInfo.Value = command;

                    socket.SendTo( Encoding.ASCII.GetBytes( "OLOLOLO" ), serverAddress );

                    Console.WriteLine( "Client sent:" + command );

                    string[] res = m_Encoding.GetString( ReceiveMessage( socket, serverAddress ).ToArray() ).Split( ' ' );

                }
            }
        }

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
