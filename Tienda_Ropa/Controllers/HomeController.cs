﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tienda_Ropa.Datos;
using Tienda_Ropa.Models;
using Tienda_Ropa.Models.ViewModels;

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
    }
}