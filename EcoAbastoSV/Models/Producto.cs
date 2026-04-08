using System.ComponentModel.DataAnnotations;

namespace EcoAbastoSv.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; }

        [Required]
        [Range(0.01, 1000.00)]
        [Display(Name = "Precio ($)")]
        public decimal Precio { get; set; }

        [Required]
        public string Departamento { get; set; }

        [Display(Name = "Cantidad disponible")]
        public int Stock { get; set; }

        // Lógica simple para la alerta de precio alto (Ejemplo: mas de $5.00 es caro para granos)
        public bool EsPrecioAlto => Precio > 5.00m;
    }
}
