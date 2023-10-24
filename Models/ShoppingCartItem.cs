using BookWebEcommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace BookWebEcommerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public Book Book { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
