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
    public class ContactController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("alicanbalik@outlook.com"));
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index","Account");
                }
            }
            return View("Index","Account", model);
        }
    }
}