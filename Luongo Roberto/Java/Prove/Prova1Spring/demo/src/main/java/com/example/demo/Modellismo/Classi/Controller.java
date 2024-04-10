package com.example.demo.Modellismo.Classi;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class Controller {
    
    @PostMapping("/aggiungiOrdine")
    public String aggiungiOrdine(@RequestBody Ordine ordine) {
        try {
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
            System.out.println("Registrazione driver riuscita");

            String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
            Connection conn = DriverManager.getConnection(connectionString);

            if (conn != null) {
                System.out.println("Connessione avvenuta");
            } else {
                System.out.println("Problema nella connessione");
            }

            // Controlla se l'articolo esiste
            String strSqlArticolo = "SELECT * FROM Articolo WHERE ArticoloId = ?;";
            PreparedStatement pa = conn.prepareStatement(strSqlArticolo);
            pa.setInt(1, ordine.getArticoloId());
            if (!pa.executeQuery().next()) {
                return "Articolo non trovato";
            }

            int idArticolo = ordine.getArticoloId();
            int quantita = ordine.getQuantita();

            String strSql = "INSERT INTO Ordini (ArticoloId, QuantitaDaProdurre, ScaricoEffettuato) VALUES (?, ?, 0);";
            PreparedStatement pd = conn.prepareStatement(strSql);
            pd.setInt(1, idArticolo);
            pd.setInt(2, quantita);
            pd.execute();
            System.out.println("Ordine Aggiunto");
            return "Ordine aggiunto con successo";
        } catch (Exception e) {
            e.printStackTrace();
            return "Errore";
        }
    }
}