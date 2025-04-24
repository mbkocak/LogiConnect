using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MvcStockv2.Models.Entity;
using MvcStock.Models.ViewModel;
using System.Diagnostics;
using System.Security.Cryptography.Pkcs;
using System.Linq;
using Microsoft.Identity.Client.Extensions.Msal;
using NuGet.Protocol.Plugins;
using MvcStockv2.Models.Entity;
using Microsoft.CodeAnalysis.Elfie.Extensions;
using System.Security.Cryptography.Xml;



namespace MvcStock.Controllers
{
    public class TransportController : Controller
    {
        Logiconnectv2Context db = new Logiconnectv2Context();
        List<TransportViewModel> transportViewModel = new List<TransportViewModel>();

        //Listeleme
        public IActionResult Index(string TransportId, string TransportType, string ProductName, string ProductType, string ProductUnit, string ProductSensivity, string SenderFirmName, string SenderFirmEmail, string SenderFirmLocation, string ReceiverFirmId, string ReceiverFirmName, string ReceiverFirmEmail, string ReceiverFirmLocation, string TransferPayment,string TransferId, string LoadingDate)

        {
            int receiverfirmid;
            string receiverfirmName;
            string receiverfirmEmail;
            string receiverfirmLocation;
            

            int transportid;
            string transporttype;

            int productid;
            string productname;
            string producttype;
            string productunit;
            string productsensivity;
            string senderfirmname;
            string senderfirmemail;
            string senderfirmlocation;

            int transferid;
            string loadingdate;
            int transferpayment;

            var products = db.Products.ToList();
            var transports = db.Transports.ToList();
            var storages = db.Storages.ToList();
            var senders = db.Senders.ToList();
            var receiver = db.Receivers.ToList();
            var transfers= db.Transfers.ToList();


            var query = from Transfer in transfers
                        join Storage in storages on Transfer.StorageId equals Storage.StorageId
                        join Product in products on Transfer.ProductId equals Product.ProductId
                        join Sender in senders on Transfer.SenderFirmId equals Sender.SenderFirmId
                        join Receiver in receiver on Transfer.ReceiverFirmId equals Receiver.ReceiverFirmId
                        join Transport in transports on Transfer.TransportId equals Transport.TransportId

                        select new TransportViewModel
                        {
                            TransportId = Transport.TransportId,
                            TransportType = Transport.TransportType,
                            ProductName = Product.ProductName,
                            ProductType = Product.ProductType,
                            ProductUnit = Product.ProductUnit,
                            ProductSensivity = Product.ProductSensivity,
                            SenderFirmName = Sender.SenderFirmName,
                            SenderFirmEmail = Sender.SenderFirmEmail,
                            SenderFirmLocation = Sender.SenderFirmLocation,
                            ProductId = Product.ProductId,
                            StorageId = Storage.StorageId,
                            StorageCapacity = Storage.StorageCapacity,

                            ReceiverFirmId = Receiver.ReceiverFirmId,
                            ReceiverFirmName = Receiver.ReceiverFirmName,
                            ReceiverFirmEmail = Receiver.ReceiverFirmEmail,
                            ReceiverFirmLocation = Receiver.ReceiverFirmLocation,
                            
                            TransferId= Transfer.TransferId,
                            TransferPayment = Transfer.TransferPayment,
                            LoadingDate = Transfer.LoadingDate
                        };

            if (!string.IsNullOrEmpty(TransportId))
            {

                transportid = Convert.ToInt32(TransportId);


                query = query.Where(x => x.TransportId.Equals(transportid));
            }
            if (!string.IsNullOrEmpty(TransportType))
            {
                transporttype = TransportType;
                query = query.Where(x => x.TransportType.Equals(transporttype));
            }
            if (!string.IsNullOrEmpty(ProductName))
            {

                query = query.Where(x => x.ProductName.Equals(ProductName));

            }
            if (!string.IsNullOrEmpty(ProductType))
            {

                producttype = ProductType;
                query = query.Where(x => x.ProductType.Equals(producttype));

            }
            if (!string.IsNullOrEmpty(ProductUnit))
            {
                productunit = ProductUnit;

                query = query.Where(x => x.ProductUnit.Equals(productunit));

            }
            if (!string.IsNullOrEmpty(ProductSensivity))
            {
                productsensivity = ProductSensivity;
                query = query.Where(x => x.ProductSensivity.Equals(productsensivity));
            }
            if (!string.IsNullOrEmpty(SenderFirmName))
            {
                senderfirmname = SenderFirmName;
                query = query.Where(x => x.SenderFirmName.Equals(senderfirmname));
            }
            if (!string.IsNullOrEmpty(SenderFirmEmail))
            {
                senderfirmemail = SenderFirmEmail;
                query = query.Where(x => x.SenderFirmEmail.Equals(senderfirmemail));
            }
            if (!string.IsNullOrEmpty(SenderFirmLocation))
            {
                senderfirmlocation = SenderFirmLocation;
                query = query.Where(x => x.SenderFirmLocation.Equals(senderfirmlocation));
            }

            if (!string.IsNullOrEmpty(ReceiverFirmId))
            {

                receiverfirmid = Convert.ToInt32(ReceiverFirmId);


                query = query.Where(x => x.ReceiverFirmId.Equals(receiverfirmid));
            }

            if (!string.IsNullOrEmpty(ReceiverFirmName))
            {

                query = query.Where(x => x.ReceiverFirmName.Equals(ReceiverFirmName));
            }

            if (!string.IsNullOrEmpty(ReceiverFirmEmail))
            {

                query = query.Where(x => x.ReceiverFirmEmail.Equals(ReceiverFirmEmail));
            }

            if (!string.IsNullOrEmpty(ReceiverFirmLocation))
            {

                query = query.Where(x => x.ReceiverFirmLocation.Equals(ReceiverFirmLocation));

            }

            if (!string.IsNullOrEmpty(TransferPayment))
            {
                transferpayment = Convert.ToInt32(TransferPayment);
                query = query.Where(x => x.TransferPayment.Equals(TransferPayment));
            }

            if (!string.IsNullOrEmpty(TransferId))
            {
                transferid = Convert.ToInt32(TransferId);
                query = query.Where(x => x.TransferId.Equals(TransferId));
            }

            if (!string.IsNullOrEmpty(LoadingDate))
            {
                
                query = query.Where(x => x.LoadingDate.Equals(LoadingDate));
            }

            transportViewModel = query.ToList();
            return View(transportViewModel);

        }
        // Ekleme İşlemi
        [HttpGet]
        public ActionResult NewTransport()
        {
            TranspotAndStorageViewModel transpotAndStorageViewModel = new TranspotAndStorageViewModel();
            var storage = db.Storages.ToList();
            var transport = db.Transports.ToList();
                           
            var product = db.Products.ToList();
            var receiver = db.Receivers.ToList();
            var sender = db.Senders.ToList();
            var transfer = db.Transfers.ToList();



            transport =
  transport.GroupBy(x => x.TransportType)
  .Select(group => group.First())
  .ToList();

            transpotAndStorageViewModel.Transports = transport;
            transpotAndStorageViewModel.Storages = storage;
            transpotAndStorageViewModel.Products = product;
            transpotAndStorageViewModel.Senders = sender;
            transpotAndStorageViewModel.Receivers = receiver;
            transpotAndStorageViewModel.Transfers = transfer;

            return View(transpotAndStorageViewModel);

        }

