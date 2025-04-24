using MvcStockv2.Models.Entity;
using MvcStockv2.Models.Entity;

namespace MvcStock.Models.ViewModel
{
    public class TranspotAndStorageViewModel
    {
        public List<Transport> Transports { get; set; }
        public List<Storage> Storages { get; set; }
        public List<Product> Products { get; set; }
        public List<Receiver> Receivers { get; set; }
        public List<Sender> Senders { get; set; }
        public List<Transfer> Transfers { get; set; }    
    }
}
