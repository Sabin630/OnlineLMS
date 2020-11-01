using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionProject.Models
{
    public class LoginUserModel
    {
        public int LoginUserId { get; set;}
        public string Username { get; set; }
        public string UserPassword { get; set; }
    }
}