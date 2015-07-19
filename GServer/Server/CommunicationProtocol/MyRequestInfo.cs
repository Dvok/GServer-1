using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    public class MyRequestInfo : IRequestInfo
    {
        private string key;
        private int playerId;
        public string Key
        {
            get { return key; }
            private set { key = value; }
        }
        public int PlayerId
        {
            get { return playerId; }
            set { playerId = value; }
        }

        public MyRequestInfo( string Key, int PlayedId )
        {
            this.Key = Key;
            this.PlayerId = PlayedId;
        }

        public byte[] ToData()
        {
            List<byte> data = new List<byte>();

            data.AddRange( Encoding.ASCII.GetBytes( Key ) );
            data.AddRange( Encoding.ASCII.GetBytes( PlayerId.ToString() ) );

            int expectedLen = 36 + 4;
            int maxLen = expectedLen - data.Count;

            if ( maxLen > 0 )
            {
                for ( var i = 0; i < maxLen; i++ )
                {
                    data.Add( 0x00 );
                }
            }

            //data.AddRange( Encoding.UTF8.GetBytes( Value ) );

            return data.ToArray();
        }

    }
}
