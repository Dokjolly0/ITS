namespace Le_classi_tutorial
{
    public partial class Form1 : Form
    {
        //Qui dichiari la variabile persona collegata alla classe Persona (devi farlo fuori per renderlo globale)
        Persona persona;
        public Form1()
        {
            InitializeComponent();
            //Qui dici che la variabile persona è uguale a una nuova persona
            persona = new Persona();
            //Prelevi le istanze della classe
            persona.Id = 1;
            persona.Nome = "Alex";
            persona.Cognome = "Violatto";
            persona.Eta = 20;
            persona.Lavoro = "Developer";
        }
    }
}