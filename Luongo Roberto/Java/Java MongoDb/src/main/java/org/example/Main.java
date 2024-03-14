package org.example;

import com.mongodb.ConnectionString;
import com.mongodb.MongoClientSettings;
import com.mongodb.MongoException;
import com.mongodb.ServerApi;
import com.mongodb.ServerApiVersion;
import com.mongodb.client.MongoClient;
import com.mongodb.client.MongoClients;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import com.mongodb.client.model.Updates;
import com.mongodb.client.result.UpdateResult;
import org.bson.Document;

import static com.mongodb.client.model.Filters.eq;

public class Main {
    public static void main(String[] args){
    String connectionString = "mongodb+srv://alexviolatto:vBaW5MIei0BemRcP@clusterlearn.2nzroew.mongodb.net/?retryWrites=true&w=majority&appName=ClusterLearn";
        try{
            ServerApi serverApi = ServerApi.builder()
                    .version(ServerApiVersion.V1)
                    .build();
            MongoClientSettings settings = MongoClientSettings.builder()
                    .applyConnectionString(new ConnectionString(connectionString))
                    .serverApi(serverApi)
                    .build();
            MongoClient mongoClient = MongoClients.create(settings);
            MongoDatabase database = mongoClient.getDatabase("DbProva");
            MongoCollection<Document> collection = database.getCollection("Prova");
            System.out.println("Connessione riuscita!");
            System.out.println("Database: " + database.getName());
            System.out.println("Collection: " + collection.getNamespace().getCollectionName());
            System.out.println();
            collection.find().forEach(document -> System.out.println(document.toJson()));
            System.out.println();
//          collection.find(eq("Nome", "Vino")).forEach(document -> System.out.println(document.toJson()));

            //Ceck if article exists
            long count = collection.countDocuments(eq("Nome", "Vino"));
            if(count == 0) {
                System.out.println("Nessun articolo trovato!");
            }else {
                System.out.println("Ricerca per Nome: Vino");
                //Print the article
                collection.find(eq("Nome", "Vino")).forEach(document -> System.out.println(document.toJson()));
            }

            //Insert a document in to collection

            Document newDocument = new Document()
                    .append("Nome", "Riso")
                    .append("Descrizione", "Riso cantonese")
                    .append("PrezzoVendita", 2.0)
                    .append("Giacenza", 5000)
                    .append("Iva", 22);
            collection.insertOne(newDocument);

            //Update a article from collection
            UpdateResult updateResult = collection.updateOne(eq("Nome", "Riso"), Updates.set("Giacenza", 5000));

            //Delete a article from collection
            collection.deleteOne(eq("Nome", "Riso"));

            System.out.println("Fine!");
        }catch (MongoException e){
            System.out.println("Error: " + e.getMessage());
        }
    }
}
