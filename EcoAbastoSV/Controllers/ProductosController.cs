using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
            public ProductosController (ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var lista = _context.Productos.ToList();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }
        public IActionResult Edit(int id)
        {
            var productos = _context.Productos.Find(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (id != producto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Productos.Update(producto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }


        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null) 
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
        }
            return RedirectToAction(nameof(Index));
        }
    }
}