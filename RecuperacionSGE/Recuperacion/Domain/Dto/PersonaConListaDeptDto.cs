using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    internal class PersonaConListaDeptDto
    {
        private int IdPersona { get; }
        private string NombrePersona { get; }
        private string ApellidosPersona { get; }
        private int IdDepartamento { get; }
        private List<Departamento> ListaDepartamentos { get; }

        public PersonaConListaDeptDto(
            int idPersona,
            string nombrePersona,
            string apellidosPersona,
            int idDepartamento,
            List<Departamento> listaDepartamentos)
        {
            IdPersona = idPersona;
            NombrePersona = nombrePersona;
            ApellidosPersona = apellidosPersona;
            IdDepartamento = idDepartamento;
            ListaDepartamentos = listaDepartamentos;
        }
    }
}
