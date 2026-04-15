using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;

namespace EcoAbastoSv.Controllers
{
    public class HomeController : Controller
    {
        // Este es el método que abrirá la página bonita que diseñamos
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}