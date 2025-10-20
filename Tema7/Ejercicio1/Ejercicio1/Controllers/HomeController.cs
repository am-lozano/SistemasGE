using System.Diagnostics;
using Ejercicio1.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        public ActionResult Index()
        {
            // Obtenemos la hora actual
            var horaActual = DateTime.Now.Hour;
            string saludo;

            // Definimos el saludo seg�n la hora
            if (horaActual < 12)
                saludo = "�Buenos d�as!";
            else if (horaActual < 18)
                saludo = "�Buenas tardes!";
            else
                saludo = "�Buenas noches!";

            // Creamos un objeto de la clase clsPersona
            Persona persona = new Persona
            {
                nombre = "Juan P�rez",
            };

            // Enviamos los datos a la vista
            ViewData["Saludo"] = saludo;  // Saludo seg�n la hora
            ViewBag.FechaActual = DateTime.Now.ToLongDateString();  // Fecha en formato largo
            return View(persona);  // Pasamos el modelo
        }
    }
}
