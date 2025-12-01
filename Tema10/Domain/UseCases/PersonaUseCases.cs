using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.DTOs;

namespace Domain.UseCases
{
    public class PersonaUseCases : IPersonaUseCases

    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IDepartamentoRepository _departamentoRepository;

        public PersonaUseCases(IPersonaRepository personaRepository, IDepartamentoRepository departamentoRepository)
        {
            _personaRepository = personaRepository;
            _departamentoRepository = departamentoRepository;
        }

        public List<Departamento> GetDepartamentos()
        {
            return _departamentoRepository.getDepartamentos();
        }

        public PersonaWithNombreDepartamentoDTO GetPersona(int id)
        {
            Persona persona = new Persona();

            // Obtenemos la persona
            persona = _personaRepository.GetPersona(id);

            // Obtenemos el nombre del departamento
            string nombreDepartamento = _departamentoRepository.getDepartamento(persona.IdDepartamento).NombreDepartamento;

            // Creamos el DTO
            PersonaWithNombreDepartamentoDTO personaDTO = new PersonaWithNombreDepartamentoDTO(persona, nombreDepartamento);

            // Devolvemos el DTO
            return personaDTO;
        }

        public List<PersonaWithNombreDepartamentoDTO> GetPersonas()
        {
            // Creamos el listado a devolver
            List<PersonaWithNombreDepartamentoDTO> listadoDTOs = new List<PersonaWithNombreDepartamentoDTO>();

            // Obtenemos el listado de personas
            List<PersonaWithNombreDepartamentoDTO> personasDTO = _personaRepository.GetPersonas();

            // Recorremos el listado de personas y mapeamos
            foreach (PersonaWithNombreDepartamentoDTO persona in personasDTO)
            {
                // Obtenemos el nombre del departamento
                string nombreDepartamento = _departamentoRepository.getDepartamento(persona.persona.IdDepartamento).NombreDepartamento;

                // Creamos el DTO
                PersonaWithNombreDepartamentoDTO personaDTO = new PersonaWithNombreDepartamentoDTO(persona.persona, nombreDepartamento);

                // Añadimos el DTO a la lista
                listadoDTOs.Add(personaDTO);
            }

            // Devolvemos el listado
            return listadoDTOs;
        }

        public PersonaWithListadoDepartamentoDTO GetPersonaWithListadoDepartamento(int id)
        {
            // Creamos el DTO
            PersonaWithListadoDepartamentoDTO personaListado = new PersonaWithListadoDepartamentoDTO(_personaRepository.GetPersona(id), _departamentoRepository.getDepartamentos());

            // Devolvemos el listado
            return personaListado;

        }

        public int AddPersona(Persona persona)
        {
            return _personaRepository.AddPersona(persona);
        }

        public int UpdatePersona(int id, Persona persona)
        {
            return _personaRepository.UpdatePersona(id, persona);
        }

        public int DeletePersona(int id)
        {
            return _personaRepository.DeletePersona(id);
        }

        public List<Departamento> getDepartamentos()
        {
            throw new NotImplementedException();
        }

        public PersonaWithNombreDepartamentoDTO getPersona(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonaWithNombreDepartamentoDTO> getPersonas()
        {
            throw new NotImplementedException();
        }

        public int addPersona(Persona persona)
        {
            throw new NotImplementedException();
        }

        public int updatePersona(int id, Persona persona)
        {
            throw new NotImplementedException();
        }

        public int deletePersona(int id)
        {
            throw new NotImplementedException();
        }
    }
}