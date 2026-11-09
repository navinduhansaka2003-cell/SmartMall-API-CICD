namespace SmartMall.API.Models
{
    public class ParkingSlot { public int Id { get; set; }
        public string SlotNumber { get; set; } = string.Empty;
        public bool IsOccupied { get; set; } public int ParkingZoneId { get; set; }
        public ParkingZone? ParkingZone { get; set; } }
}