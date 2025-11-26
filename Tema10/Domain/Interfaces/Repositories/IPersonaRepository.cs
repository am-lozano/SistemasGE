using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    internal interface IPersonaRepository
    {

        public List<Persona> getListaPersonas();

        public int crearPersona(Persona persona);



    }
}
