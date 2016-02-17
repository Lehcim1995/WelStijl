using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Widget;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace WelStijl
{
    [Activity(Label = "WelStijl", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        private Toolbar toolbar;
        private ViewPager viewPager;
        private TabLayout tabLayout;
        private ViewPagerAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

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
