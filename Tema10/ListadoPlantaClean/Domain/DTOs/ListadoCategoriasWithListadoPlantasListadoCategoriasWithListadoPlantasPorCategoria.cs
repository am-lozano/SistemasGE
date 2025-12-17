using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria
    {
        public List<Planta> plantas { get; }
        public List<Categoria> categorias { get; }


        public ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria(List<Categoria> categorias)
        {
            this.categorias = categorias;
            this.plantas = new List<Planta>();
        }


        public ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria(List<Planta> plantas, List<Categoria> categorias)
        {
            this.plantas = plantas;
            this.categorias = categorias;
        }
    }
}
