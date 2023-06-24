using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Login
    {

        public Login(string user, string passWord)
        {
            userName = user;
            password = passWord;
        }
        public string userName { get; set; }
        public string password { get; set; }
    }
}
