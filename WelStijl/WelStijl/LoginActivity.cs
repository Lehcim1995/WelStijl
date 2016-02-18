using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Widget;

namespace WelStijl
{
    [Activity(Label = "Login")]
    public class LoginActivity : Activity
    {
        private ISharedPreferences prefs;

        private Button btnLogin;
        private TextView tvwUserName;
        private EditText pwdPassword;
        private TextView tvwMessage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            prefs = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            tvwUserName = FindViewById<TextView>(Resource.Id.tvwUserName);
            pwdPassword = FindViewById<EditText>(Resource.Id.pwdPassword);
            tvwMessage = FindViewById<TextView>(Resource.Id.tvwMessage);

            btnLogin.Click += btnLoginClick;
        }

        private void btnLoginClick(object sender, EventArgs args)
        {
            if (tvwUserName.Text == "" || pwdPassword.Text == "")
            {
                tvwMessage.Visibility = ViewStates.Visible;
                tvwMessage.Text = "Vul alstublieft zowel het gebruikersnaam als wachtwoord veld in.";
                return;
            }

            if (tvwUserName.Text != pwdPassword.Text)
            {
                tvwMessage.Visibility = ViewStates.Visible;
                tvwMessage.Text = "Gebruikersnaam of wachtwoord onjuist.";
                return;
            }

            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutBoolean("loggedIn", true);
            editor.Apply();
            StartActivity(typeof(MainActivity));
        }
    }
}