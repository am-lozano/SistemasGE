using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PlantaRepository : IPlantaRepository
    {
        private static List<Planta> _plantas = new List<Planta>
{
new Planta(1,"Aloe Vera","Planta medicinal",10,1),
new Planta(2,"Manzanilla","Infusión",5,1),
new Planta(3,"Lavanda","Relajante",8,2)
};


        public List<Planta> getPlantas(int idCategoria)
        {
            return _plantas.Where(p => p.idCategoria == idCategoria).ToList();
        }


        public Planta getPlanta(int id)
        {
            return _plantas.First(p => p.id == id);
        }


        public int editarPrecio(int id, double precio)
        {
            var planta = getPlanta(id);
            planta.precio = precio;
            return 1;
        }
    }
}
