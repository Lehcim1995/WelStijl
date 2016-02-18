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
        private readonly List<Clothing> _clothing = new List<Clothing>(new []
        {
            // Jongens kleding
            new Clothing("j-2-jas-zwart-wit.jpg", "Jas Zwart Wit", 2695, ClothingColor.Zwart, "56, 62, 68, 74", 0),
            new Clothing("j-2-pyama-grijs.jpg", "Pyjama Grijs", 1695, ClothingColor.Grijs, "86/92", 0),
            new Clothing("j-2-pyama-zwart-wit.jpg", "Pyjama Zwart Wit", 1095, ClothingColor.Zwart, "86, 92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152", 0),
            new Clothing("j-2-schoen-zwart-groen.jpg", "Schoen Zwart Groen", 6495, ClothingColor.Groen, "35.5, 36, 36.5, 37.5, 38, 38.5, 39, 40", 0),
            new Clothing("j-2-shirt-geel-blauw.jpg", "Shirt Geel Blauw", 995, ClothingColor.Geel, "8, 104, 110, 116", 0),
            new Clothing("j-badjas-lichtblauw.jpg", "Badjas Lichtblauw", 2995, ClothingColor.Blauw, "98/104, 110/116, 122/128", 0),
            new Clothing("j-broek-blauw-2.jpg", "Broek Blauw", 2195, ClothingColor.Blauw, "92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152, 158, 164", 0),
            new Clothing("j-broek-blauw-3.jpg", "Broek Blauw", 12995, ClothingColor.Blauw, "104, 116, 128, 140, 152, 164", 0),
            new Clothing("j-broek-blauw.jpg", "Broek Blauw", 4495, ClothingColor.Blauw, "98, 104, 116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-bruin.jpg", "Broek Bruin", 4495, ClothingColor.Bruin, "128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-zwart-2.jpg", "Broek Zwart", 3995, ClothingColor.Zwart, "110, 116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-broek-zwart.jpg", "Broek Zwart", 5995, ClothingColor.Zwart, "116/128, 128/140, 140/152, 152/158, 158/170", 0),
            new Clothing("j-jas-blauw.jpg", "Jas Blauw", 5995, ClothingColor.Blauw, "116, 128, 140, 152, 164", 0),
            new Clothing("j-schoen-grijs.jpg", "Schoen Grijs", 4995, ClothingColor.Grijs, "31 - 40", 0),
            new Clothing("j-shirt-blauw.jpg", "Shirt Blauw", 3995, ClothingColor.Blauw, "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-bruin.jpg", "Shirt Bruin", 3995, ClothingColor.Bruin, "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-rood.jpg", "Shirt Rood", 3995, ClothingColor.Rood, "134/140, 146/152, 164/170", 0),
            new Clothing("j-shirt-zwart.jpg", "Shirt Zwart", 1295, ClothingColor.Zwart, "110, 116/122, 128-134, 140/146, 152/158, 164-176", 0),
            new Clothing("j-trui-blauw.jpg", "Trui Blauw", 3495, ClothingColor.Blauw, "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-trui-geel.jpg", "Trui Geel", 4995, ClothingColor.Geel, "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-trui-grijs.jpg", "Trui Grijs", 2995, ClothingColor.Grijs, "128, 140, 152, 164", 0),
            new Clothing("j-trui-wit.jpg", "Trui Wit", 4495, ClothingColor.Wit, "116, 122, 128, 134/140, 146/152, 158/164, 170/176", 0),
            new Clothing("j-vest-blauw.jpg", "Vest Blauw", 2895, ClothingColor.Blauw, "116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 0),
            new Clothing("j-vest-bruin.jpg", "Vest Bruin", 3995, ClothingColor.Bruin, "116, 128, 140, 152, 164, 176", 0),
            new Clothing("j-vest-grijs.jpg", "Vest Grijs", 1995, ClothingColor.Grijs, "110, 116, 122/128, 134/140, 146/152, 158/164", 0), 

            // Meisjes kleding
            new Clothing("m-jurk-roze.jpg", "Jurk roze", 3995, ClothingColor.Violet, "104, 110, 116, 122, 128, 134, 140, 146, 152, 158", 1),
            new Clothing("m-schoen-zwart.jpg", "Schoen zwart", 9995, ClothingColor.Zwart, "28, 29, 30, 31, 32, 33, 34, 35, 36", 1),
            new Clothing("m-jurk-rood.jpg", "Jurk rood", 3495, ClothingColor.Rood, "98/104, 110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-2-schoen-groen-wit.jpg", "Schoen groen wit", 3995, ClothingColor.Groen, "28, 29, 30, 31, 32, 33, 34", 1),
            new Clothing("m-2-rok-zwart-wit.jpg", "Rok Zwart Wit", 4995, ClothingColor.Zwart, "110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-rok-blauw.jpg", "Rok blauw", 1395, ClothingColor.Blauw, "128, 140, 152, 164", 1),
            new Clothing("m-broek-grijs.jpg", "Broek grijs", 2995, ClothingColor.Grijs, "140, 146, 152, 158, 164, 170, 176", 1),
            new Clothing("m-shirt-rood.jpg", "Shirt violet", 895, ClothingColor.Violet, "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-shirt-groen.jpg", "Shirt groen", 895, ClothingColor.Groen, "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-broek-blauw.jpg", "Broek blauw", 4995, ClothingColor.Blauw, "98, 104, 110, 116, 128, 140, 152, 164, 176", 1),
            new Clothing("m-2-broek-blauw-wit.jpg", "Broek blauw wit", 2495, ClothingColor.Blauw, "104/110, 116/122, 128/134, 140/146, 152/158, 164/170", 1),
            new Clothing("m-broek-grijs-2.jpg", "Broek grijs", 4595, ClothingColor.Grijs, "128, 134, 140, 146, 152, 158, 164, 170, 176", 1),
            new Clothing("m-2-broek-blauw-wit-2.jpg", "Broek blauw wit", 3295, ClothingColor.Blauw, "110, 116, 122, 128, 134, 140, 146, 152, 158, 164", 1),
            new Clothing("m-broek-rood-wit.jpg", "Broek rood wit", 1295, ClothingColor.Rood, "56, 62, 68, 74", 1),
            new Clothing("m-broek-blauw-2.jpg", "Broek blauw", 2995, ClothingColor.Blauw, "92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152, 158, 164 ", 1),
            new Clothing("m-shirt-groen-2.jpg", "Shirt groen", 1195, ClothingColor.Groen, "98/104, 110/116, , 122/128, 134/140, 146/152, 158/164, 170/176", 1),
            new Clothing("m-2-shirt-zwart-wit.jpg", "Shirt zwart wit", 1095, ClothingColor.Zwart, "92, 98, 104, 110, 116, 122, 128", 1),
            new Clothing("m-shirt-oranje.jpg", "Shirt oranje", 995, ClothingColor.Oranje, "122/128, 134/140, 146/152, 158/164, 170/176", 1),
            new Clothing("m-shirt-wit-blauw.jpg", "Shirt wit blauw", 2395, ClothingColor.Wit, "98, 104, 110, 116, 122, 128, 134", 1),
            new Clothing("m-shirt-wit.jpg", "Shirt wit", 995, ClothingColor.Wit, "134, 140/146, 152/158, 164/170", 1),
            new Clothing("m-shirt-bruin.jpg", "Shirt bruin", 1595, ClothingColor.Bruin, "116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-trui-groen.jpg", "Trui groen", 3995, ClothingColor.Groen, "98/104, 110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-trui-zwart.jpg", "Trui zwart", 1695, ClothingColor.Zwart, "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-trui-grijs.jpg", "Trui grijs", 3295, ClothingColor.Grijs, "56, 62, 68, 74", 1),
        }); 

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ClothingViewHolder vh = holder as ClothingViewHolder;

            Clothing item = _clothing[position];

            if (vh != null)
            {
                vh.Clothing = item;

                try
                {
                    Stream stream = vh.ItemView.Context.Assets.Open(item.Image);
                    Drawable d = Drawable.CreateFromStream(stream, null);
                    stream.Close();

                    vh.ImageView.SetImageDrawable(d);

                    d.Dispose();
                }
                catch (FileNotFoundException)
                {
                    vh.ImageView.SetImageResource(Resource.Drawable.ic_notification_sync_problem);
                }

                vh.NameView.Text = item.Name;
                vh.PriceView.Text = item.FormattedPrice;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ClothingCardView, parent, false);

            ClothingViewHolder vh = new ClothingViewHolder(itemView);
            return vh;
        }

        public override int ItemCount => _clothing.Count;
    }
}