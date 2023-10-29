using Microsoft.AspNetCore.Mvc;
using BookWebEcommerce.Models;
using BookWebEcommerce.Data;
using BookWebEcommerce.Data.Enum;

namespace BookWebEcommerce.ViewComponents
{
	public class CategoryViewComponent: ViewComponent
	{
		AppDbContext _context;
		List<BookCategory> categoryList;

		public CategoryViewComponent(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View(categoryList);
		}
	}
}
