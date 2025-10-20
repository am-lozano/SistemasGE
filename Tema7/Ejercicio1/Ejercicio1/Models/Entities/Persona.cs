namespace Ejercicio1.Models.Entities
{
    public class Persona
    {
        #region atributos privados

        private int _id;

        private string _nombre;

        #endregion

        #region get set

        public int id { get { return _id; } }

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion

        #region constructor

        public Persona() { }

        public Persona(int id)
        {
            _id = id;
        }

        #endregion
    }
}
