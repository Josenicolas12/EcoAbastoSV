using Microsoft.AspNetCore.Mvc;
using EcoAbastoSv.Models;   
using EcoAbastoSv.Services; 
using System.Linq;
using System.Threading.Tasks;

namespace EcoAbastoSv.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductoService _productoService;

        public ProductosController(ApplicationDbContext context, ProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        public IActionResult Index() => View(_context.Productos.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                // USANDO LA CAPA DE LÓGICA DE NEGOCIO
                var resultado = await _productoService.ValidarYGuardar(producto);

                if (resultado.Success) return RedirectToAction(nameof(Index));

                // Si la validación falla, enviamos el mensaje al usuario
                ModelState.AddModelError(string.Empty, resultado.Message);
            }
            return View(producto);
        }

        public IActionResult Edit(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null) return NotFound();
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var resultado = await _productoService.ValidarYGuardar(producto);
                if (resultado.Success) return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, resultado.Message);
            }
            return View(producto);
        }

        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null) { _context.Productos.Remove(producto); _context.SaveChanges(); }
            return RedirectToAction(nameof(Index));
        }
    }
}