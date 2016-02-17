using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;

namespace WelStijl
{
    [Activity(Label = "WelStijl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ISharedPreferences prefs;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Console.Out.WriteLine("Create");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            prefs = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);
        }

        protected override void OnResume()
        {
            base.OnResume();

            Console.Out.WriteLine("Resume");

            if (!prefs.GetBoolean("loggedIn", false))
            {
                StartActivity(typeof(LoginActivity));
            }
        }
    }
}
    
