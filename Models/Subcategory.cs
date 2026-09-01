using E_commerce.Models;

namespace E_commerce.Models
{
 

    public class Subcategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}