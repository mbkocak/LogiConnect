using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcStockv2.Models.Entity;
using MvcStock.Models.ViewModel;
using System.Collections;
using System.Diagnostics;


namespace MvcStock.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        Logiconnectv2Context db = new Logiconnectv2Context();
        public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

        public IActionResult Index()
        {
            var products = db.Products.ToList();
            var transports = db.Transports.ToList();
            var storages= db.Storages.ToList();

            List<string> productName = new List<string>();
            List<int> productunit = new List<int>();
            List<string> transportType = new List<string>();
            List<int> transportid = new List<int>();
            List<int> storageid = new List<int>();
            List<int> storageCapacity = new List<int>();
            List <string> storageName= new List<string>();

           

            productName = products.Select(s=>s.ProductName).ToList();
 
            foreach (var item in products)
            {
                int unitID = 0;
                if (Int32.TryParse(item.ProductUnit, out unitID))
                {
                    productunit.Add(unitID);
                }           
               
            }
            foreach (var item in transports)
            {
                transportType.Add(item.TransportType);
            }

            foreach (var item in transports)
            {
                transportid.Add(Convert.ToInt32(item.TransportId)); 
            }

            foreach (var item in storages)
            {
                storageName.Add(item.StorageName);

            }

            foreach (var item in storages)
            {
                storageCapacity.Add(Convert.ToInt32(item.StorageCapacity));
            }

            var model = new ChartViewModel
            {
                PieChartLabels = productName,
                PieChartData = productunit,
                DoughnutLabels = storageName,
                DoughnutData = storageCapacity
            };

            return View(model);
        }


        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
	public class ChartViewModel
	{
        public List<string> PieChartLabels { get; set; }
        public List<int> PieChartData { get; set; }

        public List<string> DoughnutLabels { get; set; }
        public List<int> DoughnutData { get; set; }
    }

}
