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
using SanvidhanApp.Helpers;

namespace SanvidhanApp.Activities
{
    [Activity(Label = "QuizDescriptionActivity")]
    public class QuizDescriptionActivity : Activity
    {
        TextView quizTopicTextView;
        TextView descriptionTextView;
        ImageView quizImageView;
        Button startQuizButton;

        // Varibales
        string quizTopic;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.selected_topic);

            quizTopicTextView = (TextView)FindViewById(Resource.Id.quizTopicText);
            descriptionTextView = (TextView)FindViewById(Resource.Id.quizDescriptionText);
            quizImageView = (ImageView)FindViewById(Resource.Id.quizImage);
            startQuizButton = (Button)FindViewById(Resource.Id.startQuizButton);

            quizTopic = Intent.GetStringExtra("topic");
            quizTopicTextView.Text = quizTopic;
            quizImageView.SetImageResource(GetImage(quizTopic));

            //Retrieve Description
            QuizHelper quizHelper = new QuizHelper();
            descriptionTextView.Text = quizHelper.GetTopicDescription(quizTopic);
            startQuizButton.Click += StartQuizButton_Click;
        }

        private void StartQuizButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,typeof(QuizActivity));
            intent.PutExtra("topic", quizTopic);
            StartActivity(intent);
            Finish();
        }

        int GetImage(string topic)
        {
            int imageInt = 0;

            if (topic == "History")
            {
                imageInt = Resource.Drawable.history;
            }
            else if (topic == "Geography")
            {
                imageInt = Resource.Drawable.geography;
            }
            else if (topic == "Space")
            {
                imageInt = Resource.Drawable.history;
            }
            else if (topic == "Programming")
            {
                imageInt = Resource.Drawable.history;
            }
            else if (topic == "Engineering")
            {
                imageInt = Resource.Drawable.history;
            }
            else if (topic == "Business")
            {
                imageInt = Resource.Drawable.business;
            }

            return imageInt;

        }
    }
}