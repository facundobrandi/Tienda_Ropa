namespace Tienda_Ropa.Models.ViewModels
{
    public class DetalleVM
    {
        public DetalleVM()
        {
            producto = new Producto();
        }

        public Producto producto { get; set; }
        public bool ExiteEnCarro { get; set; }
    }
}
