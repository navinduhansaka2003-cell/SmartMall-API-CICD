using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMall.API.Data;
using SmartMall.API.DTOs;
using SmartMall.API.Models;

namespace SmartMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShopsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Shops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopDTO>>> GetShops()
        {
            var shops = await _context.Shops
                .Include(s => s.Category)
                .Include(s => s.Floor)
                .Select(s => new ShopDTO
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    UnitNumber = s.UnitNumber,
                    FloorId = s.FloorId,
                    CategoryId = s.CategoryId,

                    // Map the new fields
                    OpenTime = s.OpenTime,
                    CloseTime = s.CloseTime,
                    HotlineNumber = s.HotlineNumber,

                    CategoryName = s.Category != null ? s.Category.Name : "Uncategorized",
                    LocationText = $"Level {s.FloorId} • {s.UnitNumber}"
                })
                .ToListAsync();

            return Ok(shops);
        }
        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDTO>> GetShop(int id)
        {
            var shop = await _context.Shops
                .Include(s => s.Category)
                .Include(s => s.Floor)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (shop == null) return NotFound();

            return Ok(new ShopDTO
            {
                Id = shop.Id,
                Name = shop.Name,
                Description = shop.Description,
                ImageUrl = shop.ImageUrl,
                UnitNumber = shop.UnitNumber,
                FloorId = shop.FloorId,
                CategoryId = shop.CategoryId,
                CategoryName = shop.Category != null ? shop.Category.Name : "Uncategorized",
                LocationText = $"Level {shop.FloorId} • {shop.UnitNumber}"
            });
        }

        // POST: api/Shops
        [HttpPost]
        public async Task<ActionResult<ShopDTO>> CreateShop(ShopDTO shopDto)
        {
            var shop = new Shop
            {
                Name = shopDto.Name,
                Description = shopDto.Description,
                ImageUrl = shopDto.ImageUrl,
                UnitNumber = shopDto.UnitNumber,
                FloorId = shopDto.FloorId,
                CategoryId = shopDto.CategoryId
            };

            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();

            shopDto.Id = shop.Id;

            return CreatedAtAction(nameof(GetShop), new { id = shop.Id }, shopDto);
        }

        // PUT: api/Shops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop(int id, ShopDTO shopDto)
        {
            if (id != shopDto.Id) return BadRequest();

            var shop = await _context.Shops.FindAsync(id);
            if (shop == null) return NotFound();

            // Update all database fields
            shop.Name = shopDto.Name;
            shop.Description = shopDto.Description;
            shop.ImageUrl = shopDto.ImageUrl;
            shop.UnitNumber = shopDto.UnitNumber;
            shop.FloorId = shopDto.FloorId;
            shop.CategoryId = shopDto.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await _context.Shops.FindAsync(id);
            if (shop == null) return NotFound();

            _context.Shops.Remove(shop);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}