namespace E_commerce.Models
{
    public class Orders
    {

        public int Id { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";

        public int UserId { get; set; }

        public User? User { get; set; }

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}