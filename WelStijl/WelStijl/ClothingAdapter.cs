using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace WelStijl
{
    class ClothingAdapter : RecyclerView.Adapter
    {
        readonly List<Clothing> clothing = new List<Clothing>(new []
        {
            new Clothing(Resource.Drawable.Icon, "Icon", 500, "green", "M", 0),
            new Clothing(Resource.Drawable.Icon, "Other Icon", 495, "green", "L", 1),
            new Clothing(Resource.Drawable.Icon, "Same Other Icon", 490, "green", "L", 0),
            new Clothing(Resource.Drawable.Icon, "More Same Other Icon", 495, "green", "M", 1)
        }); 

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ClothingViewHolder vh = holder as ClothingViewHolder;

            Clothing item = clothing[position];

            vh.Clothing = item;

            vh.ImageView.SetImageResource(item.Image);
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