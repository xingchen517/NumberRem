using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity(Label = "App1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private EditText txtChoosNum = null;
        private EditText txtShowImg = null;
        private CheckBox ckIsEven = null;
        private string valToRember = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            txtChoosNum = FindViewById<EditText>(Resource.Id.txtChooseNumber);
            txtShowImg = FindViewById<EditText>(Resource.Id.txtShowImg);
            ckIsEven = FindViewById<CheckBox>(Resource.Id.ckbxEven);


            NumberPicker picker = FindViewById<NumberPicker>(Resource.Id.numberPicker1);
            picker.ValueChanged += Picker_ValueChanged;
            picker.MinValue = 1;            
            picker.MaxValue = 100;            
            picker.WrapSelectorWheel = true;
            

            Button btnRefreshImg = FindViewById<Button>(Resource.Id.btnRefreshImg);
            btnRefreshImg.Click += BtnRefreshImg_Click;

            Button btnClear = FindViewById<Button>(Resource.Id.btnStopShow);
            btnClear.Click += BtnClear_Click;

            Button btnVerify = FindViewById<Button>(Resource.Id.btnVerify);
            btnVerify.Click += BtnVerify_Click;
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            if(txtChoosNum.Text==valToRember)
            {
                txtShowImg.Text = "Success, you got it!";
            }
            else
            {
                txtShowImg.Text = "Sorry, you need to retry!";
                txtChoosNum.Text = valToRember;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            valToRember = txtChoosNum.Text;
            txtChoosNum.Text = "";
        }

        private void BtnRefreshImg_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtChoosNum.Text))
            {
                txtShowImg.Text = ImaginationModel.GetImages(txtChoosNum.Text, ckIsEven.Checked);
            }
        }

        private void Picker_ValueChanged(object sender, NumberPicker.ValueChangeEventArgs e)
        {
            txtChoosNum.Text = RandomGenerator.GetLongNumber(e.NewVal);
        }



    }
}

