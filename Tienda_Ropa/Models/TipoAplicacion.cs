using System.ComponentModel.DataAnnotations;

namespace Tienda_Ropa.Models
{
    public class TipoAplicacion
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
