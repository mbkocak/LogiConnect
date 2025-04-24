using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Truck
{
    public int TransportId { get; set; }

    public int? TruckCapacity { get; set; }

    public int? HighwayFee { get; set; }

    public int? DriverId { get; set; }

    public virtual Driver? Driver { get; set; }
}
