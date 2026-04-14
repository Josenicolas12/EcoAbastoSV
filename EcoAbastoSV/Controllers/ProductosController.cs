using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        private static List<Producto> listaProductos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Frijol Rojo", Precio = 1.25m, Departamento = "San Salvador", Stock = 5, Categoria = "Granos Básicos" },
            new Producto { Id = 2, Nombre = "Maíz Blanco", Precio = 0.80m, Departamento = "Santa Ana", Stock = 50, Categoria = "Granos Básicos" },
            new Producto { Id = 3, Nombre = "Huevos (Cartón)", Precio = 4.50m, Departamento = "San Miguel", Stock = 2, Categoria = "Lácteos y Huevos" }
        };

        public IActionResult Index() => View("Listado", listaProductos);

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                producto.Id = listaProductos.Count > 0 ? listaProductos.Max(p => p.Id) + 1 : 1;
                listaProductos.Add(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public IActionResult Edit(int id)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            return producto == null ? NotFound() : View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var existente = listaProductos.FirstOrDefault(p => p.Id == producto.Id);
                if (existente != null)
                {
                    existente.Nombre = producto.Nombre;
                    existente.Precio = producto.Precio;
                    existente.Departamento = producto.Departamento;
                    existente.Stock = producto.Stock;
                    existente.Categoria = producto.Categoria;
                }
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        public IActionResult Delete(int id)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            if (producto != null) listaProductos.Remove(producto);
            return RedirectToAction("Index");
        }
    }
}