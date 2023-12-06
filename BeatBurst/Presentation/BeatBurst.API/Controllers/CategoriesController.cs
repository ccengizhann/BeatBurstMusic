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
    public class CategoriesController : ControllerBase
    {
        private readonly BeatBurstMusicDbContext _applicationDbContext;

        public CategoriesController(BeatBurstMusicDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto, CancellationToken cancellationToken)
        {

            if (categoryAddDto is null)
                return BadRequest("Category's name cannot be null");

            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = categoryAddDto.Name,
                CreatedByUserId = "kalaymaster",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
            };

            await _applicationDbContext.Categories.AddAsync(category, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Ok(category);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _applicationDbContext
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var categories = await _applicationDbContext
                .Categories
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Ok(categories);
        }
    }
}
  