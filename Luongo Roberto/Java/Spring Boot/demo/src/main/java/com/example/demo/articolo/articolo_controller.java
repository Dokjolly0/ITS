package com.example.demo.articolo;

import org.springframework.web.bind.annotation.RestController;

import com.google.gson.Gson;

import java.sql.Statement;
import java.util.ArrayList;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;


@RestController
public class articolo_controller {
    @RequestMapping(value ="/articoli", method=RequestMethod.GET)
    public String articoli(){
        try{
            String sqlConnectionString = "jdbc:sqlserver://localhost;databaseName=Gestionale;integratedSecurity=true; encrypt=true;trustServerCertificate=true;";
            ResultSet result_set = null;
            Connection conn = DriverManager.getConnection(sqlConnectionString);
            Statement view_all_statement = conn.createStatement();
            String sql = "SELECT * FROM articoli";
            result_set = view_all_statement.executeQuery(sql);
        
            ArrayList<articolo> articoli = new ArrayList<articolo>();
            while (result_set.next()) {
                articolo articolo = new articolo();
                articolo.setId(result_set.getInt("id"));
                articolo.setNome(result_set.getString("nome"));
                articolo.setDescrizione(result_set.getString("descrizione"));
                articolo.setPrezzo(result_set.getDouble("prezzo"));
                articolo.setGiacenza(result_set.getInt("giacenza"));
                articolo.setIva(result_set.getInt("AliquotaIva"));
                articoli.add(articolo);
            }
            Gson gson = new Gson();
            String json = gson.toJson(articoli);
            return json;
        }
        catch(Exception e){
            System.out.println(e);
        }
    return null;
}

@RequestMapping(value ="/articoli/prezzoMaxString", method=RequestMethod.GET)
public String articoloPrezzoMax(@RestParam String prezzoMaxString){
    try{
        String sqlConnectionString = "jdbc:sqlserver://localhost;databaseName=Gestionale;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
        ResultSet result_set = null;
        Connection conn = DriverManager.getConnection(sqlConnectionString);
        String sql = "SELECT * FROM articoli WHERE Prezzo <= ?";
        PreparedStatement preparedStatement = conn.prepareStatement(sql);
        Double prezzoMax = Double.parseDouble(prezzoMaxString);
        preparedStatement.setDouble(1, prezzoMax);
        result_set = preparedStatement.executeQuery();        
        
            ArrayList<articolo> articoli = new ArrayList<articolo>();
            while (result_set.next()) {
                articolo articolo = new articolo();
                articolo.setId(result_set.getInt("id"));
                articolo.setNome(result_set.getString("nome"));
                articolo.setDescrizione(result_set.getString("descrizione"));
                articolo.setPrezzo(result_set.getDouble("prezzo"));
                articolo.setGiacenza(result_set.getInt("giacenza"));
                articolo.setIva(result_set.getInt("AliquotaIva"));
                articoli.add(articolo);
            }
            Gson gson = new Gson();
            String json = gson.toJson(articoli);
            return json;
    }
    catch(Exception e){
        System.out.println(e);
    }
    return null;
}

//Insert articolo
@PostMapping(value ="/aggiungiArticoli", consumes = "application/json", produces = "application/json")
public String insertArticolo(@RequestBody articolo articolo){
        System.out.println(articolo.getNome());
    try{
         String sqlConnectionString = "jdbc:sqlserver://localhost;databaseName=Gestionale;integratedSecurity=true;encrypt=true;trustServerCertificate=true;";
         Connection conn = DriverManager.getConnection(sqlConnectionString);
         String sql = "INSERT INTO Articoli (Nome, Descrizione, Prezzo, Giacenza, AliquotaIva) VALUES (?, ?, ?, ?, ?)";
         PreparedStatement preparedStatement = conn.prepareStatement(sql);
         preparedStatement.setString(1, articolo.getNome());
         preparedStatement.setString(2, articolo.getDescrizione());
         preparedStatement.setDouble(3, articolo.getPrezzo());
         preparedStatement.setInt(4, articolo.getGiacenza());
         preparedStatement.setInt(5, articolo.getIva());
         preparedStatement.executeUpdate();
        return "Articolo inserito";
    }
    catch(Exception e){
        System.out.println(e);
    }
    return null;
}
}
