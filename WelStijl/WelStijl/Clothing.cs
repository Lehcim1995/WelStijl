using System;
using Android.OS;
using Java.IO;
using Java.Lang;
using Object = System.Object;

namespace WelStijl
{
    class Clothing
    {
        public int Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }
        public int Gender { get; set; }

        public string FormattedPrice => (Price/100m).ToString("C2");

        public Clothing(int image, string name, int price, string color, string size, int gender)
        {
            Image = image;
            Name = name;
            Price = price;
            Color = color;
            Size = size;
            Gender = gender;
        }
    }
}