using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CinemaApp.Models;

namespace CinemaApp.Controllers
{
    public class Screen32Controller : Controller
    {
        AlicanContext db = new AlicanContext();
        // GET: Screen32

        public ActionResult Reservation()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login", "Account");

            if (!Request.IsAuthenticated && !Session["Role"].Equals(255))
                return RedirectToAction("Login", "Account");

            List<Screen32> scr = db.Screen32.ToList();
            ViewData["ViewSeats"] = scr;
            

            FormCollection data = new FormCollection();
            Movie obj = new Movie();
            string Name = obj.Name;
            try
            {
                var forTime2 = (from t in db.Movies
                                where t.ScreenLinkTime2 == "/Screen32/Reservation"
                                select t).FirstOrDefault().Time2;
                ViewBag.forTime2 = forTime2;
                var forMovieName = (from t in db.Movies
                                    where t.ScreenLinkTime2 == "/Screen32/Reservation"
                                    select t).FirstOrDefault().Name;
                ViewBag.forMovieName = forMovieName;
                var forPrice = (from t in db.Movies
                                where t.ScreenLinkTime2 == "/Screen32/Reservation"
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
        public ActionResult ReserveForScreen32(ReservedSeat obj, Screen32 scr)
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
                    db.Screen32.Where(
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

        public ActionResult BillForScreen32()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login", "Account");

            if (!Request.IsAuthenticated && !Session["Role"].Equals(255))
                return RedirectToAction("Login", "Account");



            return View();
        }
    }
}