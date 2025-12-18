using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.DTOs;

namespace UI.Controllers
{
 
    public class PersonaController : Controller
    {
        private readonly IPersonaUseCases _personaUseCases;
        private readonly IDepartamentoUseCases _departamentoUseCases;


        public PersonaController(IPersonaUseCases personaUseCases, IDepartamentoUseCases departamentoUseCases)
        {
            _personaUseCases = personaUseCases;
            _departamentoUseCases = departamentoUseCases;
        }

        public IActionResult Index()
        {
            try
            {
                return View(_personaUseCases.getPersonas());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar las personas: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

   
        public IActionResult Details(int id)
        {
            try
            {
                return View(_personaUseCases.getPersona(id));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar los detalles de la persona: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        public ActionResult Create()
        {
            try
            {
                return View(_personaUseCases.GetPersonaWithListadoDepartamento());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar los departamentos: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            try
            {
                string mensaje;
                int res = _personaUseCases.addPersona(persona);
                if (res > 0)
                {
                    mensaje = "La persona se ha creado correctamente";
                }
                else
                {
                    mensaje = "La persona no se ha podido crear";
                }
                ViewBag.mensaje = mensaje;
                return View(_departamentoUseCases.getDepartamentos());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al crear la persona: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Departamentos = _departamentoUseCases.getDepartamentos();
                return View(_personaUseCases.getPersona(id).persona);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar la persona para editar: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _personaUseCases.updatePersona(id, persona);
                    return RedirectToAction("Index");
                }
                ViewBag.Departamentos = _departamentoUseCases.getDepartamentos();
                return View(persona);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al editar la persona: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                return View(_personaUseCases.getPersona(id));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar la persona para eliminar: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _personaUseCases.deletePersona(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al eliminar la persona: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }
    }
}