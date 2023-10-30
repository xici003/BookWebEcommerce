using BookWebEcommerce.Models;
using BookWebEcommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BookWebEcommerce.ViewComponents
{
    
    public class itemViewComponent : ViewComponent
    {
        AppDbContext db;
        public itemViewComponent(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int s)
        {
            var item = db.Books.Where(m => m.PublisherId == s);
                return View("ItemOfPublisher", item);
        }
       
    }
}
