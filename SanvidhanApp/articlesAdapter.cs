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
using Xamarin.Essentials;

namespace SanvidhanApp
{
    class articlesAdapter : BaseAdapter<Section>
    {
        List<Section> sections;


        public articlesAdapter(List<Section> sections)
        {
            this.sections = sections;
        }

        public override int Count
        {
            get { return sections.Count; }
        }

        public override Section this[int position]
        {
            get { return sections[position]; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;


            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.sectionRow, parent, false);


                var part = view.FindViewById<TextView>(Resource.Id.partTextView);
                var title = view.FindViewById<TextView>(Resource.Id.titleTextView);

                view.Tag = new ViewHolder() { Part = part, Title = title };
            }

            var holder = (ViewHolder)view.Tag;


            holder.Part.Text = sections[position].Part;
            holder.Title.Text = sections[position].Title;


            return view;
        }

    }

    internal class ArticleViewHolder1 : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}