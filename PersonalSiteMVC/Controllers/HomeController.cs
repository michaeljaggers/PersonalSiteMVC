using PersonalSiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Projects()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Resume()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }

            string message = $"Sender Name: {obj.Name}<br />" +
                             $"Sender Email: {obj.Email}<br />" +
                             $"Message:<br /><br />" +
                             $"{obj.Message}";

            MailMessage mail = new MailMessage($"admin@michaeljaggers.net", "michael.jaggers@gmail.com", "New contact form submission.", message);

            mail.IsBodyHtml = true;
            mail.ReplyToList.Add(obj.Email);

            SmtpClient client = new SmtpClient("mail.michaeljaggers.net");

            client.Credentials = new NetworkCredential("admin@michaeljaggers.net", "****");

            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"<div class=\"alert alert-danger\" role=\"alert\">Your message cannot be sent at this time.<br />" +
                                $"Error: {ex.Message}</div>";

                return PartialView("ContactForm", obj);
            }

            ModelState.Clear();
            ViewBag.Success = $"<div class=\"alert alert-success\" role=\"alert\">Message sent.</div>";
            return PartialView("ContactForm");
        }

        [HttpGet]
        public ActionResult Links()
        {
            return View();
        }
    }
}