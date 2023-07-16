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
using System.IO;
using Android.Content.Res;
using SanvidhanApp.Activities;

namespace SanvidhanApp
{
    [Activity(Label = "dashboard")]
    public class dashboard : Activity
    {
        LinearLayout articleLayout, quizLayout, profileLayout, contestLayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.dashboard);

            articleLayout = FindViewById<LinearLayout>(Resource.Id.articleLayout);
            quizLayout = FindViewById<LinearLayout>(Resource.Id.quizLayout);
            profileLayout = FindViewById<LinearLayout>(Resource.Id.profileLayout);
            contestLayout = FindViewById<LinearLayout>(Resource.Id.contestLayout);

            articleLayout.Click += ArticleLayout_Click;
            quizLayout.Click += QuizLayout_Click;
            profileLayout.Click += ProfileLayout_Click;
            contestLayout.Click += ContestLayout_Click;
        }

        private void ContestLayout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(contestActivity));
        }

        private void ProfileLayout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(profile_layout));
        }

        private void QuizLayout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(QuizTopicMain));
        }

        private void ArticleLayout_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(sectionView));
        }
    }
}