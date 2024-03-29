using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace WelStijl
{
    class ClothingViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
    {
        public ImageView ImageView { get; private set; }
        public TextView NameView { get; private set; }
        public TextView PriceView { get; private set; }

        public Clothing Clothing { get; set; }

        public ClothingViewHolder(View itemView) : base(itemView)
        {
            ImageView = itemView.FindViewById<ImageView>(Resource.Id.image);
            NameView = itemView.FindViewById<TextView>(Resource.Id.name);
            PriceView = itemView.FindViewById<TextView>(Resource.Id.price);

            itemView.SetOnClickListener(this);
        }

        public void OnClick(View v)
        {
            Intent intent = new Intent(v.Context, typeof (ClothingDetailActivity));
            intent.PutExtra("image", Clothing.Image);
            intent.PutExtra("name", Clothing.Name);
            intent.PutExtra("price", Clothing.Price);
            intent.PutExtra("color", Clothing.Color.ToString());
            intent.PutExtra("size", Clothing.Size);
            intent.PutExtra("gender", Clothing.Gender);
            v.Context.StartActivity(intent);
        }
    }
}