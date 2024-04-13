package com.example.demo.Modellismo.Classi;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

//import com.google.gson.*;
import javax.sql.DataSource;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.google.gson.Gson;

@RestController
public class Controller {
    private DataSource dataSource; // Assicurati di avere un DataSource configurato

    //#region AggiungiOrdine
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
    //#endregion
    //#region CalcoloFabbisogno
    @PostMapping("/calcoloFabbisogno")
    public String aggiungiFabisogno(@RequestBody Ordine ordine) {
        System.out.println("Inserire l'id dell'ordine");
        try {           
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
            System.out.println("Registrazione driver riuscita");

            String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
            Connection con = DriverManager.getConnection(connectionString);

            if (con != null) {
                System.out.println("Connessione avvenuta");
            } else {
                System.out.println("Problema nella connessione");
            }
                        int id_ordine = ordine.getOrdineId();
                        ResultSet myResult = null, result_qnt = null;


                        String checkQuery = "SELECT OrdineId FROM Fabbisogni WHERE OrdineId = ?";
                        try (PreparedStatement checkStmt = con.prepareStatement(checkQuery)) {
                            checkStmt.setInt(1, id_ordine);
                            try (ResultSet resultSet = checkStmt.executeQuery()) {
                                if (resultSet.next()) {
                                    // Se l'ordine è già stato inserito, restituisci un messaggio appropriato
                                    return "L'ordine è già stato inserito nella tabella Fabbisogni";
                                }
                            }
                        }
                        //provo ad eliminare tutto per poi eventualmente aggiornare
                        String q = "DELETE FROM Fabbisogni WHERE OrdineID = ?";
                        PreparedStatement p = con.prepareStatement(q);
                        p.setInt(1, id_ordine);
                        p.execute();

                        //prendo la quantità e l'id
                        String sql2 = "SELECT ArticoloID, QuantitaDaProdurre FROM Ordini WHERE OrdineID = ?";
                        PreparedStatement pd2 = con.prepareStatement(sql2);
                        pd2.setInt(1, id_ordine);
                        result_qnt = pd2.executeQuery();

                        if (result_qnt.next()) {
                            int quantity = result_qnt.getInt("QuantitaDaProdurre");
                            int id_art = result_qnt.getInt("ArticoloID");

                            //prendo i legami
                            Statement myStatement = con.createStatement();
                            String sql = "SELECT IdFiglio, CoefficenteFabbisogno FROM Legami WHERE IdPadre = ?";
                            PreparedStatement pd1 = con.prepareStatement(sql);
                            pd1.setFloat(1, id_art);
                            myResult = pd1.executeQuery();

                            while (myResult.next()) {
                                int id_articolo_figlio = myResult.getInt("IdFiglio");
                                int coeff = myResult.getInt("CoefficenteFabbisogno");
                                coeff = coeff * quantity;
                                //System.out.println(coeff);

                                //inserisco i legami
                                String strSql3 = "INSERT INTO Fabbisogni (OrdineID,ArticoloID, QuantitaFabbisogno) VALUES (?, ?, ?)";
                                PreparedStatement pd3 = con.prepareStatement(strSql3);
                                pd3.setInt(1, id_ordine);
                                pd3.setInt(2, id_articolo_figlio);
                                pd3.setInt(3, coeff);
                                pd3.execute();
                            }
                            return "Fabisogno Aggiunto";

                        } else {
                            return "Errore id non trovato";
                        }
                        
                    } catch (Exception e) {
                        e.printStackTrace();
                        return "Errore";
                    }
    }
    //#endregion
    //#region VisualizzaFabbisogni
    @PostMapping("/visualizzaFabisogno")
    public String visualizzaFabbisogni(@RequestBody Ordine ordine) {
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

            int id_ordine = ordine.getOrdineId();
            ResultSet myResult = null;

            //Controlla se l'ordine esiste
            String strSqlOrdine = "SELECT * FROM Ordini WHERE OrdineID = ?;";
            PreparedStatement po = conn.prepareStatement(strSqlOrdine);
            po.setInt(1, id_ordine);
            if (!po.executeQuery().next()) {
                return "OrdineId non trovato";
            }

            String strSql = "SELECT ArticoloID, QuantitaFabbisogno FROM Fabbisogni WHERE OrdineID = ?;";
            PreparedStatement pd = conn.prepareStatement(strSql);
            pd.setInt(1, id_ordine);
            myResult = pd.executeQuery();

            ArrayList<Fabbisogni> myListFabbisogni = new ArrayList<Fabbisogni>();
            while (myResult.next()) {
                Fabbisogni myFabbisogni = new Fabbisogni();
                myFabbisogni.setArticoloId(myResult.getInt("ArticoloID"));
                myFabbisogni.setQuantitaFabbisogno(myResult.getInt("QuantitaFabbisogno"));
                myListFabbisogni.add(myFabbisogni);
            }
            Gson myGsonFabbisogni = new Gson();
            String GsonFabbisogni = myGsonFabbisogni.toJson(myListFabbisogni);
            return GsonFabbisogni;
        } catch (Exception e) {
            e.printStackTrace();
            return "Errore";
        }
    }
    //#endregion
    //#region ScaricoMagazzino
    @PostMapping("/scaricoMagazzino")
    public String scaricoMagazzino(@RequestBody Ordine ordine){
        try {
            // Connessione al database
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
            System.out.println("Registrazione driver riuscita");
            String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
            Connection conn = DriverManager.getConnection(connectionString);
            int ordineID = ordine.getOrdineId();
            // Verifica se lo scarico è già stato effettuato per l'ordine specificato
            String checkScaricoSql = "SELECT ScaricoEffettuato FROM Ordini WHERE OrdineID = ?";
            PreparedStatement checkScaricoStmt = conn.prepareStatement(checkScaricoSql);
            checkScaricoStmt.setInt(1, ordineID);
            ResultSet checkScaricoResultSet = checkScaricoStmt.executeQuery();
            
            if (checkScaricoResultSet.next()) {
                boolean scaricoEffettuato = checkScaricoResultSet.getBoolean("ScaricoEffettuato");
                if (scaricoEffettuato) {
                    return "Lo scarico magazzino per l'ordine ID " + ordineID + " è già stato effettuato.";
                }
            }
            
            // Recupera i fabbisogni associati all'ordine
            String fabbisogniSql = "SELECT ArticoloID, QuantitaFabbisogno FROM Fabbisogni WHERE OrdineID = ?";
            PreparedStatement fabbisogniStmt = conn.prepareStatement(fabbisogniSql);
            fabbisogniStmt.setInt(1, ordineID);
            ResultSet fabbisogniResultSet = fabbisogniStmt.executeQuery();
            //Prova di stampa
            System.out.println(ordineID);
            // Esegue lo scarico magazzino per ciascun articolo associato all'ordine
            while (fabbisogniResultSet.next()) {
                int articoloID = fabbisogniResultSet.getInt("ArticoloID");
                int quantitàFabbisogno = fabbisogniResultSet.getInt("QuantitaFabbisogno");
                
                // Esegue lo scarico magazzino per l'articolo
                String updateArticoloSql = "UPDATE Articolo SET Giacenza = Giacenza - ? WHERE ArticoloId = ?";
                PreparedStatement updateArticoloStmt = conn.prepareStatement(updateArticoloSql);
                updateArticoloStmt.setInt(1, quantitàFabbisogno);
                updateArticoloStmt.setInt(2, articoloID);
                updateArticoloStmt.executeUpdate();

                //Controlla se hai le giacenze necessarie
                String strSql = "SELECT ArticoloID, Giacenza FROM Articolo WHERE ArticoloID = ?";
                PreparedStatement p = conn.prepareStatement(strSql);
                p.setInt(1, ordine.getArticoloId());
                ResultSet rs = p.executeQuery();
                if (rs.next()) {
                int giacenza = rs.getInt("Giacenza");
                System.out.print(giacenza);
                if (giacenza > quantitàFabbisogno) {
                    return "Non hai le giacenze necessarie";
                }
            }
            }

            //cOntrolla se l'ordine esiste
            String strSqlOrdine = "SELECT * FROM Ordini WHERE OrdineID = ?;";
            PreparedStatement po = conn.prepareStatement(strSqlOrdine);
            po.setInt(1, ordineID);
            if (!po.executeQuery().next()) {
                return "OrdineId non trovato";
            }

            // Aggiorna lo stato di ScaricoEffettuato nell'ordine
            String updateScaricoSql = "UPDATE Ordini SET ScaricoEffettuato = 1 WHERE OrdineID = ?";
            PreparedStatement updateScaricoStmt = conn.prepareStatement(updateScaricoSql);
            updateScaricoStmt.setInt(1, ordineID);
            updateScaricoStmt.executeUpdate();
            
            // Chiusura della connessione e restituzione del messaggio di successo
            conn.close();
            return "Scarico magazzino effettuato con successo per l'ordine ID " + ordineID;
        } catch (SQLException ex) {
            return "Errore durante lo scarico magazzino: " + ex.getMessage();
    }
    }
    //#endregion

    //#region CalcoloCostoTotaleSemilavorati
    @PostMapping("/calcoloCostoTotaleSemilavorati")
    public String calcoloCosto(@RequestBody Ordine ordine){
    try {
        // Connessione al database
        DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
        System.out.println("Registrazione driver riuscita");

        String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
        Connection conn = DriverManager.getConnection(connectionString);

        if (conn != null) {
            System.out.println("Connessione avvenuta");
        } else {
            System.out.println("Problema nella connessione");
        }

        // Recupero dei dati necessari per il calcolo del costo totale dei semilavorati
        int ordineID = ordine.getOrdineId();
        String sql = "SELECT ArticoloID, QuantitaFabbisogno FROM Fabbisogni WHERE OrdineID = ?";
        PreparedStatement pd = conn.prepareStatement(sql);
        pd.setInt(1, ordineID);
        ResultSet resultSet = pd.executeQuery();

        double costoTotaleSemilavorati = 0;

        // Calcolo del costo totale dei semilavorati
        while (resultSet.next()) {
            int ArticoloID = resultSet.getInt("ArticoloID");
            int QuantitaFabbisogno = resultSet.getInt("QuantitaFabbisogno");

            String sql2 = "SELECT CostoUnitario FROM Articolo WHERE ArticoloID = ?";
            PreparedStatement pd2 = conn.prepareStatement(sql2);
            pd2.setInt(1, ArticoloID);
            ResultSet resultSet2 = pd2.executeQuery();

            if (resultSet2.next()) {
                double costoUnitario = resultSet2.getDouble("CostoUnitario");
                costoTotaleSemilavorati += costoUnitario * QuantitaFabbisogno;
            }
        }
        //Controlla se l'ordine esiste
        String strSqlOrdine = "SELECT * FROM Ordini WHERE OrdineID = ?;";
        PreparedStatement po = conn.prepareStatement(strSqlOrdine);
        po.setInt(1, ordineID);
        if (!po.executeQuery().next()) {
            return "OrdineId non trovato";
        }
        //Update del costo unitario
        String strSqlUpdate = "UPDATE Ordini SET CostoTotale = ? WHERE OrdineId = ?";
        PreparedStatement pu = conn.prepareStatement(strSqlUpdate);
        pu.setDouble(1, costoTotaleSemilavorati);
        pu.setInt(2, ordine.getOrdineId());
        pu.execute();
        System.out.println("Costo unitario aggiornato");
        return "Il costo totale dei semilavorati per l'OrdineID " + ordineID + " è di " + costoTotaleSemilavorati + " euro.";
     }catch(Exception ex){
        System.out.println("Errore" + ex.getMessage());
        return "Errore";
    }
}
//#endregion
/*
 Calcolo del costo Totale del costo Unitario per un prodotto finito: Input ArticoloID (prodotto finito 1 o 2) :  la WebAPI calcola il costo totale dei semilavorati per quello specifico prodotto finito e va ad aggiornare la TArticoli compilando il campo CostoUnitario solo per quell’articoloID (1 oppure 2) .
 */
