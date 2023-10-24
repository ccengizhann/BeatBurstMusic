using Microsoft.AspNetCore.Mvc;
using BeatBurstMusic.Persistance.Contexts;
using BeatBurstMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeatBurstMusic.MVC.Controllers
{
    public class BrandController : Controller
    {
        private readonly BeatBurstMusicDbContext _context;

        public BrandController()
        {
            _context = new();
        }

        public IActionResult Index()
        {
            var brands = _context.Brands.ToList();

            return View(brands);
        }

        [HttpGet]
        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(string brandName, string brandDisplayText, string brandAddress)
        {
            var brand = new Brand()
            {
                Id = Guid.NewGuid(),
                Name = brandName,
                Address = brandAddress,
                DisplayText = brandDisplayText,
                CreatedOn = DateTime.UtcNow,
            };

            _context.Brands.Add(brand);

            _context.SaveChanges();

            return View();
        }

        [Route("[controller]/[action]/{id}")]
        public IActionResult Delete(string id)
        {
            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();
            _context.Brands.Remove(brand);

            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}