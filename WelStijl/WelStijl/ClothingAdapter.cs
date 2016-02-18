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