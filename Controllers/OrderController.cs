using BookWebEcommerce.Data;
using BookWebEcommerce.Data.Cart;
using BookWebEcommerce.Data.Services;
using BookWebEcommerce.Data.ViewModel;
using BookWebEcommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookWebEcommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly AppDbContext _context;
        private readonly IOrdersServices _ordersServices;

        public OrderController(ShoppingCart shoppingCart, AppDbContext context, IOrdersServices ordersServices)
        {
            _shoppingCart = shoppingCart;
            _context = context;
            _ordersServices = ordersServices;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var items =await _ordersServices.GetAllOrdersAsync(userId,userRole);
            return View(items);
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
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string emailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersServices.StoreOrderAsync(items, userName, emailAddress);
            await _shoppingCart.ClearShoppingCart();
            return View("CompleteOrder");
        }


	}
}
