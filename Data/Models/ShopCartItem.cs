namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int ID { get; set; }
        public Car Car { get; set; }
        public int Price { get; set; }
        public string ShopCartID { get; set; }
    }
}
