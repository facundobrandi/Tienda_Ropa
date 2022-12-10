using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tienda_Ropa.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        [Range(1, double.MaxValue,ErrorMessage = "El precio no puede ser negativo o 0.")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        public string DescripcionCorta { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        public string DescripcionLarga { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo o 0.")]
        public int Stock_Chico { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo o 0.")]
        public int Stock_Medio { get; set; }
        [Required(ErrorMessage = "Este campo es Obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El stock no puede ser negativo o 0.")]
        public int Stock_Grande { get; set; }
        public string? ImagenUrl { get; set; }




        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? categoria { get; set; }


        public int TipoAplicacionId { get; set; }
        [ForeignKey("TipoAplicacionId")]
        public TipoAplicacion? TipoAplicacion { get; set; }
    }
}
