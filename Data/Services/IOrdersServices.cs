using BookWebEcommerce.Models;

namespace BookWebEcommerce.Data.Services
{
	public interface IOrdersServices
	{
		public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId,string userEmailAddress);
		public Task<List<Order>> GetAllOrdersAsync(string userId, string userRole);
	}
}
