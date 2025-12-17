using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Planta
{
    public interface IPlantaRepository
    {
        List<Planta> getPlantas(int idCategoria);
        Planta getPlanta(int id);
        int editarPrecio(int id, double precio);
    }
}
