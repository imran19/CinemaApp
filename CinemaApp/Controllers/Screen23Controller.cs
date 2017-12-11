using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class Screen23Controller : Controller
    {
        AlicanContext db = new AlicanContext();
        // GET: Screen23

        public ActionResult Reservation()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login", "Account");

            if (!Request.IsAuthenticated && !Session["Role"].Equals(255))
                return RedirectToAction("Login", "Account");

            List<Screen23> scr = db.Screen23.ToList();
            ViewData["ViewSeats"] = scr;


            FormCollection data = new FormCollection();
            Movie obj = new Movie();
            string Name = obj.Name;
            try
            {
                var forTime3 = (from t in db.Movies
                                where t.ScreenLinkTime3 == "/Screen23/Reservation"
                                select t).FirstOrDefault().Time3;
                ViewBag.forTime3 = forTime3;
                var forMovieName = (from t in db.Movies
                                    where t.ScreenLinkTime3 == "/Screen23/Reservation"
                                    select t).FirstOrDefault().Name;
                ViewBag.forMovieName = forMovieName;
                var forPrice = (from t in db.Movies
                                where t.ScreenLinkTime3 == "/Screen23/Reservation"
                                select t).FirstOrDefault().Price;
                ViewBag.forPrice = forPrice;
            }
            catch (NullReferenceException ex)
            {

                ViewBag.exception = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ReserveForScreen23(ReservedSeat obj, Screen23 scr)
        {
            if (ModelState.IsValid)
            {
                /*obj.Name = data["customerName"].ToString();
                obj.Surname = data["customerSurname"].ToString();
                obj.Time = data["movieTime"].ToString(); */

                string numOfSeat = obj.ReservedSeats;
                string[] arraySeat = numOfSeat.Split(',');

                for (int i = 0; i < arraySeat.Length; i++)
                {
                    string sn = arraySeat[i];
                    db.Screen23.Where(
                         a => a.SeatNumber == sn
                    ).Single().isReserved = true;
                }
                db.ReservedSeats.Add(obj);
                db.SaveChanges();

                return RedirectToAction("Reservation");
            }
            else
            {
                ModelState.Clear();
                ViewBag.Error = "Something went wrong. Try again or contact with Administrator.";
                return RedirectToAction("Reservation", obj);
            }

        }

        public ActionResult BillForScreen23()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login", "Account");

            if (!Request.IsAuthenticated && !Session["Role"].Equals(255))
                return RedirectToAction("Login", "Account");



            return View();
        }
    }
}