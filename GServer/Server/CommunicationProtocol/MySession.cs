using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Server.CommunicationProtocol
{
    /// <summary>
    /// Вся логика сессии будет находиться здесь.
    /// </summary>
    public class MySession : AppSession<MySession, MyRequestInfo>
    {
        private int playerID;
        private int roomID;

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
        }
        public int PlayerID
        {
            get { return playerID; }
            set { playerID = value; }
        }

    }
}
