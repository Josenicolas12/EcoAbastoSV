using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        // Lista con datos iniciales realistas para El Salvador
        private static List<Producto> listaProductos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Frijol Rojo (lb)", Precio = 1.25m, Departamento = "San Salvador", Stock = 5, Categoria = "Granos Básicos" },
            new Producto { Id = 2, Nombre = "Maíz Blanco (lb)", Precio = 0.80m, Departamento = "Santa Ana", Stock = 50, Categoria = "Granos Básicos" },
            new Producto { Id = 3, Nombre = "Huevos (Cartón 30 unidades)", Precio = 4.50m, Departamento = "San Miguel", Stock = 2, Categoria = "Lácteos y Huevos" },
            new Producto { Id = 4, Nombre = "Arroz Blanco (lb)", Precio = 0.55m, Departamento = "La Libertad", Stock = 100, Categoria = "Granos Básicos" }
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