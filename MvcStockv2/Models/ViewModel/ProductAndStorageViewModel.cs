
using MvcStockv2.Models.Entity;

namespace MvcStock.Models.ViewModel
{
    public class ProductAndStorageViewModel
    {
        public List<Storage> Storages { get; set; }
        public List<Product> Products { get; set; }
        public List<Sender> Senders { get; set; }
        public List<Transfer> Transfers { get; set; }
        public string ProductType { get; set; }
        public int ProductId { get; set; }
        public int SenderFirmId { get; set; }
        public string ProductSensivity { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
    }
}
