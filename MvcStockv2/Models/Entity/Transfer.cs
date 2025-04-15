using System;
using System.Collections.Generic;

namespace MvcStockv2.Models.Entity;

public partial class Transfer
{
    public int TransferId { get; set; }

    public string? LoadingDate { get; set; }

    public int? TransportId { get; set; }

    public int? ProductId { get; set; }

    public int? SenderFirmId { get; set; }

    public int? StorageId { get; set; }

    public int ReceiverFirmId { get; set; }

    public int TransferPayment { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Receiver? ReceiverFirm { get; set; }

    public virtual Sender? SenderFirm { get; set; }

    public virtual Storage? Storage { get; set; }

    public virtual Transport? Transport { get; set; }
}
