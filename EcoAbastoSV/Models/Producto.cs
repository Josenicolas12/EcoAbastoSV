using System.ComponentModel.DataAnnotations;

namespace EcoAbastoSv.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [Display(Name = "Nombre del Producto")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe ser mayor a 0.")]
        [Display(Name = "Precio ($)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        public string Departamento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Display(Name = "Categoría")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, 5000, ErrorMessage = "El stock no puede ser negativo.")]
        [Display(Name = "Cantidad en Stock")]
        public int Stock { get; set; }

        public bool EsPrecioAlto => Precio > 5.00m;
    }
}