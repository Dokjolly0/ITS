package org.example;
import com.azure.core.credential.AzureKeyCredential;
import com.azure.ai.texttranslation.TextTranslationClient;
import com.azure.ai.texttranslation.TextTranslationClientBuilder;
import com.azure.ai.texttranslation.models.InputTextItem;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        String TestoInput, TestoOutput, TargetLanguage  ;
        TargetLanguage = "en";
        TestoInput="ciao amici tutto bene";
        String apiKey = "7073a72433844cc6b2bc11e1634511f1";
        String region = "switzerlandnorth";
        AzureKeyCredential credential = new AzureKeyCredential(apiKey);

        // creo il client per la traduzione
        TextTranslationClient myTextTranslationClient =
                new TextTranslationClientBuilder()
                        .credential(credential)
                        .region(region)
                        .buildClient();

        // creo la lista delle lingue target
        List<String> myListTargetLanguages = new ArrayList<>();
        // aggiungo alla lista il TargetLanguage (en)
        myListTargetLanguages.add(TargetLanguage);

        // creo la lista dei testi da tradurre
        List<InputTextItem> myListTestiDaTradurre = new ArrayList<>();
        // aggiungo alla lista il testo da tradurre
        myListTestiDaTradurre.add(new InputTextItem(TestoInput));

        // chiamo il servizio Azure e ottengo il response
        var response = myTextTranslationClient.translate(myListTargetLanguages,myListTestiDaTradurre);
    }
}