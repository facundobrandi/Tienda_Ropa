using System.ComponentModel.DataAnnotations;

namespace Tienda_Ropa.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de categoria es obligatorio")]
        public string NombreCategoria { get; set; }
        [Required(ErrorMessage = "El orden es obligatorio")]
        [Range(1,int.MaxValue,ErrorMessage = "El orden tiene que ser mayor a 0")]
        public int MostrarOrden { get; set; }
    }
}
