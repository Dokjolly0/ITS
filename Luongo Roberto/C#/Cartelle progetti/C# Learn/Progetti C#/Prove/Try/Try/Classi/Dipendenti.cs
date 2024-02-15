namespace Verifica_C_.Classi
{
    public class Dipendenti
    {
        public Int32 Id { get; set; }
        //Sulle stringhe bisogna mettere un ? per controllare se il valore è nullo o meno
        public string? Cognome { get; set; }
        public string? Nome { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string? Sesso { get; set; }
        public string? Comune { get; set; }
        public string? Provincia { get; set; }
        public string? Email { get; set; }
        public Dipendenti()
        {
            //costruttore
        }
    }
}