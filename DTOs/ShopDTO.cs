namespace SmartMall.API.DTOs
{
    public class ShopDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Input fields for Creating/Updating via Swagger
        public string ImageUrl { get; set; } = string.Empty;
        public string UnitNumber { get; set; } = string.Empty;
        public int FloorId { get; set; }
        public int CategoryId { get; set; }

        // New Input fields for the Shop Details Window
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string HotlineNumber { get; set; } = string.Empty;

        // Output fields formatted specifically for the WPF UI
        public string CategoryName { get; set; } = string.Empty;
        public string LocationText { get; set; } = string.Empty;
    }
}