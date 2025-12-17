using Domain.Entities;
using Domain.Interfaces.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CategoriaUseCases : ICategoriaUseCases
    {
        private readonly ICategoriaRepository _categoriaRepository;


        public CategoriaUseCases(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        public List<Categoria> getCategorias()
        {
            return _categoriaRepository.getCategorias();
        }


        public string getNombreCategoriaById(int id)
        {
            return _categoriaRepository.getNombreCategoriaById(id);
        }
    }
}
