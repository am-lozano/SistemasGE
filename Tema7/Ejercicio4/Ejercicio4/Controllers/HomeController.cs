using System.Diagnostics;
using Ejercicio4.Models;
using Microsoft.AspNetCore.Mvc;
using Ejercicio4.Models.DAL;

namespace Ejercicio4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // accion que renderiza la vista principal
        public IActionResult Index()
        {
            return View();
        }

        // lista de departamentos
        private static List<clsDepartamento> departamentos = new List<clsDepartamento>
        {
            new clsDepartamento(1, "Recursos Humanos"),
            new clsDepartamento(2, "Tecnologia"),
            new clsDepartamento(3, "Marketing")
        };

        // lista de personas
        private static List<clsPersona> personas = new List<clsPersona>
        {
            new clsPersona(1, "Jose", "Dominguez", 30, departamentos[0]),
            new clsPersona(2, "Ana", "Gomez", 25, departamentos[1]),
            new clsPersona(3, "Carlos", "Perez", 35, departamentos[2]),
            new clsPersona(4, "Maria", "Lopez", 28, departamentos[1]),
            new clsPersona(5, "Pedro", "Martinez", 40, departamentos[0])
        };

        // accion para editar los datos de una persona
        public IActionResult EditarPersona()
        {
            // seleccionar aleatoriamente una persona de la lista
            Random random = new Random();
            var persona = personas[random.Next(personas.Count)]; // selecciona una persona al azar

            // pasar los departamentos a la vista
            ViewBag.Departamentos = departamentos;

            // pasar la persona seleccionada a la vista
            return View(persona);
        }

        // accion para guardar los datos modificados de una persona
        [HttpPost]
        public IActionResult GuardarPersona(clsPersona persona)
        {
            // verificar si el modelo es valido (validacion del formulario)
            if (ModelState.IsValid)
            {
                // buscar la persona original por ID
                var personaExistente = personas.FirstOrDefault(p => p.Id == persona.Id);

                // si la persona existe, actualizar sus datos
                if (personaExistente != null)
                {
                    personaExistente.Nombre = persona.Nombre;
                    personaExistente.Apellidos = persona.Apellidos;
                    personaExistente.Edad = persona.Edad;
                    personaExistente.Departamento = persona.Departamento;
                }

                // redirigir al usuario a la pagina principal despues de guardar
                return RedirectToAction("Index");
            }

            // si los datos no son validos, devolver la vista de edicion con errores
            ViewBag.Departamentos = departamentos; // pasar los departamentos nuevamente a la vista
            return View("EditarPersona", persona); // volver a mostrar el formulario de edicion
        }

        // accion de privacidad
        public IActionResult Privacy()
        {
            return View();
        }

        // accion para manejar los errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}