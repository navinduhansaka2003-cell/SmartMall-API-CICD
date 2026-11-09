namespace SmartMall.API.Models
{
    public class ParkingSession { 
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int ParkingSlotId { get; set; } 
        public ParkingSlot? ParkingSlot { get; set; }
        public DateTime EntryTime { get; set; } }
}