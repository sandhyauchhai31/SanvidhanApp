using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanvidhanApp
{
    public class Connection
    {
        private static Connection _instance;
        public static Connection Instance
        {
            get
            {
                if (_instance == null) _instance = new Connection();
                return _instance;
            }
        }
    }
    public class Connectiondb
    {
        public string dbPath;
        public SQLiteConnection db;
        public void con()
        {
            string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "s1.db3");
            db = new SQLiteConnection(dbPath);
        }
    }
    public class Global
    {
        public static int UserId;
        public static string page_id;
    }
}