using System.Collections.Generic;
using System.IO;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using FileNotFoundException = Java.IO.FileNotFoundException;

namespace WelStijl
{
    class ClothingAdapter : RecyclerView.Adapter
    {
        static readonly List<Clothing> clothing = new List<Clothing>(new []
        {
            new Clothing("j-2-jas-zwart-wit.jpg", "Jas Zwart Wit", 2695, "zwart", "56, 62, 68, 74", 0),
            new Clothing("j-2-pyama-grijs.jpg", "Pyjama Grijs", 1695, "grijs", "86/92", 0),
            new Clothing("j-2-pyama-zwart-wit.jpg", "Pyjama Zwart Wit", 1095, "zwart", "86, 92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152", 0),
            new Clothing("j-2-schoen-zwart-groen.jpg", "Schoen Zwart Groen", 6495, "groen", "35.5, 36, 36.5, 37.5, 38, 38.5, 39, 40", 0),
            new Clothing("j-2-shirt-geel-blauw.jpg", "Shirt Geel Blauw", 995, "geel", "8, 104, 110, 116", 0),
            new Clothing("j-badjas-lichtblauw.jpg", "Badjas Lichtblauw", 2995, "lichtblauw", "98/104, 110/116, 122/128", 0),
            new Clothing("j-broek-blauw-2.jpg", "Broek Blauw", 2195, "blauw", "92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152, 158, 164", 0),
            new Clothing("j-broek-blauw-3.jpg", "Broek Blauw", 12995, "blauw", "104, 116, 128, 140, 152, 164", 0),
            new Clothing("j-broek-blauw.jpg", "Broek Blauw", 4495, "blauw", "98, 104, 116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-bruin.jpg", "Broek Bruin", 4495, "bruin", "128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-zwart-2.jpg", "Broek Zwart", 3995, "zwart", "110, 116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-zwart.jpg", "Broek Zwart", 5995, "zwart", "116/128, 128/140, 140/152, 152/158, 158/170", 0),
            new Clothing("j-jas-blauw.jpg", "Jas Blauw", 5995, "blauw", "116, 128, 140, 152, 164", 0),
            new Clothing("j-schoen-grijs.jpg", "Schoen Grijs", 4995, "grijs", "31 - 40", 0),
            new Clothing("j-shirt-blauw.jpg", "Shirt Blauw", 3995, "lichtblauw", "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-bruin.jpg", "Shirt Bruin", 3995, "bruin", "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-rood.jpg", "Shirt Rood", 3995, "rood", "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-zwart.jpg", "Shirt Zwart", 1295, "zwart", "110, 116/122, 128-134, 140/146, 152/158, 164-176", 0),
            new Clothing("j-trui-blauw.jpg", "Trui Blauw", 3495, "blauw", "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-trui-geel.jpg", "Trui Geel", 4995, "geel", "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-trui-grijs.jpg", "Trui Grijs", 2995, "grijs", "128, 140, 152, 164", 0),
            new Clothing("j-trui-wit.jpg", "Trui Wit", 4495, "wit", "116, 122, 128, 134/140, 146/152, 158/164, 170/176", 0),
            new Clothing("j-vest-blauw.jpg", "Vest Blauw", 2895, "blauw", "116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 0),
            new Clothing("j-vest-bruin.jpg", "Vest Bruin", 3995, "bruin", "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-vest-grijs.jpg", "Vest Grijs", 1995, "grijs", "110, 116, 122/128, 134/140, 146/152, 158/164", 0), 
        }); 

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ClothingViewHolder vh = holder as ClothingViewHolder;

            Clothing item = clothing[position];

            vh.Clothing = item;

            try
            {
                Stream stream = vh.ItemView.Context.Assets.Open(item.Image);
                Drawable d = Drawable.CreateFromStream(stream, null);
                stream.Close();

                vh.ImageView.SetImageDrawable(d);
            }
            catch (FileNotFoundException)
            {
                vh.ImageView.SetImageResource(Resource.Drawable.ic_notification_sync_problem);
            }

            vh.NameView.Text = item.Name;
            vh.PriceView.Text = item.FormattedPrice;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ClothingCardView, parent, false);

            ClothingViewHolder vh = new ClothingViewHolder(itemView);
            return vh;
        }

        public override int ItemCount => clothing.Count;
    }
}