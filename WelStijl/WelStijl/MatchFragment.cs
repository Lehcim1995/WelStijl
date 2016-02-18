using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Graphics;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace WelStijl
{
    public class MatchFragment : Fragment, View.IOnClickListener
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.Fragment_Match, container, false);
            LinearLayout lloMatch = rootView.FindViewById<LinearLayout>(Resource.Id.lloMatch);

            int i = 0;

            while (i < 3)
            {
                RectangleShape rect;

                if (i == 0)
                {
                    rect = new RectangleShape(Application.Context, Color.Blue);
                }

                else
                {
                    rect = new RectangleShape(Application.Context, Color.Red);
                }

                WindowManagerLayoutParams layoutParams = new WindowManagerLayoutParams();
                layoutParams.Width = WindowManagerLayoutParams.MatchParent;
                layoutParams.Height = 100;
                lloMatch.AddView(rect, layoutParams);
                rect.Id = i;
                rect.SetOnClickListener(this);
                i++;
            }


            return rootView;
        }


        public void OnClick(View v)
        {
            switch (v.Id)
            {
                case 0:
                    Toast.MakeText(Activity, "Blauw", ToastLength.Short).Show();
                    break;
                case 1:
                    Toast.MakeText(Activity, "Rood 1", ToastLength.Short).Show();
                    break;
                case 2:
                    Toast.MakeText(Activity, "Rood 2", ToastLength.Short).Show();
                    break;
            }
        }
    }
}