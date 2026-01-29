using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Persona
    {
        private int Id { get; }
        private string Nombre { get; }
        private string Apellidos { get; }
        private int Telefono { get; }
        private string Direccion { get; }
        private string Foto { get; }
        private DateTime Fecha { get; }
        private int IdDepartamento { get; }

        public Persona(int id, string nombre, string apellidos, int telefono,
            string direccion, string foto, DateTime fecha, int idDepartamento)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Telefono = telefono;
            Direccion = direccion;
            Foto = foto;
            Fecha = fecha;
            IdDepartamento = idDepartamento;
        }
    }
}
