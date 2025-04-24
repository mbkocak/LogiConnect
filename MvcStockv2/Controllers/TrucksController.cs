using Microsoft.AspNetCore.Mvc;
using MvcStockv2.Models.Entity;
using MvcStock.Models.ViewModel;
using System.Diagnostics;

namespace MvcStock.Controllers
{
    public class TrucksController : Controller

    {
        Logiconnectv2Context db = new Logiconnectv2Context();

        //Listeleme
        public IActionResult Index(string TransportId,string TruckCapacity,string HighwayFee,string DriverName,string DriverSurname)
        {
            int driverid;
            int transportid;
            int truckcapacity;
            int highwayfee;
            string drivername;
            string driversurname;


            var trucks = db.Trucks.ToList();
            var drivers = db.Drivers.ToList();

            var query = from truck in trucks
                        join Driver in drivers on truck.DriverId equals Driver.DriverId
                        select new DriverAndTruckViewModel { DriverId=Driver.DriverId, DriverName = Driver.DriverName, DriverSurname = Driver.DriverSurname, TransportId = truck.TransportId, TruckCapacity = truck.TruckCapacity, HighwayFee = truck.HighwayFee };
           
            if (!string.IsNullOrEmpty(TransportId))
            {
               
                transportid = Convert.ToInt32(TransportId);


                query = query.Where(x => x.TransportId.Equals(transportid));
            }
            if (!string.IsNullOrEmpty(TruckCapacity))
            {
                truckcapacity = Convert.ToInt32(TruckCapacity);
                query = query.Where(x => x.TruckCapacity.Equals(truckcapacity));
            }
            if (!string.IsNullOrEmpty(HighwayFee))
            {

                highwayfee = Convert.ToInt32(HighwayFee);
                query = query.Where(x => x.HighwayFee.Equals(highwayfee));

            }
            if (!string.IsNullOrEmpty(DriverName))
            {

                drivername = DriverName;
                query = query.Where(x => x.DriverName.Equals(drivername));

            }
            if (!string.IsNullOrEmpty(DriverSurname))
            {
                driversurname = DriverSurname;
       
                query = query.Where(x => x.DriverSurname.Equals(driversurname));

            }
            return View(query);
        }

        // Ekleme İşlemi
        [HttpGet]
        public ActionResult NewTruck()
        {

            var driver = db.Drivers.ToList();
            return View(driver);

        }
        [HttpPost]
        public ActionResult NewTruck(Truck truck)
        {
            db.Trucks.Add(truck);
            db.SaveChanges();
            TempData["AddMessage"] = "";
            return RedirectToAction("Index");

        }
        //Silme İşlemi
        public ActionResult Delete(int id)
        {
            var truck = db.Trucks.Find(id);
            db.Trucks.Remove(truck);
            db.SaveChanges();

            TempData["DeleteMessage"] = "";
            return RedirectToAction("Index");
        }

        // Update İşlemi
        public ActionResult Update(int id)
        {
            var truck = db.Trucks.Find(id);
            var driver = db.Drivers.ToList();
            DriverAndTransportViewModel driverAndTransportViewModel = new DriverAndTransportViewModel();
            driverAndTransportViewModel.Drivers = driver;
            driverAndTransportViewModel.TransportId = id;
            driverAndTransportViewModel.TruckCapacity = truck.TruckCapacity;
            driverAndTransportViewModel.HighwayFee = truck.HighwayFee;
            driverAndTransportViewModel.DriverId = id;
            return View(driverAndTransportViewModel);
        }
        [HttpPost]
        public ActionResult ApplyUpdate(DriverAndTransportViewModel driverAndTransportViewModel)
        {
            var trck = db.Trucks.Find(driverAndTransportViewModel.TransportId);
            trck.TruckCapacity = driverAndTransportViewModel.TruckCapacity;
            trck.HighwayFee = driverAndTransportViewModel.HighwayFee;
            trck.DriverId = driverAndTransportViewModel.DriverId;

            db.Trucks.Update(trck);
            db.SaveChanges();
            TempData["UpdateMessage"] = "";
            return RedirectToAction("Index");
        }



    }
}