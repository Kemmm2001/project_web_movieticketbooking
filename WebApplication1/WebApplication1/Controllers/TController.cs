﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class TController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
