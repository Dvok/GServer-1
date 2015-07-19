using SuperSocket.SocketBase.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    interface MySetup
    {
        void Setup( IRootConfig rootConfig, IServerConfig serverConfig );
    }
}
