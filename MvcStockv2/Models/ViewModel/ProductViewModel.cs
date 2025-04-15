using MvcStockv2.Models.Entity;

namespace MvcStockv2.Models.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductUnit { get; set; }
        public string ProductSensivity { get; set; }
        public int SenderFirmId { get; set; }
        public string SenderFirmName { get; set; }
        public string SenderFirmEmail { get; set; }
        public string SenderFirmLocation { get; set; }
        public int StorageId { get; set; }
        public int StorageCapacity { get; set; }
        public string StorageName { get; set; }

        public int TransferId { get; set; }
        public string LoadingDate { get; set; }

    }
}
