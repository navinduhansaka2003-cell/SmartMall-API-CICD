using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMall.API.Data;
using SmartMall.API.DTOs;

namespace SmartMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FloorsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorDTO>>> GetFloors()
        {
            var floors = await _context.Floors
                .Select(f => new FloorDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    Level = f.Level
                })
                .ToListAsync();

            return Ok(floors);
        }

        [HttpPost]
        public async Task<ActionResult<FloorDTO>> CreateFloor(FloorDTO floorDto)
        {
            var floor = new SmartMall.API.Models.Floor
            {
                Name = floorDto.Name,
                Level = floorDto.Level
            };

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            floorDto.Id = floor.Id;
            return Ok(floorDto);
        }

    }
}