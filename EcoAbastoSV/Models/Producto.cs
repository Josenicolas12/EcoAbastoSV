using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoAbastoSv.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [Display(Name = "Producto")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 9999.99, ErrorMessage = "El precio debe ser un número mayor a 0.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Precio ($)")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(0, 10000, ErrorMessage = "El stock no puede ser negativo.")]
        [Display(Name = "Cantidad")]
        public int? Stock { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        public string Categoria { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        public string Departamento { get; set; } = string.Empty;
 
        [NotMapped]
        public bool EsEscaso => Stock.HasValue && Stock.Value < 10;
    }
}