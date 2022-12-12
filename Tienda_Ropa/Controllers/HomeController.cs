using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tienda_Ropa.Datos;
using Tienda_Ropa.Models;
using Tienda_Ropa.Models.ViewModels;
using Tienda_Ropa.Utilidades;

namespace Tienda_Ropa.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                productos = _db.Producto.Include(c => c.categoria).Include(t => t.TipoAplicacion),
                categorias = _db.Categoria
            };



            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            Console.WriteLine("hola mundo");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Detalle(int Id) 
        {
            List<CarroCompra> carroCompras = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null
                && HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroCompras = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }




            DetalleVM detalleVM = new DetalleVM()
            {
                producto = _db.Producto.Include(c => c.categoria).Include(t => t.TipoAplicacion).Where(p => p.Id == Id).FirstOrDefault(),
                ExiteEnCarro =false,
            };

            foreach (var item in carroCompras) 
            {
                if (item.ProductoId == Id) { detalleVM.ExiteEnCarro = true; }
            }

            return View(detalleVM);
        
        }


        [HttpPost,ActionName("Detalle")]
        
        public IActionResult DetallePost(int Id) 
        {
            List<CarroCompra> carroCompras = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null
                && HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroCompras = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras); 
            }
            carroCompras.Add(new CarroCompra { ProductoId = Id });
            HttpContext.Session.Set(WC.SessionCarroCompras, carroCompras);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoverDeCarro(int Id)
        {
            List<CarroCompra> carroCompras = new List<CarroCompra>();

            if (HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras) != null
                && HttpContext.Session.Get<IEnumerable<CarroCompra>>(WC.SessionCarroCompras).Count() > 0)
            {
                carroCompras = HttpContext.Session.Get<List<CarroCompra>>(WC.SessionCarroCompras);
            }

            var productoARemover = carroCompras.SingleOrDefault(x => x.ProductoId == Id);

            if(productoARemover != null) 
            {
                carroCompras.Remove(productoARemover);            
            }

            HttpContext.Session.Set(WC.SessionCarroCompras, carroCompras);

            return RedirectToAction(nameof(Index));
        }

    }
}