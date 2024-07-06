

namespace Mydu_Shoes.Models
{
    public class products
    {
        public Guid Id { get; set; }

        public string? Tensp { get; set; }

        public string? Img { get; set; }

        public decimal? gia { get; set; }

        public string? Description { get; set; }
        public string Size { get; set; }
        public Guid? CategoryId { get; set; } // Foreign key for Categories
        public Categories Category { get; set; }
    }
}
