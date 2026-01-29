using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Departamento
    {
        private int Id { get; }
        private string Nombre { get; }

        public Departamento(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
