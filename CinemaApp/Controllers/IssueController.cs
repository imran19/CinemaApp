using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CinemaApp.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CinemaApp.Controllers
{
    public class IssueController : Controller
    {
        AlicanContext db = new AlicanContext();
        // GET: Issue
        public ActionResult ReportIssue()
        {
            if (Session["Role"] == null)
                return RedirectToAction("Login", "Account");


            if (!Request.IsAuthenticated && !Session["Role"].Equals(255))
                return RedirectToAction("Login", "Account");

            return View();
        }
        [HttpPost]
        public ActionResult SendIssue(string Message)
        {
            Report reportIssue = new Report()
            {
                ReceptionistId = Convert.ToInt32(Session["Id"]),
                ReceptionistName = Session["Name"].ToString(),
                ReceptionistSurname = Session["Surname"].ToString(),
                Issue = Message
            };
            db.Reports.Add(reportIssue);
            db.SaveChanges();
            return RedirectToAction("Homepage", "Account");
        }


        public ActionResult Solved(int id)
        {
            Report solvedIssue = db.Reports.Find(id);
            solvedIssue.isSolved = true;
            db.SaveChanges();
            return RedirectToAction("AdminPanel", "Account");
        }
    }
}