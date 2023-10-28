
using BookWebEcommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebEcommerce.Data.Cart
{
    public class ShoppingCart
    {
        public  AppDbContext _context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(b => b.Book).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(b => b.Book.Price * b.Amount).Sum();
            return total;
        }

        public void AddItemToCart(Book book)
        {
            var shoppingCartItem =_context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Amount = 1,
                    Book = book
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(Book book)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
        }
        public async Task ClearShoppingCart()
        {
			var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
			_context.ShoppingCartItems.RemoveRange(items);
			await _context.SaveChangesAsync();
		}
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

    }
}
