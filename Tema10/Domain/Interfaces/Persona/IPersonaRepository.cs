using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPersonaRepository
    {
        List<Departamento> GetDepartamentos();
        Persona GetPersona(int id);
        List<PersonaWithNombreDepartamentoDTO> GetPersonas();
        PersonaWithListadoDepartamentoDTO GetPersonaWithListadoDepartamento(int id);
        int AddPersona(Persona persona);
        int UpdatePersona(int id, Persona persona);
        int DeletePersona(int id);
    }
}