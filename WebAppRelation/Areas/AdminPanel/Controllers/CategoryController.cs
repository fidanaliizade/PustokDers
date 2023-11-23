using Microsoft.AspNetCore.Mvc;
using WebAppRelation.Areas.AdminPanel.ViewModels;

namespace WebAppRelation.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Table()
        {
            AdminVM admin = new AdminVM();
            admin.Categories=_db.Categories.ToList();
            return View(admin);
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Table");
        }
    }
}
