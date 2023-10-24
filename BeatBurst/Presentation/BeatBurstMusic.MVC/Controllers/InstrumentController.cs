using BeatBurstMusic.Domain.Entities;
using BeatBurstMusic.Domain.Enums;
using BeatBurstMusic.Persistance.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace BeatBurstMusic.MVC.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly BeatBurstMusicDbContext _context;


        public InstrumentController()
        {
            _context = new();
        }

        public IActionResult Index() //All Instruments will be shown
        {
            var products = _context.Instruments.ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _context.Brands.ToList();

            return View(brands);
        }

        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string price, string barcode, string pictureUrl)
        {
            var brand = _context.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();

            var instrument = new Domain.Entities.Instrument()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Barcode = barcode,
                Brand = brand,
                CreatedOn = DateTime.UtcNow,
                PictureUrl = pictureUrl
            };

            _context.Instruments.Add(instrument);

            _context.SaveChanges();

         
            
            

            return RedirectToAction("add");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Inspect(string id)
        {
            var instrument = _context.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            return View(instrument);
        }
    }
}