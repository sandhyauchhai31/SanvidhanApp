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
    [Activity(Label = "sign_up_layout")]
    public class sign_up_layout : Activity
    {
        Button BtnSignUp;
        EditText TxtName, TxtPhone, TxtEmail, TxtPass1, TxtPass2;
        Connectiondb c = new Connectiondb();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.sign_up_layout);
            // Create your application here
            c.con();
            BtnSignUp = FindViewById<Button>(Resource.Id.BtnSignUp);
            TxtName = FindViewById<EditText>(Resource.Id.TxtName);
            TxtPhone = FindViewById<EditText>(Resource.Id.TxtPhone);
            TxtEmail = FindViewById<EditText>(Resource.Id.TxtEmail);
            TxtPass1 = FindViewById<EditText>(Resource.Id.TxtPass1);
            TxtPass2 = FindViewById<EditText>(Resource.Id.TxtPass2);

            BtnSignUp.Click += BtnSignUp_Click;
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            if ((TxtName.Text != "") && (TxtEmail.Text != "") && (TxtPhone.Text != "") && (TxtPass1.Text != "") && (TxtPass2.Text != "") && (TxtPass1.Text == TxtPass2.Text))
            {
                Sanvidhan sn = new Sanvidhan();
                sn.Acc_Name = TxtName.Text;
                sn.Acc_Phone = TxtPhone.Text;
                sn.Acc_Email = TxtEmail.Text;
                sn.Acc_Pass = TxtPass1.Text;
                c.db.Insert(sn);

                Toast.MakeText(this, "Account Created Successfully.", ToastLength.Long).Show();
                StartActivity(typeof(MainActivity));
            }
        }
    }
}