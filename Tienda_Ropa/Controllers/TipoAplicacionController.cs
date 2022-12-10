using Microsoft.AspNetCore.Mvc;
using Tienda_Ropa.Datos;
using Tienda_Ropa.Models;

namespace Tienda_Ropa.Controllers
{
    public class TipoAplicacionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TipoAplicacionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> lista = _db.TipoAplicacion;

            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(TipoAplicacion tipo)
        {
            if (ModelState.IsValid)
            {
                _db.TipoAplicacion.Add(tipo);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return (View(tipo));
        }

        public IActionResult Editar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.TipoAplicacion.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TipoAplicacion tipo)
        {
            if (ModelState.IsValid)
            {
                _db.TipoAplicacion.Update(tipo);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return (View(tipo));
        }

        // get Eliminar
        public IActionResult Eliminar(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.TipoAplicacion.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(TipoAplicacion tipo)
        {
            if (tipo == null)
            {
                return NotFound();
            }

            _db.TipoAplicacion.Remove(tipo);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }


}

