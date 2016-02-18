namespace WelStijl
{
    class Clothing
    {
        public int Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Clothing(int image, string name, int price)
        {
            Image = image;
            Name = name;
            Price = price;
        }
    }
}