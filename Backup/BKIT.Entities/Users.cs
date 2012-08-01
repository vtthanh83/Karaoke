using System;
using System.Collections.Generic;
using System.Text;

namespace BKIT.Entities
{
    public class Users
    {
        private int _User_ID;

        public int User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }
        private string _User_UserName;

        public string User_UserName
        {
            get { return _User_UserName; }
            set { _User_UserName = value; }
        }
        private string _User_UserPassword;

        public string User_UserPassword
        {
            get { return _User_UserPassword; }
            set { _User_UserPassword = value; }
        }

    }
    public enum Level
    {
        Admin = 1, User = 2, Guest = 3
    }
}
