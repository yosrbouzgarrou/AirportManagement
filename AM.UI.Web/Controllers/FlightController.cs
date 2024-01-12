using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight serviceFlight;
        IServicePlane servicePlane;
        public FlightController(IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }

        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart) // ? : nullable
        {
            if(dateDepart!=null)
                return View(serviceFlight.GetMany(f => f.FlightDate.Date.Equals(dateDepart)));
            return View(serviceFlight.GetAll());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View(serviceFlight.GetById(id));
        }

        // GET: FlightController/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.PlaneId = new SelectList(servicePlane.GetAll(), "PlaneId", "Information");

            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile AirlineLogo)
        {
            try
            {
                flight.AirlineLogo = AirlineLogo.FileName; // ajout dans la base
                serviceFlight.Add(flight);
                serviceFlight.Commit();

                //sauvegarder l'image sous uploads
                if (AirlineLogo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "uploads", AirlineLogo.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    AirlineLogo.CopyTo(stream);
                    
                }



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.PlaneId = new SelectList(servicePlane.GetAll(), "PlaneId", "Information");
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Flight flight)
        {
            try
            {
                serviceFlight.Update(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceFlight.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Flight flight)
        {
            try
            {
                serviceFlight.Delete(serviceFlight.GetById(id));
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
