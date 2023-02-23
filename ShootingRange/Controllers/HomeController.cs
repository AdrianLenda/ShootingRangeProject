using Microsoft.AspNetCore.Mvc;
using ShootingRange.Models;
using System.Diagnostics;

namespace ShootingRange.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}