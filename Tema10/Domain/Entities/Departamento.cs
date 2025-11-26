using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Departamento
    {

        #region Atributos privados
        private int _id;
        private string _nombre;
        #endregion

        public int Id
        {
            get { return _id; }
        }

        #region Getter y Setter
        public string Mnombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        #region constructor
        public Departamento(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
        }
        #endregion

    }
}
