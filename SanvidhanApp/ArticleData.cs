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
    internal class ArticleData
    {
        public static List<Articlepage> Articles { get; private set; }

        static ArticleData()
        {
            var temp = new List<Articlepage>();


            //AddSection(temp);
            //AddSection(temp);
            //AddSection(temp);

            Articles = temp.OrderBy(i => i.ArticleNo).ToList();
        }
    }
}