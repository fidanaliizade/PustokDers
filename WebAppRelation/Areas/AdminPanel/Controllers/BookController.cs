using Microsoft.AspNetCore.Mvc;
using WebAppRelation.Areas.AdminPanel.ViewModels;

namespace WebAppRelation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BookController : Controller
    {
        AppDbContext _db;
        public BookController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Table()
        {
            AdminVM admin = new AdminVM();
            admin.Books = _db.Books
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .ToList();
            return View(admin);
        }

        public IActionResult Create()
        {
			ViewData["Categories"] = _db.Categories.ToList();
			ViewData["Brands"] = _db.Brands.ToList();
			return View();
        }

        [HttpPost]

        public IActionResult Create(Book book )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Books.Add(book);
            _db.SaveChanges();
            return RedirectToAction("Table");
        }

    }
}
