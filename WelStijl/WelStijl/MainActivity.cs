using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Preferences;
using String = Java.Lang.String;

namespace WelStijl
{
    [Activity(Label = "WelStijl", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        private ViewPager viewPager;
        private TabLayout tabLayout;
        private ViewPagerAdapter adapter;
        private ISharedPreferences prefs;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Console.Out.WriteLine("Create");
            prefs = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            SetupViewPager();

            tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(viewPager);
        }

        private void SetupViewPager()
        {
            adapter = new ViewPagerAdapter(SupportFragmentManager);
            adapter.AddFragment(Fragment.Instantiate(this, Class.FromType(typeof(SearchFragment)).Name), Resources.GetString(Resource.String.FragmentSearch));
            adapter.AddFragment(Fragment.Instantiate(this, Class.FromType(typeof(MatchFragment)).Name), Resources.GetString(Resource.String.FragmentMatch));
            adapter.AddFragment(Fragment.Instantiate(this, Class.FromType(typeof(DesignFragment)).Name), Resources.GetString(Resource.String.FragmentDesign));
            adapter.AddFragment(Fragment.Instantiate(this, Class.FromType(typeof(MyClothesFragment)).Name), Resources.GetString(Resource.String.FragmentMyClothes));
            viewPager.Adapter = adapter;
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


        class ViewPagerAdapter : FragmentPagerAdapter
        {
            private readonly List<Fragment> fragments = new List<Fragment>();
            private readonly List<string> fragmentTitles = new List<string>();

            public ViewPagerAdapter(FragmentManager fragmentManager) : base(fragmentManager)
            {
                
    }

            public override Fragment GetItem(int position)
            {
                return fragments[position];
}
    
            public override int Count => fragments.Count;

            public void AddFragment(Fragment fragment, string title)
            {
                fragments.Add(fragment);
                fragmentTitles.Add(title);
            }

            public override ICharSequence GetPageTitleFormatted(int position)
            {
                return new String(fragmentTitles[position]);
            }
        }
    }
}
