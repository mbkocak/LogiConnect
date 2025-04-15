using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Ship
{
    public int TransportId { get; set; }

    public string? ShipCapacity { get; set; }

    public string? CaptainName { get; set; }

    public string? ShipFee { get; set; }
}