//#region CalcoloCostoTotaleProdottoFinito
@PostMapping("/calcoloCostoTotaleProdottoFinito")
public String calcoloCostoTotale(@RequestBody Articolo articolo){
    try{
        // Connessione al database
        DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
        System.out.println("Registrazione driver riuscita");

        String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
        Connection conn = DriverManager.getConnection(connectionString);

        if (conn != null) {
            System.out.println("Connessione avvenuta");
        } else {
            System.out.println("Problema nella connessione");
        }
        int articoloID = articolo.getArticoloId();

        //Controlla se l'articolo esiste e se è diverso da 1 o 2
        String strSqlArticolo = "SELECT * FROM Ordini WHERE ArticoloID = ?";
        PreparedStatement pa = conn.prepareStatement(strSqlArticolo);
        pa.setInt(1, articoloID);
        if (!pa.executeQuery().next()) {
            return "Articolo non trovato";
        }
        if(!(articoloID == 1 || articoloID == 2)){
            return "Devi selezionare ArticoloID 1 o 2";
        }

        String getDetailInfo = "SELECT IdFiglio, CoefficenteFabbisogno FROM Legami WHERE IdPadre = ?";
        PreparedStatement getDetailStatement = conn.prepareStatement(getDetailInfo);
        getDetailStatement.setInt(1, articoloID);  
        ResultSet resultSet = getDetailStatement.executeQuery();

        int ArticoloID_figlio;
        int QuantitaFabbisogno;
        float CostoFabbisognoTotale = (float) 0.0;

        while (resultSet.next()) {
            ArticoloID_figlio = resultSet.getInt("IdFiglio");
            QuantitaFabbisogno = resultSet.getInt("CoefficenteFabbisogno");
            String getCostoQuery = "SELECT CostoUnitario FROM Articolo WHERE Tipologia = 'SL' AND ArticoloID = ?";
            PreparedStatement getCostoStatement = conn.prepareStatement(getCostoQuery);
            getCostoStatement.setInt(1, ArticoloID_figlio);

            ResultSet costoResult = getCostoStatement.executeQuery();
            if(costoResult.next()){
                double costoUnitario = costoResult.getFloat("CostoUnitario");
                CostoFabbisognoTotale += costoUnitario  * QuantitaFabbisogno;
            }
        }

        if (CostoFabbisognoTotale > 0){
            String updateCostoTotale = "UPDATE Articolo SET CostoUnitario = ? WHERE ArticoloID = ?";
            PreparedStatement updateStatement = conn.prepareStatement(updateCostoTotale) ;
            updateStatement.setDouble(1, CostoFabbisognoTotale);
            updateStatement.setInt(2, articoloID);
            updateStatement.execute();
        }
        return "Il costo totale del costo unitario per l'ArticoloID " + articoloID + " è di " + CostoFabbisognoTotale + " euro.";
    }

    catch(Exception ex){
        System.out.println("Errore" + ex.getMessage());
        return "Errore";
    }
}
//#endregion

}

//Query 1
// /aggiungiOrdine
// {
//     "articoloId": 1,
//     "quantita": 10
// }

//Query 2
// /calcoloFabbisogno
// {
//     "ordineId": 12
// }

//Query 3
// /visualizzaFabisogno
// {
//     "ordineId": 1
// }

//Query 4
// /scaricoMagazzino
// {
//     "ordineId": 1
// }

//Query 5
// /calcoloCostoTotaleSemilavorati
// {
//     "ordineId": 12
// }

//Query 6
// /calcoloCostoTotaleProdottoFinito
// {
//     "articoloId": 1
// }