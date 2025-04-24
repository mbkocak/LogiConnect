using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class AirFreighter
{
    public int TransportId { get; set; }

    public string? AirFreighterCapacity { get; set; }

    public string? PilotName { get; set; }

    public string? AirlineFee { get; set; }
}
