using BookWebEcommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace BookWebEcommerce.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
