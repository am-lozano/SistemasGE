using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;

namespace UI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoUseCases _departamentoUseCases;


        public DepartamentoController(IDepartamentoUseCases departamentoUseCases)
        {
            _departamentoUseCases = departamentoUseCases;
        }


        public IActionResult Index()
        {
            try
            {
                return View(_departamentoUseCases.getDepartamentos());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar los departamentos: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        public IActionResult Details(int id)
        {
            try
            {
                return View(_departamentoUseCases.getDepartamento(id));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar los detalles del departamento: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }


        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar el formulario de creación del departamento: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }


        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departamentoUseCases.addDepartamento(departamento);
                    return RedirectToAction("Index");
                }
                return View(departamento);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al crear el departamento: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }


        public IActionResult Edit(int id)
        {
            try
            {
                return View(_departamentoUseCases.getDepartamento(id));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar el departamento para editar: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Departamento departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departamentoUseCases.updateDepartamento(id, departamento);
                    return RedirectToAction("Index");
                }
                return View(departamento);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al editar el departamento: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                return View(_departamentoUseCases.getDepartamento(id));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al cargar el departamento para eliminar: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _departamentoUseCases.deleteDepartamento(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Ocurrió un error al eliminar el departamento: " + ex.Message;
                return View("~/Views/Home/Error.cshtml");
            }
        }
    }
}