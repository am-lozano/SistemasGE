using Domain.DTOs;
using Domain.Interfaces.Categoria;
using Domain.Interfaces.Planta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class PlantaUseCases : IPlantaUseCases
    {
        private readonly IPlantaRepository _plantaRepository;
        private readonly ICategoriaUseCases _categoriaUseCases;


        public PlantaUseCases(IPlantaRepository plantaRepository, ICategoriaUseCases categoriaUseCases)
        {
            _plantaRepository = plantaRepository;
            _categoriaUseCases = categoriaUseCases;
        }


        public ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria getListadoCategoriasWithListadoPlantasPorCategoria(int? idCategoria)
        {
            var categorias = _categoriaUseCases.getCategorias();


            if (!idCategoria.HasValue)
                return new ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria(categorias);


            var plantas = _plantaRepository.getPlantas(idCategoria.Value);
            return new ListadoCategoriasWithListadoPlantasListadoCategoriasWithListadoPlantasPorCategoria(plantas, categorias);
        }


        public PlantaWithNombreCategoriaDTO getPlanta(int id)
        {
            var planta = _plantaRepository.getPlanta(id);
            var nombreCategoria = _categoriaUseCases.getNombreCategoriaById(planta.idCategoria);
            return new PlantaWithNombreCategoriaDTO(planta, nombreCategoria);
        }


        public int editarPrecio(int id, double precio)
        {
            if (!compruebaPrecio(id, precio)) return -1;
            return _plantaRepository.editarPrecio(id, precio);
        }


        private bool compruebaPrecio(int id, double precioNuevo)
        {
            var planta = _plantaRepository.getPlanta(id);
            return precioNuevo > planta.precio;
        }
    }
}
