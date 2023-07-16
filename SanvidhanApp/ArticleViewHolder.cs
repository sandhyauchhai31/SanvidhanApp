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
    public class ArticleViewHolder : Java.Lang.Object
    {
        public TextView ArticleNo { get; set; }
        public TextView Title { get; set; }
    }
}