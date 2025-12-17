using System.Diagnostics;
using ListadoPlantaClean.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListadoPlantaClean.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
