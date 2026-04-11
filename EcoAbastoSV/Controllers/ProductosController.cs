using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        // 1. LISTA ESTÁTICA: Mantiene los datos en memoria mientras el sitio está activo
        private static List<Producto> listaProductos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Frijol Rojo", Precio = 1.25m, Departamento = "San Salvador" },
            new Producto { Id = 2, Nombre = "Maíz Blanco", Precio = 0.80m, Departamento = "Santa Ana" },
            new Producto { Id = 3, Nombre = "Huevos (Cartón)", Precio = 4.50m, Departamento = "San Miguel" }
        };

        // VISTA PRINCIPAL: Muestra la tabla con los productos
        public IActionResult Index()
        {
            return View(listaProductos);
        }

        // --- SECCIÓN CREAR ---

        // Abre el formulario de registro
        public IActionResult Create()
        {
            return View();
        }

        // Recibe los datos y los guarda en la lista
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                // Generamos un ID nuevo automáticamente
                producto.Id = listaProductos.Count > 0 ? listaProductos.Max(p => p.Id) + 1 : 1;

                listaProductos.Add(producto);
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // --- SECCIÓN EDITAR ---

        // Abre el formulario con los datos cargados del producto seleccionado
        public IActionResult Edit(int id)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // Procesa los cambios realizados en el formulario
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var productoExistente = listaProductos.FirstOrDefault(p => p.Id == producto.Id);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = producto.Nombre;
                    productoExistente.Precio = producto.Precio;
                    productoExistente.Departamento = producto.Departamento;
                }
                return RedirectToAction("Index");
            }
            return View(producto);
        }
        public IActionResult Delete(int id)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                listaProductos.Remove(producto);
            }
            return RedirectToAction("Index");
        }

    } 
} 
   