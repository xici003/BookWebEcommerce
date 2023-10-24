using System.ComponentModel.DataAnnotations;

namespace BookWebEcommerce.Models
{
    public class Order
    {
        [Key] 
        public int Id { get; set; }

        public string UserId { get; set; }
        public string Email { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
