﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StateMVC.Views.States;
using Microsoft.AspNetCore.Http;
using StateMVC.Models;

namespace StateMVC.Controllers
{
    public class StateController : Controller
    {
        IMemoryCache cache;
        DataService dataService;

        public StateController(DataService data, IMemoryCache cache)
        {
            this.cache = cache;
            dataService = data;

        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("")]
        public IActionResult Index(IndexVM index)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Success";
                dataService.GetEmail(index);
                //cache.Set("SupportEmail", index.SupportEmail);
                HttpContext.Session.SetString("Company", index.CompanyName);
                Response.Cookies.Append("Cookie", "Jag är en cookie",
                    new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(1)
                    });
            }
            return RedirectToAction(nameof(Display));
        }


        [HttpGet("/display")]
        public IActionResult Display()
        {
            var message = (string)TempData["Message"];
            var supportEmail = cache.Get<string>("SupportEmail");
            var company = HttpContext.Session.GetString("Company");
            var VisitDate = Request.Cookies["Cookie"];

            DisplayVM vm = new DisplayVM()
            {
                CompletedMessage = message,
                SupportEmail = supportEmail,
                CompanyName = company,
                Cookie = VisitDate,
            };

            return View(vm);
        }
    }
}
