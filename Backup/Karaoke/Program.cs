using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BKIT.Entities;
namespace Karaoke
{
    static class Program
    {
        /// <summary>
        public static bool isLogin = false;
        public static Level userLevel = Level.Guest;
        public static string username = "Guest";
        public static string password = "123";
        public static int IDNhanvien = -1;
        /// The main entry point for the application.
        /// 
        /// </summary>
        /// 
        [STAThread]      
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
