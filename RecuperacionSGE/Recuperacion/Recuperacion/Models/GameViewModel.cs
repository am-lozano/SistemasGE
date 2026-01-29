namespace Recuperacion.Models
{
    public class GameViewModel
    {
        private bool IsLoading { get; set; }
        private List<PersonaConColor> DataCompleted { get; set; }
        private string Error { get; set; }
        private int Aciertos { get; set; }
        private int Registros { get; set; }
        private bool AllGuessed { get; set; }

        public GameViewModel()
        {
            DataCompleted = new();
        }
    }
}
