using System.ComponentModel.DataAnnotations;

namespace EcoAbastoSv.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe ser un valor mayor a 0.")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un departamento.")]
        public string Departamento { get; set; } = string.Empty;

        // ESTA PROPIEDAD CORRIGE EL ERROR DE LA VISTA INDEX
        [Required(ErrorMessage = "El stock es obligatorio.")]
        public int Stock { get; set; }

        // ESTA PROPIEDAD CORRIGE EL ERROR DE "EsPrecioAlto" EN LA TABLA
        public bool EsPrecioAlto => Precio > 5.00m;
    }
}