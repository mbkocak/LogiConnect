namespace MvcStock.Models.ViewModel
{
    public class TransportViewModel
    {
        public int TransportId { get; set; }
        public string TransportType { get; set; }

        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductUnit { get; set; }
        public string ProductSensivity { get; set; }

        public string SenderFirmName { get; set; }
        public string SenderFirmEmail { get; set; }
        public string SenderFirmLocation { get; set; }

        public int ProductId { get; set; }
        public int StorageId { get; set; }
        public int StorageCapacity { get; set; }

        public int ReceiverFirmId { get; set; }
        public string ReceiverFirmName { get; set; }
        public string ReceiverFirmEmail { get; set; }
        public string ReceiverFirmLocation { get; set; }
       

        public int TransferId { get; set; }
        public string LoadingDate { get; set; }
        public int TransferPayment {  get; set; }





    }
}
