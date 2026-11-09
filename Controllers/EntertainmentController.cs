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
    public class EntertainmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntertainmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntertainmentDTO>>> GetEntertainment()
        {
            var list = await _context.Entertainment
                .Include(e => e.Category)
                .Include(e => e.Floor)
                .ToListAsync();

            var dtoList = list.Select(e => new EntertainmentDTO
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                ImageUrl = e.ImageUrl,
                UnitNumber = e.UnitNumber,

                // Mapped directly to OpenTime/CloseTime to fix CS0117
                OpenTime = e.OpenTime,
                CloseTime = e.CloseTime,
                Hotline = e.Hotline,

                // The ?? 0 fixes the CS0266 nullable int conversion error
                FloorId = e.FloorId ?? 0,
                CategoryId = e.CategoryId ?? 0,

                CategoryName = e.Category?.Name ?? "Uncategorized",
                LocationText = e.Floor != null ? $"{e.Floor.Name} • {e.UnitNumber}" : e.UnitNumber
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntertainmentDTO>> GetEntertainment(int id)
        {
            var item = await _context.Entertainment
                .Include(e => e.Category)
                .Include(e => e.Floor)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (item == null) return NotFound();

            return Ok(new EntertainmentDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                UnitNumber = item.UnitNumber,
                OpenTime = item.OpenTime,
                CloseTime = item.CloseTime,
                Hotline = item.Hotline,
                FloorId = item.FloorId ?? 0,
                CategoryId = item.CategoryId ?? 0,
                CategoryName = item.Category?.Name ?? "Uncategorized",
                LocationText = item.Floor != null ? $"{item.Floor.Name} • {item.UnitNumber}" : item.UnitNumber
            });
        }

        [HttpPost]
        public async Task<ActionResult<EntertainmentDTO>> PostEntertainment(EntertainmentDTO dto)
        {
            // Using EntertainmentModel fixes the CS0246 missing type error
            var item = new EntertainmentModel
            {
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                UnitNumber = dto.UnitNumber,
                OpenTime = dto.OpenTime,
                CloseTime = dto.CloseTime,
                Hotline = dto.Hotline,
                FloorId = dto.FloorId,
                CategoryId = dto.CategoryId
            };

            _context.Entertainment.Add(item);
            await _context.SaveChangesAsync();

            dto.Id = item.Id;

            return CreatedAtAction(nameof(GetEntertainment), new { id = item.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntertainment(int id, EntertainmentDTO dto)
        {
            if (id != dto.Id) return BadRequest();

            var item = await _context.Entertainment.FindAsync(id);
            if (item == null) return NotFound();

            item.Name = dto.Name;
            item.Description = dto.Description;
            item.ImageUrl = dto.ImageUrl;
            item.UnitNumber = dto.UnitNumber;
            item.OpenTime = dto.OpenTime;
            item.CloseTime = dto.CloseTime;
            item.Hotline = dto.Hotline;
            item.FloorId = dto.FloorId;
            item.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntertainment(int id)
        {
            var item = await _context.Entertainment.FindAsync(id);
            if (item == null) return NotFound();

            _context.Entertainment.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}