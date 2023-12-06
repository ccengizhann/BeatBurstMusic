using BeatBurstMusic.Domain.Dtos;
using BeatBurstMusic.Domain.Entities;
using BeatBurstMusic.Persistance.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeatBurst.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsController : ControllerBase
    {
        private readonly BeatBurstMusicDbContext _applicationDbContext;

        public InstrumentsController(BeatBurstMusicDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext
                .Instruments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _applicationDbContext
                .Instruments
                .Include(x => x.InstrumentCategories)
                .ThenInclude(x => x.Category)
                .AsNoTracking()
                .Select(x => new ProductDto()
                {
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                    Name = x.Name,
                    Categories = x.InstrumentCategories.Select(x => new ProductGetAllCategoryDto()
                    {
                        Id = x.Category.Id,
                        Name = x.Category.Name,
                    }).ToList()
                }).ToListAsync(cancellationToken);

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
        {
            if (productAddDto is null || string.IsNullOrEmpty(productAddDto.Name))
                return BadRequest();

            List<InstrumentCategory> productCategories = new List<InstrumentCategory>();

            var id = Guid.NewGuid();

            if (productAddDto.CategoryIds is not null && productAddDto.CategoryIds.Any())
            {
                foreach (var categoryId in productAddDto.CategoryIds)
                {
                    var productCategory = new InstrumentCategory()
                    {
                        CategoryId = categoryId,
                        InstrumentId = id,
                        CreatedOn = DateTime.UtcNow,
                        CreatedByUserId = "kalaymaster"
                    };

                    productCategories.Add(productCategory);
                }
            }


            var product = new Instrument()
            {
                Id = id,
                Name = productAddDto.Name,
                CreatedByUserId = "tylerDurden",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                InstrumentCategories = productCategories
            };

            await _applicationDbContext.Instruments.AddAsync(product, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(product);
        }

        [HttpPost("OtherPostProccess")]
        public async Task<IActionResult> UpdateAsync(ProductAddDto productAddDto, CancellationToken cancellationToken)
        {
            //var product = await _applicationDbContext
            //    .Products
            //    .Include(x => x.Category)
            //    .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            //product.Name = "Yalan Çalgılar";

            //_applicationDbContext.Products.Update(product);

            //await _applicationDbContext.SaveChangesAsync(cancellationToken);



            //return Ok(product);

            return Ok();
        }

    }
}
 
