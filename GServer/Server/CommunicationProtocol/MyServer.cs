using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Logging;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    public class MyServer: AppServer<MySession, MyRequestInfo> , MySetup
    {
        public MyServer()
            : base( new DefaultReceiveFilterFactory<MyRequestFilter, MyRequestInfo>() )
        {

        }

        void MySetup.Setup( IRootConfig rootConfig, IServerConfig serverConfig )
        {
            base.Setup( rootConfig, serverConfig, null, null, new ConsoleLogFactory(), null );
        }

    }
}
