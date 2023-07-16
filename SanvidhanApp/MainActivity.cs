using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using System.Linq;

namespace SanvidhanApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
        Button BtnLogin, BtnSignUp;
        EditText TxtId, TxtPass;
        Connectiondb c = new Connectiondb();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "संविधान";

            c.con();
            c.db.CreateTable<Sanvidhan>();
            c.db.CreateTable<Sanvidhan1>();

            BtnLogin = FindViewById<Button>(Resource.Id.BtnLogin);
            BtnSignUp = FindViewById<Button>(Resource.Id.BtnSignUp);

            TxtId = FindViewById<EditText>(Resource.Id.TxtId);
            TxtPass = FindViewById<EditText>(Resource.Id.TxtPass);

            BtnLogin.Click += BtnLogin_Click;
            BtnSignUp.Click += BtnSignUp_Click;

        }

        private void BtnSignUp_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(sign_up_layout));
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if ((TxtId.Text != "") && (TxtPass.Text != ""))
            {
                //Acc_Phone="+TxtId.Text+" and
                var user_date = c.db.Query<Sanvidhan>("SELECT * FROM Sanvidhan where Acc_Phone='" + TxtId.Text + "' and Acc_Pass='" + TxtPass.Text + "'");
                int user_count = user_date.Count();
                var data1 = user_date.ToList();
                if (user_count > 0)
                {
                    Global.UserId = data1[0].ID;
                    StartActivity(typeof(dashboard));
                }
            }
            
        }
    }
}