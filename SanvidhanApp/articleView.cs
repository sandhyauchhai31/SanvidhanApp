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
    [Activity(Label = "articleView")]
    public class articleView : Activity
    {
        ListView myList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.articleView);

            myList = FindViewById<ListView>(Resource.Id.listView2);


            SectionData.Sections.Clear();
          //ArticleData.Articles.Clear();

            string name = Intent.GetStringExtra("Name");

            //  Read the contents of our asset
            string content;
            AssetManager assets = this.Assets;
            using (StreamReader sr = new StreamReader(assets.Open("" + name + ".txt")))
            {
                content = sr.ReadToEnd();
            }
            string[] strArr = content.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            foreach (string str in strArr)
            {
                SectionData.Sections.Add(new Section()
                {
                    ID = i,
                    Part = str.Split('|')[0].ToString(), //"भाग" + " " + i.ToString(),
                    Title = "Xamarin Android ",
                    ArticleID = str.Split('|')[1].Trim()
                }) ;

                i++; 
            }
            myList.Adapter = new MyCustomListAdapter(SectionData.Sections);
            myList.ItemClick += MyList_ItemClick;
        }

        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent i = new Intent(this, typeof(article1));
            i.PutExtra("Name", SectionData.Sections[e.Position].ArticleID.ToString());
            StartActivity(i);
        }
    }
}