        [HttpPost]
        public ActionResult NewTransport(Transport transport, Product product, MvcStockv2.Models.Entity.Receiver receiver, MvcStockv2.Models.Entity.Storage storage, Transfer transfer)
        {

           
           transfer.TransportId = transport.TransportId;
            db.Transfers.Add(transfer);
            db.SaveChanges();

            TempData["AddMessage"] = "";
            return RedirectToAction("Index");
        }



        // Silme İşlemi
        public ActionResult Delete(int id)
        {
            var transfer = db.Transfers.Find(id);

            db.Transfers.Remove(transfer);
            db.SaveChanges();

            TempData["DeleteMessage"] = "";
            return RedirectToAction("Index");



        }


        //Update İşlemi
        public ActionResult Update(int id)
        {
            var transport = db.Transports.ToList();
            var storage = db.Storages.ToList();
            var transfer = db.Transfers.SingleOrDefault(w => w.TransferId == id);
            var product = db.Products.ToList();
            var sender = db.Senders.ToList();
            var receiver = db.Receivers.ToList();

            transport =
transport.GroupBy(x => x.TransportType)
.Select(group => group.First())
.ToList();
            TransportAndStorageViewModelcs transportAndStorageViewModel = new TransportAndStorageViewModelcs();

            transportAndStorageViewModel.TransferId = id;
            transportAndStorageViewModel.Products = product;
            transportAndStorageViewModel.Transports = transport;
            transportAndStorageViewModel.Storages = storage;
            transportAndStorageViewModel.Transfer = transfer;
            transportAndStorageViewModel.Senders = sender;
            transportAndStorageViewModel.Receivers = receiver;





            return View(transportAndStorageViewModel);
        }
        public ActionResult ApplyUpdate(Transfer transfer, Transport transport, Product product, MvcStockv2.Models.Entity.Receiver receiver, MvcStockv2.Models.Entity.Sender sender, MvcStockv2.Models.Entity.Storage storage)
        {
            var trnsfr = db.Transfers.Find(transfer.TransferId);

            if (trnsfr != null)
            {
                
                trnsfr.TransportId = transport.TransportId;
                trnsfr.ProductId = product.ProductId;
                trnsfr.SenderFirmId = sender.SenderFirmId;
                trnsfr.ReceiverFirmId = receiver.ReceiverFirmId;
                trnsfr.StorageId = storage.StorageId;
                trnsfr.TransferPayment = transfer.TransferPayment;
                trnsfr.LoadingDate = transfer.LoadingDate;


                db.Transfers.Update(trnsfr);
                db.SaveChanges();

                TempData["UpdateMessage"] = "";
            }
            else
            {
                TempData["UpdateMessage"] = "Transfer can't found!";
            }

            return RedirectToAction("Index");

        }


    }



}
