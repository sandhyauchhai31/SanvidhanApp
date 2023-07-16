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
    public class Sanvidhan
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Acc_Name { get; set; }
        public string Acc_Phone { get; set; }
        public string Acc_Email { get; set; }
        public string Acc_Pass { get; set; }
    }
    public class Sanvidhan1
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Acc_ID { get; set; }
        public string Acc_SchoolName { get; set; }
        public string Acc_SSC { get; set; }
        public string Acc_HSC { get; set; }

    }
}