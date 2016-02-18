using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;

namespace WelStijl
{
    public class MatchFragment : Fragment, View.IOnClickListener
    {
        private String[] _colors = new[] {"Geel", "Geelgroen", "Groen", "Blauwgroen", "Blauw", "Blauwviolet", "Violet", "Roodviolet", "Rood", "Oranjerood", "Oranje", "Geeloranje", "Wit", "Lichtgrijs", "Grijs", "Donkergrijs", "Zwart", "Bruin"};
        private View _rootView;
        private int _lastClickedColorId;
        private RecyclerView recyclerView;
        private ClothingAdapter adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _rootView = inflater.Inflate(Resource.Layout.Fragment_Match, container, false);
            LinearLayout lloMatchColors = _rootView.FindViewById<LinearLayout>(Resource.Id.lloMatchColors);

            int i = 0;

            while (i < 3)
            {
                RectangleShape rect;

                if (i == 0)
                {
                    rect = new RectangleShape(Application.Context, Color.Black);
                }

                else
                {
                    rect = new RectangleShape(Application.Context, Color.Black);
                    rect.Visibility = ViewStates.Invisible;
                }

                WindowManagerLayoutParams layoutParams = new WindowManagerLayoutParams();
                layoutParams.Width = WindowManagerLayoutParams.MatchParent;
                layoutParams.Height = 200;
                lloMatchColors.AddView(rect, layoutParams);
                rect.Id = i;
                rect.SetPaddingRelative(-10, 0, 0, 0);
                rect.SetOnClickListener(this);
                i++;
            }

            recyclerView = _rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            adapter = new ClothingAdapter();

            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            return _rootView;
        }


        public void OnClick(View v)
        {
            _lastClickedColorId = v.Id;

            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetTitle("Kies een kleur.");
            builder.SetItems(_colors, OnColorClick);
            Dialog dialog = builder.Create();
            dialog.Show();
        }

        private void OnColorClick(object sender, DialogClickEventArgs args)
        {
            RectangleShape rectangle = _rootView.FindViewById<RectangleShape>(_lastClickedColorId);
            Color color;


            switch (_lastClickedColorId) 
            {
                case 0:
                    _rootView.FindViewById<RectangleShape>(1).Visibility = ViewStates.Visible;
                    break;

                case 1:
                    _rootView.FindViewById<RectangleShape>(2).Visibility = ViewStates.Visible;
                    break;
            }
            
            switch(args.Which)
            {
                case 0:
                    color = Color.Yellow;
                    break;
                case 1:
                    color = Color.YellowGreen;
                    break;
                case 2:
                    color = Color.Green;
                    break;
                case 3:
                    color = Color.SeaGreen;
                    break;
                case 4:
                    color = Color.Blue;
                    break;
                case 5:
                    color = Color.BlueViolet;
                    break;
                case 6:
                    color = Color.Violet;
                    break;
                case 7:
                    color = Color.MediumVioletRed;
                    break;
                case 8:
                    color = Color.Red;
                    break;
                case 9:
                    color = Color.OrangeRed;
                    break;
                case 10:
                    color = Color.Orange;
                    break;
                case 11:
                    color = Color.DarkOrange;
                    break;
                case 12:
                    color = Color.White;
                    break;
                case 13:
                    color = Color.LightGray;
                    break;
                case 14:
                    color = Color.Gray;
                    break;
                case 15:
                    color = Color.DarkGray;
                    break;
                case 16:
                    color = Color.Black;
                    break;
                default:
                    color = Color.Brown;
                    break;
            }
            
            rectangle.setPaint(color);
        }
    }
}