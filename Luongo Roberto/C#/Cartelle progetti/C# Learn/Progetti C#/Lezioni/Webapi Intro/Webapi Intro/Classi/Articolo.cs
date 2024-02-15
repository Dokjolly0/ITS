namespace Webapi_Intro.Classi
{
    public class Articolo
    {
            public Int32 Id { get; set; }
            //Sulle stringhe bisogna mettere un ? per controllare se il valore è nullo o meno
            public string? Nome { get; set; }
            public string? Descrizione { get; set; }
            public Int32 Giacenza { get; set; }
            public Int32 AliquotaIva { get; set; }
            public Int32 Prezzo { get; set; }
            public Articolo()
            {
                //costruttore
            }
    }
}
