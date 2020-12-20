using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using User_System_Test_App.Models;

namespace User_System_Test_App.ViewModel
{
    public class UsersViewModel
    {
        public int Selected { get; set; }
        public List<UserModel> Users { get; set; }
    }
}