using Android.App;
using Android.Net;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Widget;

namespace WelStijl
{
    [Activity]
    public class ClothingDetailActivity : AppCompatActivity
    {
        private Toolbar _toolbar;
        private Clothing _clothing;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ClothingDetail);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(_toolbar);

            if (!Intent.Extras.IsEmpty)
            {
                _clothing = new Clothing(
                    Intent.GetStringExtra("image"),
                    Intent.GetStringExtra("name"), 
                    Intent.GetIntExtra("price", 0), 
                    Intent.GetStringExtra("color"), 
                    Intent.GetStringExtra("size"), 
                    Intent.GetIntExtra("gender", 0)
                    );

                SupportActionBar.Title = _clothing.Name;

                FindViewById<ImageView>(Resource.Id.image).SetImageURI(Uri.Parse(_clothing.Image));
                FindViewById<TextView>(Resource.Id.price).Text = _clothing.FormattedPrice;
                FindViewById<TextView>(Resource.Id.color).Text = _clothing.Color;
                FindViewById<TextView>(Resource.Id.size).Text = _clothing.Size;
                FindViewById<TextView>(Resource.Id.gender).Text = GetString(_clothing.Gender == 0 ? Resource.String.Male : Resource.String.Female);
            }
        }
    }
}
