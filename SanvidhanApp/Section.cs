using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanvidhanApp
{
    public class Section
    {
        public int ID { get; set; }
        public string Part { get; set; }

        public string Title { get; set; }

        public string ArticleID { get; set; }

        public override string ToString()
        {
            return ID + " " + Part + " " + Title + " "+ ArticleID;
        }
    }
}