using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    public class MyRequestInfo : UdpRequestInfo
    {
        private byte[] packageObject;

        public byte[] PackageObject
        {
            get { return packageObject; }
            set { packageObject = value; }
        }

        public MyRequestInfo( string Key, string SessionID, byte[] Object )
            : base( Key, SessionID )
        {
            this.PackageObject = Object;
        }

        public byte[] ToData()
        {
            List<byte> data = new List<byte>();

            data.AddRange( Encoding.ASCII.GetBytes( Key ) );
            data.AddRange( Encoding.ASCII.GetBytes( SessionID ) );
            data.AddRange( packageObject );

            int expectedLen = 36 + Key.Length + packageObject.Length;
            int maxLen = expectedLen - data.Count;

            if ( maxLen > 0 )
            {
                for ( var i = 0; i < maxLen; i++ )
                {
                    data.Add( 0x00 );
                }
            }

            return data.ToArray();
        }

    }
}
