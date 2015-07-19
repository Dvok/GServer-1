using GServer.Common;
using GServer.Packages;
using GServer.Server.CommunicationProtocol;
using SuperSocket.SocketBase.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.DynamicOperations
{
    public class LogIn : CommandBase<MySession, MyRequestInfo>
    {
        public override void ExecuteCommand( MySession session, MyRequestInfo requestInfo )
        {

            Player user = Utils.BytesToObject<Player>( requestInfo.PackageObject );
            //TODO: Логика авторизации.
            session.Send( session.SessionID + " " + session.RoomID );
        }
    }
}
