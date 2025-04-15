using MvcStockv2.Models.Entity;

namespace MvcStock.Models.ViewModel
{
    public class DriverAndTransportViewModel
    {
        public List<Driver> Drivers { get; set; }
        public int? TruckCapacity { get; set; }
        public int? HighwayFee { get; set; }
        public int TransportId { get; set; }
        public int DriverId { get; set; }

    }
}
