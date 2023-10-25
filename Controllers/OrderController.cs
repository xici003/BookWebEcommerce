using BookWebEcommerce.Data;
using BookWebEcommerce.Data.Cart;
using BookWebEcommerce.Data.ViewModel;
using BookWebEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookWebEcommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;

        public OrderController(ShoppingCart shoppingCart, AppDbContext context)
        {
            _shoppingCart = shoppingCart;
            _context = context;
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var items = await _context.Books.Include(a => a.Author).Include(p => p.Publisher)
                .Include(t => t.Translator).FirstOrDefaultAsync(n => n.Id == id);
            if(items != null)
            {
                _shoppingCart.AddItemToCart(items);
            }
            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var items = await _context.Books.Include(a => a.Author).Include(p => p.Publisher)
                .Include(t => t.Translator).FirstOrDefaultAsync(n => n.Id == id);
            if (items != null)
            {
                _shoppingCart.RemoveItemFromCart(items);
            }
            return RedirectToAction("ShoppingCart");
        }
    }
}
