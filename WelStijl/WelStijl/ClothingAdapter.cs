using System.Collections.Generic;
using Android.Net;
using Android.Support.V7.Widget;
using Android.Views;

namespace WelStijl
{
    class ClothingAdapter : RecyclerView.Adapter
    {
        static readonly List<Clothing> clothing = new List<Clothing>(new []
        {
            new Clothing("file:///android_asset/j-2-jas-zwart-wit.jpg", "Jas Zwart Wit", 2695, "zwart", "56, 62, 68, 74", 0), 

            // Meisjes kleding
            new Clothing("m-jurk roze.jpg", "Jurk roze", 3995, "violet", "104, 110, 116, 122, 128, 134, 140, 146, 152, 158", 1),
            new Clothing("m-schoen zwart.jpg", "Schoen zwart", 9995, "zwart", "28, 29, 30, 31, 32, 33, 34, 35, 36", 1),
            new Clothing("m-jurk rood.jpg", "Jurk rood", 3495, "rood", "98/104, 110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-2-schoen groen wit.jpg", "Schoen groen wit", 3995, "groen", "28, 29, 30, 31, 32, 33, 34", 1),
            new Clothing("m-2-rok zwart wit.jpg", "Rok Zwart Wit", 4995, "zwart", "110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-rok blauw.jpg", "Rok blauw", 1395, "blauw", "128, 140, 152, 164", 1),
            new Clothing("m-broek grijs.jpg", "Broek grijs", 2995, "grijs", "140, 146, 152, 158, 164, 170, 176", 1),
            new Clothing("m-shirt rood.jpg", "Shirt violet", 895, "violet", "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-shirt groen.jpg", "Shirt groen", 895, "groen", "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-broek blauw.jpg", "Broek blauw", 4995, "blauw", "98, 104, 110, 116, 128, 140, 152, 164, 176", 1),
            new Clothing("m-2-broek blauw wit.jpg", "Broek blauw wit", 2495, "blauw", "104/110, 116/122, 128/134, 140/146, 152/158, 164/170", 1),
            new Clothing("m-broek grijs 2.jpg", "Broek grijs", 4595, "grijs", "128, 134, 140, 146, 152, 158, 164, 170, 176", 1),
            new Clothing("m-2-broek blauw wit 2.jpg", "Broek blauw wit", 3295, "blauw", "110, 116, 122, 128, 134, 140, 146, 152, 158, 164", 1),
            new Clothing("m-broek rood wit.jpg", "Broek rood wit", 1295, "rood", "56, 62, 68, 74", 1),
            new Clothing("m-broek blauw 2.jpg", "Broek blauw", 2995, "blauw", "92, 98, 104, 110, 116, 122, 128, 134, 140, 146, 152, 158, 164 ", 1),
            new Clothing("m-shirt groen 2.jpg", "Shirt groen", 1195, "groen", "98/104, 110/116, , 122/128, 134/140, 146/152, 158/164, 170/176", 1),
            new Clothing("m-2-shirt zwart wit.jpg", "Shirt zwart wit", 1095, "zwart", "92, 98, 104, 110, 116, 122, 128", 1),
            new Clothing("m-shirt oranje.jpg", "Shirt oranje", 995, "oranje", "122/128, 134/140, 146/152, 158/164, 170/176", 1),
            new Clothing("m-shirt wit blauw.jpg", "Shirt wit blauw", 2395, "wit", "98, 104, 110, 116, 122, 128, 134", 1),
            new Clothing("m-shirt wit.jpg", "Shirt wit", 995, "wit", "134, 140/146, 152/158, 164/170", 1),
            new Clothing("m-shirt bruin.jpg", "Shirt bruin", 1595, "bruin", "116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-trui groen.jpg", "Trui groen", 3995, "groen", "98/104, 110/116, 122/128, 134/140, 146/152, 158/164", 1),
            new Clothing("m-trui zwart.jpg", "Trui zwart", 1695, "zwart", "80, 86, 98/104, 104/110, 116/122, 128/134, 134/140, 146/152, 152/164, 164/170", 1),
            new Clothing("m-trui  grijs.jpg", "Trui grijs", 3295, "grijs", "56, 62, 68, 74", 1),
        }); 

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ClothingViewHolder vh = holder as ClothingViewHolder;

            Clothing item = clothing[position];

            vh.Clothing = item;

            vh.ImageView.SetImageURI(Uri.Parse(item.Image));
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