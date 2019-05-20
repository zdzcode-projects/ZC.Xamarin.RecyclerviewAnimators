using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;

namespace XamarinAndroidExample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        const string KEY_GRID = "GRID";


        private bool enabledGrid = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);




            FindViewById<View>(Resource.Id.btn_animator_sample).Click += MainActivity_Click;

            FindViewById<View>(Resource.Id.btn_adapter_sample).Click += MainActivity_Click1;

            FindViewById<SwitchCompat>(Resource.Id.grid).CheckedChange += MainActivity_CheckedChange;
            ////.setOnCheckedChangeListener { _, isChecked -> enabledGrid = isChecked }
        }

        private void MainActivity_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            enabledGrid = e.IsChecked;
        }

        private void MainActivity_Click1(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AdapterSampleActivity)));
        }

        private void MainActivity_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AnimatorSampleActivity)));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}