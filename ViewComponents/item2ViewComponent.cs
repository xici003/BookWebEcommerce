using Microsoft.AspNetCore.Mvc.ViewComponents;
using BookWebEcommerce.Models;
using BookWebEcommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookWebEcommerce.ViewComponents
{
    public class item2ViewComponent:ViewComponent
    {
        AppDbContext db;
        public item2ViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int s)
        {
            var item = db.Books.Where(m => m.PublisherId == s);
            return View("itemOfPublisher_Details", item);
        }
    }
}
