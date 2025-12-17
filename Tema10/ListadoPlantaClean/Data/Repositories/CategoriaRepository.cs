using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private static List<Categoria> _categorias = new List<Categoria>
{
new Categoria(1,"Medicinal"),
new Categoria(2,"Aromática")
};


        public List<Categoria> getCategorias()
        {
            return _categorias;
        }


        public string getNombreCategoriaById(int id)
        {
            return _categorias.First(c => c.id == id).nombre;
        }
    }
}
