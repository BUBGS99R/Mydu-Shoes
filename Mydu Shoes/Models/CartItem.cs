

namespace Mydu_Shoes.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
       

        public products Product { get; set; }
    }
}
