using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? DriverName { get; set; }

    public string? DriverSurname { get; set; }

    public virtual ICollection<Truck> Trucks { get; set; } = new List<Truck>();
}
