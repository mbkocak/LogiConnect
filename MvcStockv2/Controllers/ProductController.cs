using Microsoft.AspNetCore.Mvc;
using MvcStock.Models.ViewModel;
using MvcStockv2.Models.Entity;
using MvcStockv2.Models.ViewModel;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Xml;

namespace MvcStock.Controllers
{
    public class ProductController : Controller
    {
        Logiconnectv2Context db = new Logiconnectv2Context();
        List<ProductViewModel> productViewModel = new List<ProductViewModel>();
        public IActionResult Index(string ProductId, string ProductName, string ProductType, string ProductUnit, string ProductSensivity,  string TransferId, string LoadingDate)
        {


            int productid;
            string productname;
            string producttype;
            string productunit;
            string productsensivity;

            int transferid;
            string loadingdate;

         


            var query = from  pr in db.Products
                        
                        select new ProductViewModel {
                            ProductType = pr.ProductType,
                            ProductUnit = pr.ProductUnit,
                            ProductSensivity = pr.ProductSensivity,
                            ProductId = pr.ProductId,
                            ProductName = pr.ProductName };

            if (!string.IsNullOrEmpty(ProductId))
            {
                productid = Convert.ToInt32(ProductId);
                query = query.Where(x => x.ProductId.Equals(ProductId));

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
            if (!string.IsNullOrEmpty(TransferId))
            {
                transferid = Convert.ToInt32(TransferId);
                query = query.Where(x => x.ProductId.Equals(TransferId));

            }
            if (!string.IsNullOrEmpty(LoadingDate))
            {

                query = query.Where(x => x.LoadingDate.Equals(LoadingDate));
            }


            productViewModel = query.ToList();
            return View(productViewModel);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            ProductAndStorageViewModel productAndStorageViewModel = new ProductAndStorageViewModel();
            var product = db.Products.ToList();
            var transfer= db.Transfers.ToList();


            productAndStorageViewModel.Products = product;
            productAndStorageViewModel.Transfers= transfer;


            return View(productAndStorageViewModel);

        }
        [HttpPost]
        public ActionResult NewProduct(MvcStockv2.Models.Entity.Sender sender, Product product, Transfer transfer)
        {

  
            var products = db.Products.ToList();
      
           
            db.Products.Add(product);
            db.SaveChanges();
            TempData["AddMessage"] = "";
            return RedirectToAction("Index");
        }

        // Silme İşlemi
        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            TempData["DeleteMessage"] = "";
            return RedirectToAction("Index");
        }

        // Update İşlemi
        public ActionResult Update(int id)
        {
            var product = db.Products.Find(id);
            ProductAndStorageViewModel productAndStorageViewModel = new ProductAndStorageViewModel();
          
            productAndStorageViewModel.ProductId = id;
            productAndStorageViewModel.ProductName = product.ProductName;
            productAndStorageViewModel.ProductType = product.ProductType;
            productAndStorageViewModel.ProductSensivity = product.ProductSensivity;
            productAndStorageViewModel.ProductUnit = product.ProductUnit;
            return View(productAndStorageViewModel);
        }

        [HttpPost]
        public ActionResult ApplyUpdate(ProductAndStorageViewModel productAndStorageViewModel)
        {
            var prdct = db.Products.Find(productAndStorageViewModel.ProductId);
            prdct.ProductType = productAndStorageViewModel.ProductType;
            prdct.ProductSensivity = productAndStorageViewModel.ProductSensivity;
            prdct.ProductName = productAndStorageViewModel.ProductName;
            prdct.ProductUnit = productAndStorageViewModel.ProductUnit;


            db.Products.Update(prdct);
            db.SaveChanges();
            TempData["UpdateMessage"] = "";
            return RedirectToAction("Index");
        }


    }
}
