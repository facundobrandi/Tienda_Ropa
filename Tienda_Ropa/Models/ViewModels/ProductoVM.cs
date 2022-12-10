using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tienda_Ropa.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto producto { get; set; }
        public IEnumerable<SelectListItem>? CategoriaLista { get; set; }
        public IEnumerable<SelectListItem>? TipoAplicacionLista { get; set; }
    }
}
