using Azure;
using Azure.AI.Translation.Text;

String input, output, target, lang;
Boolean reTranslate = true;

try
{
    while (reTranslate == true)
    {
        Console.WriteLine("Inserisci il testo da tradurre: ");
        input = Console.ReadLine();
        Console.WriteLine("Inserisci la lingua in cui vuoi tradurre: ");
        target = Console.ReadLine();
        AzureKeyCredential credential = new AzureKeyCredential("dc33a776699e433090864974c986b867");
        TextTranslationClient client = new TextTranslationClient(credential, "switzerlandnorth");
        var response = client.Translate(target, input);
        var textItem = response.Value.FirstOrDefault();
        output = textItem.Translations.FirstOrDefault().Text;
        lang = textItem.DetectedLanguage.Language;
        Console.WriteLine("Traduzione: " + output);
        Console.WriteLine("Lingua rilevata: " + lang);

        Console.WriteLine("Vuoi tradurre un altro testo? (y/n)");
        String responseReTranslate = Console.ReadLine();
        if (responseReTranslate != "y")
        {
            reTranslate = false;
        }
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.ReadKey();
