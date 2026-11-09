using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMall.API.Data;
using SmartMall.API.DTOs;
using SmartMall.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodDiningController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FoodDiningController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodDining
        // This sends the data to your WPF Kiosk
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDiningDTO>>> GetFoodDiningStores()
        {
            var foodStores = await _context.FoodDining
                .Include(f => f.Category)
                .Include(f => f.Floor)
                .ToListAsync();

            var dtoList = foodStores.Select(f => new FoodDiningDTO
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                ImageUrl = f.ImageUrl,
                UnitNumber = f.UnitNumber,
                OpenTime = f.OpenTime,
                CloseTime = f.CloseTime,
                HotlineNumber = f.HotlineNumber,
                FloorId = f.FloorId,
                CategoryId = f.CategoryId,

                // Formats the text nicely for the frontend Kiosk UI
                CategoryName = f.Category?.Name ?? "",
                LocationText = f.Floor != null ? $"{f.Floor.Name} • {f.UnitNumber}" : f.UnitNumber
            }).ToList();

            return Ok(dtoList);
        }

        // GET: api/FoodDining/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDiningDTO>> GetFoodDiningStore(int id)
        {
            var foodStore = await _context.FoodDining
                .Include(f => f.Category)
                .Include(f => f.Floor)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (foodStore == null) return NotFound();

            return Ok(new FoodDiningDTO
            {
                Id = foodStore.Id,
                Name = foodStore.Name,
                Description = foodStore.Description,
                ImageUrl = foodStore.ImageUrl,
                UnitNumber = foodStore.UnitNumber,
                OpenTime = foodStore.OpenTime,
                CloseTime = foodStore.CloseTime,
                HotlineNumber = foodStore.HotlineNumber,
                FloorId = foodStore.FloorId,
                CategoryId = foodStore.CategoryId,
                CategoryName = foodStore.Category?.Name ?? "",
                LocationText = foodStore.Floor != null ? $"{foodStore.Floor.Name} • {foodStore.UnitNumber}" : foodStore.UnitNumber
            });
        }

        // POST: api/FoodDining
        // This allows you to add new restaurants via Swagger
        [HttpPost]
        public async Task<ActionResult<FoodDiningDTO>> PostFoodDiningStore(FoodDiningDTO dto)
        {
            var foodStore = new FoodDining
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                UnitNumber = dto.UnitNumber,
                OpenTime = dto.OpenTime,
                CloseTime = dto.CloseTime,
                HotlineNumber = dto.HotlineNumber,
                FloorId = dto.FloorId,
                CategoryId = dto.CategoryId
            };

            _context.FoodDining.Add(foodStore);
            await _context.SaveChangesAsync();

            dto.Id = foodStore.Id;

            return CreatedAtAction(nameof(GetFoodDiningStores), new { id = foodStore.Id }, dto);
        }

        // PUT: api/FoodDining/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFoodDiningStore(int id, FoodDiningDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var foodStore = await _context.FoodDining.FindAsync(id);
            if (foodStore == null) return NotFound();

            foodStore.Name = dto.Name;
            foodStore.Description = dto.Description;
            foodStore.ImageUrl = dto.ImageUrl;
            foodStore.UnitNumber = dto.UnitNumber;
            foodStore.OpenTime = dto.OpenTime;
            foodStore.CloseTime = dto.CloseTime;
            foodStore.HotlineNumber = dto.HotlineNumber;
            foodStore.FloorId = dto.FloorId;
            foodStore.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/FoodDining/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodDiningStore(int id)
        {
            var foodStore = await _context.FoodDining.FindAsync(id);
            if (foodStore == null) return NotFound();

            _context.FoodDining.Remove(foodStore);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}