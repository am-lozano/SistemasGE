namespace Recuperacion.Models
{
    public class PersonaConColor
    {
        private int IdPersona { get; }
        private string NombrePersona { get; }
        private string ApellidosPersona { get; }
        private int IdDepartamento { get; set; }
        private List<Departamento> ListaDepartamentos { get; }
        private string Color { get; }

        public PersonaConColor(
            int idPersona,
            string nombrePersona,
            string apellidosPersona,
            int idDepartamento,
            List<Departamento> listaDepartamentos,
            string color)
        {
            IdPersona = idPersona;
            NombrePersona = nombrePersona;
            ApellidosPersona = apellidosPersona;
            IdDepartamento = idDepartamento;
            ListaDepartamentos = listaDepartamentos;
            Color = color;
        }
    }
}
