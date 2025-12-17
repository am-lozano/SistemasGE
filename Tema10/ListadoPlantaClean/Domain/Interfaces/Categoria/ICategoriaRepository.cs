using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Categoria
{
    public interface ICategoriaRepository
    {
        List<Categoria> getCategorias();
        string getNombreCategoriaById(int id);
    }
}
