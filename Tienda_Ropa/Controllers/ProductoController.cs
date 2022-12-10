using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda_Ropa.Datos;
using Tienda_Ropa.Models;
using Tienda_Ropa.Models.ViewModels;

namespace Tienda_Ropa.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(ApplicationDbContext db , IWebHostEnvironment  webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> lista = _db.Producto.Include(c => c.categoria).Include(t => t.TipoAplicacion);

            return View(lista);
        }

        public IActionResult Upsert(int? Id)
        {
            //IEnumerable<SelectListItem> categoriaDropdown = _db.Categoria.Select(c=> new SelectListItem 
            //{
            //    Text =c.NombreCategoria,
            //    Value = c.Id.ToString()
            //});

            //ViewBag.CategoriaDropdown = categoriaDropdown;


            //Producto producto = new Producto();

            ProductoVM productoVM = new ProductoVM()
            {
                producto = new Producto(),
                CategoriaLista = _db.Categoria.Select(c => new SelectListItem 
                {
                   Text =c.NombreCategoria,
                   Value = c.Id.ToString()
                }),
                TipoAplicacionLista = _db.TipoAplicacion.Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                }),
            };

            if (Id == null) 
            {
            return View(productoVM);
            }
            else 
            {
                productoVM.producto = _db.Producto.Find(Id);
                if(productoVM.producto == null) { return NotFound(); }

                return View(productoVM);
            }
         
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(ProductoVM productoVM) 
        {
            if (ModelState.IsValid) 
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if(productoVM.producto.Id == 0) 
                {
                    //Crear

                    string upload = webRootPath + WC.ImagenRuta;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using(var fileStream = new FileStream(Path.Combine(upload, fileName+extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    //imagen grabada

                    productoVM.producto.ImagenUrl = fileName + extension;
                    _db.Producto.Add(productoVM.producto);
                }
                else
                {
                    //actualizar

                    var objproducto = _db.Producto.AsNoTracking().FirstOrDefault(p => p.Id == productoVM.producto.Id);

                    if (files.Count > 0)
                    {
                        string upload = webRootPath + WC.ImagenRuta;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //borrar imagen anterior
                        var anteriorfile = Path.Combine(upload,objproducto.ImagenUrl);
                        if (System.IO.File.Exists(anteriorfile)) 
                        {
                            System.IO.File.Delete(anteriorfile);
                        }

                        //fin de borrar imagen

                        using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(fileStream);
                        }

                        productoVM.producto.ImagenUrl=fileName + extension;
                    }
                    else 
                    {
                        productoVM.producto.ImagenUrl = objproducto.ImagenUrl;
                    }

                    _db.Producto.Update(productoVM.producto);
                }

                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(productoVM);
        
        }

        //get 
        public IActionResult Eliminar(int? Id) 
        {
            if(Id == null || Id == 0) 
            {
                return NotFound();
            }

            Producto producto = _db.Producto.Include(c => c.categoria).Include(t => t.TipoAplicacion).FirstOrDefault(p => p.Id == Id);

            if(producto == null) 
            {
                return NotFound();
            }

            return View(producto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Eliminar(Producto producto) 
        {
            if(producto == null) 
            {
                return NotFound();
            }

            //eliminar la imagen 

            string upload = _webHostEnvironment.WebRootPath + WC.ImagenRuta;

            //borrar imagen anterior
            var anteriorfile = Path.Combine(upload,producto.ImagenUrl);
            if (System.IO.File.Exists(anteriorfile))
            {
                System.IO.File.Delete(anteriorfile);
            }

            _db.Producto.Remove(producto);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }






    }


}
