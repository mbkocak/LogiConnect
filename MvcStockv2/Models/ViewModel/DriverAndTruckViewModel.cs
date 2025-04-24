namespace MvcStock.Models.ViewModel
{
    public class DriverAndTruckViewModel
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public int TransportId { get; set; }
        public int? TruckCapacity { get; set; }
        public int? HighwayFee { get; set; }
    }
}
