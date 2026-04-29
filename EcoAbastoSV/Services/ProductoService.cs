using EcoAbastoSv.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoAbastoSv.Services
{
    public class ProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        // REGLAS DE NEGOCIO APLICADAS
        public async Task<(bool Success, string Message)> ValidarYGuardar(Producto producto)
        {
            // 1. No permitir campos vacíos (Nombre y Departamento)
            if (string.IsNullOrWhiteSpace(producto.Nombre) || string.IsNullOrWhiteSpace(producto.Departamento))
                return (false, "Regla de Negocio: Todos los campos son obligatorios.");

            // 2. No aceptar montos o cantidades negativas
            if (producto.Precio <= 0)
                return (false, "Regla de Negocio: El precio debe ser un monto mayor a $0.00.");

            if (producto.Stock < 0)
                return (false, "Error: El stock no puede ser una cantidad negativa.");

            // 3. Evitar registros duplicados (Mismo nombre en el mismo departamento)
            var existe = await _context.Productos
                .AnyAsync(p => p.Nombre.ToLower() == producto.Nombre.ToLower()
                          && p.Departamento == producto.Departamento
                          && p.Id != producto.Id);

            if (existe)
                return (false, $"El producto '{producto.Nombre}' ya existe en el registro de {producto.Departamento}.");

            // Si todo es correcto, guardamos o actualizamos
            try
            {
                if (producto.Id == 0) _context.Productos.Add(producto);
                else _context.Productos.Update(producto);

                await _context.SaveChangesAsync();
                return (true, "Operación exitosa.");
            }
            catch (Exception)
            {
                return (false, "Error de sistema al procesar la información.");
            }
        }
    }
}