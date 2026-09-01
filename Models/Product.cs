using E_commerce.Models;

namespace E_commerce.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public int? SubcategoryId { get; set; }

        public Subcategory? Subcategory { get; set; }

        public ICollection<ProductImage> Images { get; set; }
            = new List<ProductImage>();

        public ICollection<ProductReview> Reviews { get; set; }
            = new List<ProductReview>();

        public ICollection<Cart> CartItems { get; set; }
            = new List<Cart>();

        public ICollection<Wishlist> Wishlists { get; set; }
            = new List<Wishlist>();
    }
}