namespace Webapi_Intro.Classi
{
    public class RispostaArticoli
    {
        public string? Messaggio { get; set; }
        public List<Articolo>? ListArticoli {get; set; }

        public RispostaArticoli(string Messaggio, List<Articolo>? ListArticoli)
        {
            this.Messaggio = Messaggio;
            this.ListArticoli = ListArticoli;
        }
    }
}
