using EcoAbastoSv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoAbastoSv.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Simulación rápida (para commit)
            var top = new TopProducto
            {
                Nombre = "Huevos",
                Ventas = 70
            };

            ViewBag.TopProducto = top.Nombre + " (" + top.Ventas + " ventas)";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
