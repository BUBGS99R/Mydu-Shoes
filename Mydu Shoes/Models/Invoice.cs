namespace Mydu_Shoes.Models
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation property
        public List<OrderDetail> Items { get; set; }
    }
}
