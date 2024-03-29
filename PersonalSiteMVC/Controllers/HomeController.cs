﻿using PersonalSiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Configuration;

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
                return PartialView("ContactForm", obj);
            }

            string message = $"Sender Name: {obj.Name}<br />" +
                             $"Sender Email: {obj.Email}<br />" +
                             $"Message:<br /><br />" +
                             $"{obj.Message}";

            MailMessage mail = new MailMessage(
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailTo"].ToString(),
                "New contact form submission.",
                message
            );

            mail.IsBodyHtml = true;
            mail.ReplyToList.Add(obj.Email);

            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            client.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailPass"].ToString()
            );

            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {
                ViewBag.Error = $"<div class=\"alert alert-danger text-center\" role=\"alert\">Your message could not be sent at this time.</div>";

                return PartialView("ContactForm", obj);
            }

            ModelState.Clear();
            ViewBag.Success = $"<div class=\"alert alert-success text-center\" role=\"alert\">Message sent.</div>";
            return PartialView("ContactForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxSubmit(ContactViewModel obj)
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Links()
        {
            return View();
        }
    }
}