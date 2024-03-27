using Azure;
using Azure.AI.Translation.Text;

String input, output, target, lang;

try
{
    Console.WriteLine("Inserisci il testo da tradurre: ");
    input = Console.ReadLine();
    Console.WriteLine("Inserisci la lingua in cui vuoi tradurre: ");
    target = Console.ReadLine();
    //Definiamo che abbiamo accesso ad'azure
    AzureKeyCredential credential = new AzureKeyCredential("dc33a776699e433090864974c986b867");
    //Definiamo un client con la credenziale creata prima
    TextTranslationClient client = new TextTranslationClient(credential, "switzerlandnorth");
    //Definiamo una risposta che traduce il testo dato in input
    var response = client.Translate(target, input);

    //Il response ha un figlio che si chiama value
    //Puo avere piu figli, noi prendiamo il primo (indice 0)
    var textItem = response.Value.FirstOrDefault();

    //textItem ha puo avere vari figli (Translation)
    //prendo il primo figlio delle translation e accedo al text che è la effettiva traduzione
    output = textItem.Translations.FirstOrDefault().Text;
    lang = textItem.DetectedLanguage.Language;
    Console.WriteLine("Traduzione: " + output);
    Console.WriteLine("Lingua rilevata: " + lang);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();