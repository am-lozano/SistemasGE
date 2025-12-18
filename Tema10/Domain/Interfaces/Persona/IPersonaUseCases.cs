using System;
using System.Collections.Generic;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces
{

    public interface IPersonaUseCases
    {

        List<Persona> getListadoPersonas();

        PersonaWithNombreDepartamentoDTO getPersona(int id);


        List<PersonaWithNombreDepartamentoDTO> getPersonas();

        PersonaWithListadoDepartamentoDTO GetPersonaWithListadoDepartamento();

        PersonaWithListadoDepartamentoDTO GetPersonaWithListadoDepartamento(int id);

        int addPersona(Persona persona);

        int updatePersona(int id, Persona persona);


        int deletePersona(int id);
    }
}