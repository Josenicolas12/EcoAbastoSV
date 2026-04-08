using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;
using System.Collections.Generic;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            // Creamos datos de prueba para que la tabla no salga vacía en tu captura
            var lista = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Frijol Rojo (lb)", Precio = 1.25m, Departamento = "San Salvador", Stock = 50 },
                new Producto { Id = 2, Nombre = "Maíz Blanco (lb)", Precio = 0.30m, Departamento = "Santa Ana", Stock = 5 },
                new Producto { Id = 3, Nombre = "Huevos (Cartón)", Precio = 5.50m, Departamento = "San Miguel", Stock = 20 }
            };

            return View(lista);
        }
    }
}