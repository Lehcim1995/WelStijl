using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Java.IO;
using Environment = Android.OS.Environment;
using Fragment = Android.Support.V4.App.Fragment;
using Uri = Android.Net.Uri;

namespace WelStijl
{
    [Activity(ScreenOrientation = ScreenOrientation.Portrait)]
    public class MyClothesFragment : Fragment
    {
        private ImageView _imageView;
        private View rootView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            rootView = inflater.Inflate(Resource.Layout.Fragment_MyClothes, container, false);


            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                Button button = rootView.FindViewById<Button>(Resource.Id.TakePicture);
                _imageView = rootView.FindViewById<ImageView>(Resource.Id.imageView1);
                button.Click += TakeAPicture;
            }

            return rootView;
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                Activity.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                Toast.MakeText(Activity, "Je mobiel is kut", ToastLength.Short).Show();
            }
            else
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));

                Activity.StartActivityFromFragment(this, intent, 0);
            }
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            Toast.MakeText(Activity, "Gelukt", ToastLength.Short).Show();
            //OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            Activity.SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display.
            // Loading the full sized image will consume to much memory
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            App.bitmap = LoadAndResizeBitmap(App._file.Path, width, height);
            if (App.bitmap != null)
            {
                Toast.MakeText(Activity, "Plaatje?", ToastLength.Short).Show();
                _imageView.SetImageBitmap(App.bitmap);
                App.bitmap = null;
            }

            // Dispose of the Java side bitmap.
            GC.Collect();
        }

        private static Bitmap LoadAndResizeBitmap(string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options {InJustDecodeBounds = true};
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                    ? outHeight/height
                    : outWidth/width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }

        private static class App
        {
            public static File _file;
            public static File _dir;
            public static Bitmap bitmap;
        }
    }
}