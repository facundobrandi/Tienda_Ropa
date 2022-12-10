using Tienda_Ropa.Controllers;

namespace Tienda_Ropa.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Producto> productos { get; set; }
        public IEnumerable<Categoria> categorias { get; set; } 
    }
}
