﻿

namespace Mydu_Shoes.Models
{
    public class Categories
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<products> Products { get; set; }
    }
}
