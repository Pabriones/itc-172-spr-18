using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Using_Data_Entities_and_Wizards.Models
{
    public class LoginClass
    {
        public LoginClass() { }
        public LoginClass (string user, string password)
        {
            UserName = user;
            PassWord = password;
        }
        public string UserName { set; get; }
        public string PassWord { set; get; }
    }
}