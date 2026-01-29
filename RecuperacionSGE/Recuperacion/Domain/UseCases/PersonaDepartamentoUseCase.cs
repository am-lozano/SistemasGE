using Domain.Dto;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    internal class PersonaDepartamentoUseCase : IPersonaDepartamentoUseCase
    {
        private readonly IPersonasRepo _personasRepo;
        private readonly IDepartamentosRepo _departamentosRepo;

        public PersonaDepartamentoUseCase(
            IPersonasRepo personasRepo,
            IDepartamentosRepo departamentosRepo)
        {
            _personasRepo = personasRepo;
            _departamentosRepo = departamentosRepo;
        }

        public async Task<List<PersonaConListaDeptDto>> GetListaPersonaConListaDeptDto()
        {
            var personas = await _personasRepo.GetAllPersonas();
            var departamentos = await _departamentosRepo.GetAllDepartamentos();

            return personas.Select(p =>
                new PersonaConListaDeptDto(
                    p.Id,
                    p.Nombre,
                    p.Apellidos,
                    p.IdDepartamento,
                    departamentos
                )).ToList();
        }
    }
}
