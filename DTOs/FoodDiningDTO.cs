namespace SmartMall.API.DTOs
{
    public class FoodDiningDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string UnitNumber { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string HotlineNumber { get; set; } = string.Empty;

        // Raw IDs for saving data
        public int FloorId { get; set; }
        public int CategoryId { get; set; }

        // Formatted strings for the Kiosk UI
        public string CategoryName { get; set; } = string.Empty;
        public string LocationText { get; set; } = string.Empty;
    }
}
