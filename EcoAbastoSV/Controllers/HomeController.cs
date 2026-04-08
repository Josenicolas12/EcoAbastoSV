using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcoAbastoSv.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Este cambio te manda directo a ver tu tabla de productos
            return RedirectToAction("Index", "Productos");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}