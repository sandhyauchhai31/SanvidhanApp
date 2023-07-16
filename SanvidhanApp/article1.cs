using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SanvidhanApp
{
    [Activity(Label = "article1")]
    public class article1 : Activity
    {
        ListView myList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.article1);

            string name = Intent.GetStringExtra("Name");

          //  Read the contents of our asset
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("" + name + ".txt")))
            {
                content = sr.ReadToEnd();
            }

            TextView txtdata = FindViewById<TextView>(Resource.Id.txtdata);
            txtdata.Text = content;
              }
        
    }
}