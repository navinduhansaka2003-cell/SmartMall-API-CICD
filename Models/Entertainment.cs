using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMall.API.Models
{
    public class EntertainmentModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty; // Image URL / Path එක සඳහා

        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string Hotline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string? UnitNumber { get; set; }
        public int? FloorId { get; set; }
        public Floor? Floor { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}