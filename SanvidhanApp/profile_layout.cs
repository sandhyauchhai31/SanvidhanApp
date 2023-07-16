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
    [Activity(Label = "profile_layout")]
    public class profile_layout : Activity
    {
        Button BtnSave;
        EditText TxtName, TxtPhone, TxtEmail, TxtPass1, TxtPass2, TxtSchoolName, TxtSSC, TxtHSC;
        Connectiondb c = new Connectiondb();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            c.con();
            SetContentView(Resource.Layout.profile_layout);

            BtnSave = FindViewById<Button>(Resource.Id.BtnSave);
            TxtName = FindViewById<EditText>(Resource.Id.TxtName);
            TxtPhone = FindViewById<EditText>(Resource.Id.TxtPhone);
            TxtEmail = FindViewById<EditText>(Resource.Id.TxtEmail);
            TxtPass1 = FindViewById<EditText>(Resource.Id.TxtPass1);
            TxtPass2 = FindViewById<EditText>(Resource.Id.TxtPass2);

            TxtSchoolName = FindViewById<EditText>(Resource.Id.TxtSchool);
            TxtSSC = FindViewById<EditText>(Resource.Id.TxtSSC);
            TxtHSC = FindViewById<EditText>(Resource.Id.TxtHSC);

            var user_date = c.db.Query<Sanvidhan>("SELECT * FROM Sanvidhan where ID=" + Global.UserId.ToString() + "");
            var data = user_date.ToList();

            TxtName.Text = data[0].Acc_Name;
            TxtPhone.Text = data[0].Acc_Phone;
            TxtEmail.Text = data[0].Acc_Email;
            TxtPass1.Text = data[0].Acc_Pass;


            try
            {
                //SELECT * FROM Sanvidhan1 where ID=" + Global.UserId.ToString() + "
                var user_date1 = c.db.Query<Sanvidhan1>("SELECT * FROM Sanvidhan1 WHERE Acc_Id =" + Global.UserId.ToString() + "");
                var data1 = user_date1.ToList();
                TxtSchoolName.Text = data1[0].Acc_SchoolName;

                TxtSSC.Text = data1[0].Acc_SSC;
                TxtHSC.Text = data1[0].Acc_HSC;
            }
            catch
            {
                TxtSchoolName.Text = "";
                TxtSSC.Text = "";
                TxtHSC.Text = "";
            }

            BtnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if ((TxtName != null) && (TxtPhone != null) && (TxtEmail.Text != null) && (TxtSSC != null) && (TxtSchoolName != null) && (TxtHSC.Text != null))
            {
                try
                {
                    var user_date1 = c.db.Query<Sanvidhan1>("SELECT * FROM Sanvidhan1 WHERE Acc_Id =" + Global.UserId.ToString() + "");
                    var data1 = user_date1.ToList();
                    //Toast.MakeText(this, "Record is already present"+ data1.Count+"...", ToastLength.Long).Show();
                    if (data1.Count > 0)
                    {
                        var user_date2 = c.db.ExecuteScalar<Sanvidhan1>("UPDATE Sanvidhan1 SET Acc_SchoolName = ?, Acc_SSC = ? , Acc_HSC = ? WHERE Acc_ID = ?", TxtSchoolName.Text, TxtSSC.Text, TxtHSC.Text, Global.UserId.ToString());
                    }
                    else
                    {
                        //Toast.MakeText(this, "Record is already present", ToastLength.Long).Show();
                        Sanvidhan1 sn1 = new Sanvidhan1();
                        sn1.Acc_ID = Global.UserId;
                        sn1.Acc_SchoolName = TxtSchoolName.Text;
                        sn1.Acc_SSC = TxtSSC.Text;
                        sn1.Acc_HSC = TxtHSC.Text;
                        c.db.Insert(sn1);
                    }
                }

                finally
                {
                    var user_date = c.db.ExecuteScalar<Sanvidhan>("UPDATE Sanvidhan SET Acc_Name = ?, Acc_Phone = ? WHERE ID = ?", TxtName.Text, TxtPhone.Text, Global.UserId.ToString());
                    Toast.MakeText(this, "Record Update Successfully.", ToastLength.Long).Show();
                }

            }
            else
            {
                Toast.MakeText(this, "Please fill all fields...!!!", ToastLength.Long).Show();
            }
        }
    }
}