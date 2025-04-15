using Microsoft.AspNetCore.Mvc;
using MvcStockv2.Models.Entity;
using MvcStock.Models.ViewModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;



namespace MvcStock.Controllers
{
    public class DriverController : Controller
    {
        Logiconnectv2Context db = new Logiconnectv2Context();
        public IActionResult Index(string DriverId, string DriverName, string DriverSurname)
        {
            int driverid;
            string drivername;
            string driversurname;
            var drivers = db.Drivers.ToList();

            if (!string.IsNullOrEmpty(DriverId))
            {
                driverid = Convert.ToInt32(DriverId);


                drivers = drivers.Where(x => x.DriverId.Equals(driverid)).ToList();
            }
            if (!string.IsNullOrEmpty(DriverName))
            {
                drivername = (DriverName);


                drivers = drivers.Where(x => x.DriverName.Equals(drivername)).ToList();
            }
            if (!string.IsNullOrEmpty(DriverSurname))
            {
                driversurname = (DriverSurname);


                drivers = drivers.Where(x => x.DriverSurname.Equals(driversurname)).ToList();
            }
            return View(drivers);
        }


        //Ekleme İşlemi
        [HttpGet]
        public ActionResult NewDriver()
        {

            var driver = db.Drivers.ToList();
            return View(driver);
        }

        [HttpPost]
        public ActionResult NewDriver(Driver driver)
        {
            db.Drivers.Add(driver);
            db.SaveChanges();
            TempData["AddMessage"] = "";
            return RedirectToAction("Index");

        }
        // Silme İşlemi
        public ActionResult Delete(int id)
        {
            var trucks = db.Trucks.ToList(); 
            var driver = db.Drivers.Find(id);

            var quary = trucks.Where(x => x.DriverId == id).ToList();
            if (quary.Count()>0)
            {
                db.Trucks.RemoveRange(quary);
                db.Drivers.Remove(driver);
                
                db.SaveChanges();

            }
            else
            {
                db.Drivers.Remove(driver);
                db.SaveChanges();
            }


            TempData["DeleteMessage"] = "";
            return RedirectToAction("Index");
        }

        //Update İşlemi
        public ActionResult Update(int id)
        {
            var drvr = db.Drivers.Find(id);
            return View(drvr);

        }
        [HttpPost]
        public ActionResult ApplyUpdate(Driver driver)
        {
            var drvr = db.Drivers.Find(driver.DriverId);
            drvr.DriverName = driver.DriverName;
            drvr.DriverSurname = driver.DriverSurname;

            db.Drivers.Update(drvr);
            db.SaveChanges();
            TempData["UpdateMessage"] = "";
            return RedirectToAction("Index");
        }

    }
}
