using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Planta
{
    public interface IPlantaUseCases
    {
        ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria getListadoCategoriasWithListadoPlantasPorCategoria(int? idCategoria);
        PlantaWithNombreCategoriaDTO getPlanta(int id);
        int editarPrecio(int id, double precio);
    }
}
