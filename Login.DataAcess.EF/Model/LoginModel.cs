using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.DataAccess.EF.Model
{
    public class LoginModel
    {
        public int LoginID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsLoginSuccessful { get; set; }

        public LoginModel(int loginId, string username, string password)
        {
            LoginID = loginId;
            UserName = username;
            Password = password;
        }
        public LoginModel(string username, string password)
        {
            UserName = username;
            Password = password;
        }

        public LoginModel()
        {

        }

    }
}