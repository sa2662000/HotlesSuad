using Hotles.Data;
using Hotles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Hotles.Controllers
{
    public class HomeController : Controller
    {
       
      private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
        _context = context;
        }
       
        public IActionResult CreateNewRecord(Hotle hotle)
            
        {
            if (ModelState.IsValid)
            {
				_context.hotles.Add(hotle);
				_context.SaveChanges();
				
			}
			return RedirectToAction("Index");

		}


        public IActionResult Update(Hotle hotle)
        {
            _context.hotles.Update(hotle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult Edit(int id)
        {
            var hoteledit= _context.hotles.SingleOrDefault(x => x.Id == id);
           return View(hoteledit);
        }
        public IActionResult Delete(int id)
        {
            var hotedelete =_context.hotles.SingleOrDefault(x=>x.Id==id);
            _context.hotles.Remove(hotedelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Index(String City)
        {
            var findhotel = _context.hotles.Where(x => x.City.Contains(City));
            ViewBag._context.hotles = findhotel;
            return View(findhotel);
        }
        public IActionResult Index()
        {
            var hotel = _context.hotles.ToList();
            return View(hotel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}