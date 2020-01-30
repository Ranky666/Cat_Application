using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Controllers
{
    public class DogController : Controller
    {
       CatContext db;
        public DogController(CatContext context)
        {
            db = context;
        }


        public async Task<IActionResult> Index()
        {
            return View(await db.Dogs.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Dog dog)
        {

            db.Dogs.Add(dog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Dog dog = await db.Dogs.FirstOrDefaultAsync(p => p.Id == id);
                if (dog != null)
                    return View(dog);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Dog dog)
        {
            db.Dogs.Update(dog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Dog dog = await db.Dogs.FirstOrDefaultAsync(p => p.Id == id);
                if (dog != null)
                    db.Dogs.Remove(dog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Dog dog = await db.Dogs.FirstOrDefaultAsync(p => p.Id == id);
                if (dog != null)
                    return View(dog);
            }
            return NotFound();
        }
    }
}
