
using MvcStockv2.Models.Entity;
namespace MvcStock.Models.ViewModel

{
    public class TransportAndStorageViewModelcs
    {
        public List<Storage> Storages { get; set; }
        public List<Transport> Transports { get; set; }
        public List<Product> Products { get; set; }
        public List<Sender> Senders { get; set; }
        public List<Receiver> Receivers { get; set; }
        public Transfer Transfer { get; set; }
        public string StorageCapacity { get; set; }
        public string TransportType { get; set; }
        public int TransportId { get; set; }
        public int StorageId { get; set; }
        public string ProductName { get; set; }
        public string StorageName { get; set; }
        public int TransferPayment { get; set; }
        public int TransferId { get; set; }

    }
}
