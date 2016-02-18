using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace WelStijl
{
    public class SearchFragment : Fragment
    {
        private RecyclerView recyclerView;
        private ClothingAdapter adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.Fragment_Search, container, false);

            recyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);

            adapter = new ClothingAdapter();

            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity, LinearLayoutManager.Vertical, false);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            return rootView;
        }
    }
}