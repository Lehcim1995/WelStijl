using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace WelStijl
{
    public class DesignFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.Fragment_Design, container, false);
        }
    }
}