namespace WelStijl
{
    class Clothing
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public ClothingColor Color { get; set; }
        public string Size { get; set; }
        public int Gender { get; set; }

        public string FormattedPrice => (Price/100m).ToString("C2");

        public Clothing(string image, string name, int price, ClothingColor color, string size, int gender)
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