using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WelStijl
{
    class ClothingViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ImageView { get; private set; }
        public TextView NameView { get; private set; }
        public TextView PriceView { get; private set; }

        public ClothingViewHolder(View itemView) : base(itemView)
        {
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.image);
            NameView = itemView.FindViewById<TextView>(Resource.Id.name);
            PriceView = itemView.FindViewById<TextView>(Resource.Id.price);
        }
    }
}