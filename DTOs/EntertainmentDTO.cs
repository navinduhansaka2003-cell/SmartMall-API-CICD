using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMall.API.DTOs
{
    public class EntertainmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string UnitNumber { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string Hotline { get; set; } = string.Empty;

        // Raw IDs for saving data
        public int FloorId { get; set; }
        public int CategoryId { get; set; }

        // Formatted strings for the Kiosk UI
        public string CategoryName { get; set; } = string.Empty;
        public string LocationText { get; set; } = string.Empty;

        // Related Navigation / Joined Objects
        public CategoryDTO? Category { get; set; }
        public FloorDTO? Floor { get; set; }
    }
}