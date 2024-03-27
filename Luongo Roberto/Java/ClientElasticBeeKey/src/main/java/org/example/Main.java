package org.example;
import co.elastic.clients.elasticsearch.ElasticsearchClient;
import co.elastic.clients.json.jackson.JacksonJsonpMapper;
import co.elastic.clients.transport.ElasticsearchTransport;
import co.elastic.clients.transport.rest_client.RestClientTransport;
import org.apache.http.HttpHost;
import org.apache.http.message.BasicHeader;
import org.apache.http.Header;
import org.elasticsearch.client.RestClient;
import co.elastic.clients.elasticsearch.core.IndexResponse;
import co.elastic.clients.elasticsearch.core.SearchResponse;
import java.io.IOException;

import org.apache.http.Header;
import org.elasticsearch.client.RestClient;

public class Main {
    public static void main(String[] args) {
        try {
            String beeKey = "eS1BcmU0NEJrNFhNUWhkcmh0Y0s6bjhiNjdNWERRaS1pcC11WEVhWHlLUQ==";
            String serverURL = "https://mydeployment-20e937.es.us-central1.gcp.cloud.es.io";

            RestClient restClient = RestClient
                    .builder(HttpHost.create(serverURL))
                    .setDefaultHeaders(new Header[] {
                            new BasicHeader("Authorization", "Apikey " + beeKey)
                    }).build();

            ElasticsearchTransport transport = new RestClientTransport(restClient, new JacksonJsonpMapper());

            ElasticsearchClient client = new ElasticsearchClient(transport);

            System.out.println("Client created successfully");

            String index = "persone";

            Persona persona = new Persona();
            persona.setId("1");
            persona.setNome("Mario");
            persona.setCognome("Rossi");

            IndexResponse response = client.index(i -> i.index(index).id(persona.getId()).document(persona));
            System.out.println("Persona indexed successfully");

            //Searc for the indexed document
            SearchResponse searchResponse = client.search(s -> s.index(index).query(q -> q.match(m -> m.field("nome").query("Mario"))));

        } catch (Exception e) {
            e.getMessage();
        }
    }
}