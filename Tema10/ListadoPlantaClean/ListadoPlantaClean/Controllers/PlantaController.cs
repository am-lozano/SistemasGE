using Microsoft.AspNetCore.Mvc;

namespace ListadoPlantaClean.Controllers
{
    public class PlantaController : Controller
    {
        private readonly IPlantaUseCases _plantaUseCases;


        public PlantaController(IPlantaUseCases plantaUseCases)
        {
            _plantaUseCases = plantaUseCases;
        }


        public IActionResult Index(int? idCategoria)
        {
            return View(_plantaUseCases.getListadoCategoriasWithListadoPlantasPorCategoria(idCategoria));
        }


        [HttpPost]
        public IActionResult Index(int idCategoria)
        {
            return View(_plantaUseCases.getListadoCategoriasWithListadoPlantasPorCategoria(idCategoria));
        }


        public IActionResult Edit(int id)
        {
            return View(_plantaUseCases.getPlanta(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, double precioNuevo)
        {
            var result = _plantaUseCases.editarPrecio(id, precioNuevo);
            if (result < 0)
                ViewBag.Error = "El nuevo precio debe ser mayor que el actual";
            return RedirectToAction("Index");
        }
    }
}
