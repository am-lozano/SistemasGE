using System.Diagnostics;
using Ejercicio3.Models;
using Microsoft.AspNetCore.Mvc;
using Ejercicio3.Models.DAL;

namespace Ejercicio3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonaPosTres()
        {
            // crear una lista de personas
            var personas = new List<clsPersona>
            {
                new clsPersona(1, "Jos�", "Dom�nguez", 30),
                new clsPersona(2, "Ana", "G�mez", 25),
                new clsPersona(3, "Carlos", "P�rez", 35),
                new clsPersona(4, "Mar�a", "L�pez", 28),
                new clsPersona(5, "Pedro", "Mart�nez", 40)
            };

            // obtener la persona en la posici�n 3 (�ndice 2)
            var persona = personas.ElementAtOrDefault(2);

            // verificar si la persona fue encontrada y pasarla a ViewBag
            if (persona != null)
            {
                ViewBag.PersonaSeleccionada = persona;
            }
            else
            {
                ViewBag.PersonaSeleccionada = "No se encontr� la persona en la posici�n indicada.";
            }

            // pasar la lista de personas a la vista
            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}