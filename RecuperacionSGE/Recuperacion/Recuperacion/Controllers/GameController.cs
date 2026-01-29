using Microsoft.AspNetCore.Mvc;
using Recuperacion.Models;

namespace Recuperacion.Controllers
{
    public class GameController
    {
        private readonly IPersonaDepartamentoUseCase _useCase;

        private static readonly Dictionary<int, string> MAPEO_COLORES = new()
    {
        { 1, "#FFCDD2" },
        { 2, "#C8E6C9" },
        { 3, "#BBDEFB" },
        { 4, "#FFF9C4" }
    };

        public GameController(IPersonaDepartamentoUseCase useCase)
        {
            _useCase = useCase;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _useCase.GetListaPersonaConListaDeptDto();

            var vm = new GameViewModel
            {
                DataCompleted = data.Select(ConvertirAPersonaConColor).ToList(),
                Registros = data.Count
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Comprobar([FromBody] ComprobarRequest request)
        {
            var data = await _useCase.GetListaPersonaConListaDeptDto();
            int aciertos = data.Count(p =>
                request.Selecciones.Any(s =>
                    s.IdPersona == p.IdPersona &&
                    s.IdDepartamentoSeleccionado == p.IdDepartamento));

            return Json(new
            {
                aciertos,
                total = data.Count,
                ganado = aciertos == data.Count
            });
        }

        private PersonaConColor ConvertirAPersonaConColor(PersonaConListaDeptDto p)
            => new(
                p.IdPersona,
                p.NombrePersona,
                p.ApellidosPersona,
                0,
                p.ListaDepartamentos,
                MAPEO_COLORES.GetValueOrDefault(p.IdDepartamento, "#FFFFFF"));
    }
}
