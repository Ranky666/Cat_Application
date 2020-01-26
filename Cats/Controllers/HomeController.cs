using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Cats.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;




namespace Cats.Controllers
{
    public class HomeController : Controller
    {
        CatContext db;
        public HomeController(CatContext context)
        {
            db = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await db.Cats.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cat cat)
        {
          
            db.Cats.Add(cat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Cat cat = await db.Cats.FirstOrDefaultAsync(p => p.Id == id);
                if (cat != null)
                    return View(cat);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cat cat)
        {
            db.Cats.Update(cat);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Cat cat = await db.Cats.FirstOrDefaultAsync(p => p.Id == id);
                if (cat != null)
                    return View(cat);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Cat cat = await db.Cats.FirstOrDefaultAsync(p => p.Id == id);
                if (cat != null)
                {
                    db.Cats.Remove(cat);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Cat cat = await db.Cats.FirstOrDefaultAsync(p => p.Id == id);
                if (cat != null)
                    return View(cat);
            }
            return NotFound();
        }
    }
}
