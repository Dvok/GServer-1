using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GServer.Packages
{
    [ Serializable ]
    public class Player
    {
        private string login;
        private string password;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Player( string login, string password )
        {
            this.Login = login;
            this.Password = password;
        }

    }
}
