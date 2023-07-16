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
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Xamarin.Essentials;
using static Android.Service.Voice.VoiceInteractionSession;

namespace SanvidhanApp
{
    [Activity(Label = "sectionView")]
    public class sectionView : Activity
    {
        ListView myList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.sectionView);

            myList = FindViewById<ListView>(Resource.Id.listView);



            ArticleData.Articles.Clear();

            //var resourcePrefix = "Mapper.Droid";

            //var assembly = typeof(article1).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{resourcePrefix}.SectionParts.txt");
            //string text = "";
            AssetManager assets = this.Assets;
            string content = "";
            using (StreamReader sr = new StreamReader(assets.Open("SectionParts.txt")))
            {
                content = sr.ReadToEnd();
            }
            string[] strArr = content.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.None);
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
                //if(i == 1)
                //{
                //    LayoutInflater.From().Inflate(Resource.Layout.article1, null);
                //}

            }
            myList.Adapter = new MyCustomListAdapter(SectionData.Sections);
            myList.ItemClick += MyList_ItemClick;
        }

        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           // Toast.MakeText(this, "Row Index " + SectionData.Sections [ e.Position].ID +"  " + SectionData.Sections[e.Position].Part + "  " + SectionData.Sections[e.Position].ArticleID, ToastLength.Short).Show();

            Intent i = new Intent(this, typeof(articleView)); 
            i.PutExtra("Name", SectionData.Sections[e.Position].ArticleID.ToString());
            StartActivity(i);

            
            
            
             
        }
    }
}
