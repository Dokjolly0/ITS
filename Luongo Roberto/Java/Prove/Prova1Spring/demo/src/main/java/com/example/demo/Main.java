// package org.example;
// import com.microsoft.sqlserver.jdbc.SQLServerDriver;

// import java.sql.*;
// import java.util.Scanner;

// public class Main {
//     public static void main(String[] args) throws SQLException {
//         Scanner scanner = new Scanner(System.in);
//         int numero = 1;
//         Connection conn = null;
//         try
//         {
//             //Provo a connettermi al server
//             //Registriamo il driver per accedere a SQL Server
//             DriverManager.registerDriver(new SQLServerDriver());
//             System.out.println("Registrazione driver riuscita");

//             String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true; encrypt=true;trustServerCertificate=true;";
//             conn = DriverManager.getConnection(connectionString);
//         }
//         catch(Exception e)
//         {
//             System.out.println("Errore di connessione al database");
//         }
//         if(conn != null)
//         {
//             while(numero >= 1 && numero <= 5)
//             {
//                 System.out.println();
//                 System.out.println();
//                 System.out.println("Inserisci un numero da 1 a 5:");
//                 System.out.println("1. Inserimento nuovo ordine");
//                 System.out.println("2. Calcola fabbisopgni per un ordine");
//                 System.out.println("3. Visualizza fabbisogni per un ordine");
//                 System.out.println("4. Scarico magazzino");
//                 System.out.println("5. Esci dal menu");

//                 numero = scanner.nextInt();

//                 if(numero == 1)
//                 {
//                     System.out.println("Inserisci la tipologia di veicolo (A/B o 'exit' per uscire)");
//                     String tipologia = scanner.nextLine();
//                     while(!tipologia.equalsIgnoreCase("A") && !tipologia.equalsIgnoreCase("B") && !tipologia.equalsIgnoreCase("exit"))
//                     {
//                         System.out.println("Inserisci 'A' o 'B' o 'exit' per uscire dal menu");
//                         tipologia = scanner.nextLine();
//                     }
//                     int scarico = 0;
//                     if(tipologia.equalsIgnoreCase("A"))
//                     {
//                         int articoloId = 1;
//                         System.out.println("Inserisci la quantità da produrre");
//                         int quantitaDaProdurre = scanner.nextInt();
//                         try
//                         {
//                             String stringaSql1 = "INSERT INTO Ordini (ArticoloId, QuantitaDaProdurre, ScaricoEffettuato) VALUES (?, ?, ?);";
//                             PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
//                             preparedStatement.setInt(1, articoloId);
//                             preparedStatement.setInt(2, quantitaDaProdurre);
//                             preparedStatement.setInt(3, scarico);
//                             int rowsInserted1 = preparedStatement.executeUpdate();
//                             if(rowsInserted1 > 0)
//                             {
//                                 System.out.println("Ordine inserito");
//                             }
//                             else
//                             {
//                                 System.out.println("Errore nell'inserimento dell'ordine, ordine non inserito");
//                             }
//                         }
//                         catch(Exception e)
//                         {
//                             System.out.println("Errore nell'inserimento dell'ordine");
//                         }

//                     }
//                     else if(tipologia.equalsIgnoreCase("B"))
//                     {
//                         int articoloId = 2;
//                         System.out.println("Inserisci la quantità da produrre");
//                         int quantitaDaProdurre = scanner.nextInt();
//                         try
//                         {
//                             String stringaSql1 = "INSERT INTO Ordini (ArticoloId, QuantitaDaProdurre, ScaricoEffettuato) VALUES (?, ?, ?);";
//                             PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
//                             preparedStatement.setInt(1, articoloId);
//                             preparedStatement.setInt(2, quantitaDaProdurre);
//                             preparedStatement.setInt(3, scarico);
//                             int rowsInserted1 = preparedStatement.executeUpdate();
//                             if(rowsInserted1 > 0)
//                             {
//                                 System.out.println("Ordine inserito");
//                             }
//                             else
//                             {
//                                 System.out.println("Errore nell'inserimento dell'ordine, ordine non inserito");
//                             }
//                         }
//                         catch(Exception e)
//                         {
//                             System.out.println("Errore nell'inserimento dell'ordine");
//                         }
//                     }
//                     else if(tipologia.equalsIgnoreCase("exit"))
//                     {
//                         System.out.println("Uscita dal menu...");
//                         continue;
//                     }
//                 }
//                 else if(numero == 2)
//                 {
//                         try {
//                             System.out.println("Inserisci l'ID dell'Ordine");
//                             int OrdineID = scanner.nextInt();
//                             String checkOrderSql = "SELECT * FROM Fabbisogni WHERE OrdineId = ?";
//                             PreparedStatement preparedStatementCheck = conn.prepareStatement(checkOrderSql);
//                             preparedStatementCheck.setInt(1, OrdineID);
//                             ResultSet resultSet = preparedStatementCheck.executeQuery();
//                             int rowsUpdated = preparedStatementCheck.executeUpdate();
//                                 if (rowsUpdated == 0) {
//                                     System.out.println("Fabbisogno non inserito");
//                                 }
//                             if (resultSet.next()) {
//                                 //se ritorna true, significa che esistono dei fabbisogni, quindi devo andare ad eliminarli
//                                 String deleteFabbisogni = "DELETE FROM Fabbisogni WHERE OrdineId = ?";
//                                 PreparedStatement deleteStatement = conn.prepareStatement(deleteFabbisogni);
//                                 deleteStatement.setInt(1, OrdineID);
//                                 deleteStatement.execute();
//                             }
//                             //se esistevano dei fabbisogni ora solo eliminati
//                             //in caso contrario, non esistevano, posso inserirli

//                             //devo ottenere gli articoli e le quantitÃ  necessarie
//                             String getArticoliQuantita = "SELECT ArticoloId, QuantitaDaProdurre from Ordini where OrdineId = ?";
//                             PreparedStatement getStatement = conn.prepareStatement(getArticoliQuantita);
//                             getStatement.setInt(1, OrdineID);
//                             ResultSet getResult = getStatement.executeQuery();
//                             int ArticoloID = 0, QuantitàDaProdurre = 0;
//                             if (getResult.next()) {
// //                            System.out.print(resultSet.getString("NomeArticolo") + " ");
//                                 ArticoloID = getResult.getInt("ArticoloId");
//                                 QuantitàDaProdurre = getResult.getInt("QuantitaDaProdurre");
//                             }
//                             //query nei legami, ottengo figlio id e coefficiente
//                             String selectLegami = "SELECT IdFiglio, CoefficenteFabbisogno FROM Legami where IdPadre = ?";
//                             PreparedStatement selectLegamiStatement1 = conn.prepareStatement(selectLegami);
//                             selectLegamiStatement1.setInt(1, ArticoloID);
//                             ResultSet resultSelect1 = selectLegamiStatement1.executeQuery();
//                             while (resultSelect1.next()) {
//                                 int ArticoloFiglio = resultSelect1.getInt("IdFiglio");
//                                 int CoefficienteFabbisogno = resultSelect1.getInt("CoefficenteFabbisogno");

//                                 int QuantitàFabbisogno = CoefficienteFabbisogno * QuantitàDaProdurre;
//                                 //per ogni articolo figlio ( semi lavorato ) di un determinato articolo padre ( prodotto finito ),
//                                 //genero un fabbisogno con figlio e quantita
//                                 String insertFabbisogni = "INSERT INTO Fabbisogni (OrdineId, ArticoloId, QuantitaFabbisogno) values (?,?,?)";
//                                 PreparedStatement insertStatement = conn.prepareStatement(insertFabbisogni);
//                                 //ArticoloID = figlioid
//                                 //quantitaFabbisogno = coefficiente * quantita da produrre
//                                 insertStatement.setInt(1, OrdineID);
//                                 insertStatement.setInt(2, ArticoloFiglio);
//                                 insertStatement.setInt(3, QuantitàFabbisogno);
//                                 insertStatement.execute();
//                             }
//                         } catch (Exception ex) {
//                             System.out.println("Errore nel calcolo del fabbisogno" + ex.getMessage());
//                         }



//                     }
//                 else if(numero == 3)
//                 {
//                     try {
//                         System.out.println("Inserisci l'ID di cui vuoi visualizzare i fabbisogni");
//                         int OrdineId = scanner.nextInt();
//                         String MostraFabbisogni = "SELECT QuantitaFabbisogno, ArticoloId FROM Fabbisogni WHERE OrdineId = ?";
//                         PreparedStatement getStatement = conn.prepareStatement(MostraFabbisogni);
//                         getStatement.setInt(1, OrdineId);
//                         ResultSet getResult = getStatement.executeQuery();
//                         while (getResult.next()) {
//                             int ArticoloID = getResult.getInt("ArticoloID");
//                             int Quantita = getResult.getInt("QuantitaFabbisogno");
//                             System.out.print("ArticoloID: " + ArticoloID + "\n");
//                             System.out.println("Quantità Fabbisogno: " + Quantita);
//                         }
//                         int rowsUpdated = getStatement.executeUpdate();
//                         if (rowsUpdated > 0) {
//                             System.out.println("Fabbisogni visualizzati con successo");
//                         }
//                         else if (rowsUpdated == 0) {
//                             System.out.println("Non ci sono fabbisogni per l'ordine selezionato");
//                         }
//                     }catch(Exception exe) {
//                         System.out.println("Errore " + exe.getMessage());
//                         System.out.println();
//                         System.out.println();
//                         System.out.println("Inserisci un numero valido da 1 a 5");
//                         System.out.println("1. Inserimento nuovo ordine");
//                         System.out.println("2. Calcola fabbisopgni per un ordine");
//                         System.out.println("3. Visualizza fabbisogni per un ordine");
//                         System.out.println("4. Scarico magazzino");
//                         System.out.println("5. Esci dal menu");

//                         numero = scanner.nextInt();
//                     }

//                 }
//                 else if(numero == 4)
//                 {
//                     try {
//                         System.out.println("Inserisci l'ID  dell'Ordine");
//                         int ordineID = scanner.nextInt();
//                         String AggiornaGiacenza = "SELECT ArticoloId, QuantitaFabbisogno FROM Fabbisogni WHERE OrdineId = ?";
//                         PreparedStatement preparedStatement = conn.prepareStatement(AggiornaGiacenza);
//                         try {
//                             preparedStatement.setInt(1, ordineID);
//                         } catch(Exception exx) {
//                             System.out.println();
//                         }
//                         ResultSet resultSet = preparedStatement.executeQuery();
//                         while (resultSet.next()) {
//                             int ArticoloID = resultSet.getInt("ArticoloId");
//                             int quantitaFabbisogno = resultSet.getInt("QuantitaFabbisogno");
//                             //System.out.println("ArticoloID: " + ArticoloID + " Quantità Fabbisogno: " + quantitaFabbisogno);
//                             String queryAggGiac = "UPDATE Articolo SET Giacenza = Giacenza - ? WHERE ArticoloId = ?";
//                             try {
//                                 preparedStatement= conn.prepareStatement(queryAggGiac);
//                                 preparedStatement.setInt(1, quantitaFabbisogno);
//                                 preparedStatement.setInt(2, ArticoloID);
//                                 preparedStatement.executeUpdate();
//                             }
//                             catch(Exception ess) {
//                                 System.out.println();
//                             }
//                         }
//                         String Aggiornamento = "UPDATE Ordini SET ScaricoEffettuato = ? WHERE OrdineId = ?";
//                         try {
//                             preparedStatement = conn.prepareStatement(Aggiornamento);
//                             preparedStatement.setBoolean(1, true);
//                             preparedStatement.setInt(2, ordineID);
//                             preparedStatement.executeUpdate();
//                             int rowsUpdated = preparedStatement.executeUpdate();
//                             if (rowsUpdated > 0) {
//                                 System.out.println("Lo scarico magazzino per l'OrdineID " + ordineID + " è stato effettuato con successo.");
//                             }
//                         } catch(Exception ev) {
//                             System.out.println(ev.getMessage());
//                         } System.out.println("Lo scarico magazzino per l'OrdineID " + ordineID + " è stato effettuato con successo.");
//                     }
//                     catch(Exception ex) {
//                         System.out.println("Errore" + ex.getMessage());
//                     }

//                 }
//                 else if(numero == 5)
//                 {
//                     return;
//                 }
//                 else
//                 {
//                     System.out.println();
//                     System.out.println();
//                     System.out.println("Inserisci un numero valido da 1 a 5");
//                     System.out.println("1. Inserimento nuovo ordine");
//                     System.out.println("2. Calcola fabbisopgni per un ordine");
//                     System.out.println("3. Visualizza fabbisogni per un ordine");
//                     System.out.println("4. Scarico magazzino");
//                     System.out.println("5. Esci dal menu");

//                     numero = scanner.nextInt();
//                 }
//             }
//         }
//         else
//         {
//             System.out.println("Connessione fallita");
//         }
//     }
// }

// Convert this project to spring boot project
// Add the following dependencies to the pom.xml file
// <dependency>
//     <groupId>org.springframework.boot</groupId>
//     <artifactId>spring-boot-starter-data-jpa</artifactId>
// </dependency>
// <dependency>
//     <groupId>org.springframework.boot</groupId>
//     <artifactId>spring-boot-starter-web</artifactId>
// </dependency>
// <dependency>
//     <groupId>com.microsoft.sqlserver</groupId>
//     <artifactId>mssql-jdbc</artifactId>
//     <version>9.2.1.jre11</version>
// </dependency>

// Path: src/main/java/com/example/demo/Main.java
// package com.example.demo;
// import com.microsoft.sqlserver.jdbc.SQLServerDriver;

// import org.springframework.boot.SpringApplication;
// import org.springframework.boot.autoconfigure.SpringBootApplication;

// import java.sql.*;

// @SpringBootApplication
// public class Main {
//     public static void main(String[] args) {
//         SpringApplication.run(Main.class, args);
//     }
// }

// Path: src/main/java/com/example/demo/Controller.java
// package com.example.demo;
// import org.springframework.web.bind.annotation.GetMapping;
// import org.springframework.web.bind.annotation.RestController;

// @RestController
// public class Controller {
//     @GetMapping("/")
//     public String home() {
//         return "Hello World!";
//     }
// }

// Path: src/main/resources/application.properties
// spring.datasource.url=jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true; encrypt=true;trustServerCertificate=true;
// spring.datasource.driver-class-name=com.microsoft.sqlserver.jdbc.SQLServerDriver
// spring.jpa.show-sql=true
// spring.jpa.hibernate.ddl-auto=update

// Run the application and go to http://localhost:8080/ to see the output
// The application will connect to the database and display "Hello World!" on the browser

// Now, let's create the database and tables
// Open SQL Server Management Studio
// Create a new database called AziendaModellismo
// Create the following tables
// CREATE TABLE Articolo (
//     ArticoloId INT PRIMARY KEY,
//     NomeArticolo VARCHAR(255),
//     Giacenza INT
// );

// CREATE TABLE Ordini (
//     OrdineId INT PRIMARY KEY,
//     ArticoloId INT,
//     QuantitaDaProdurre INT,
//     ScaricoEffettuato BIT,
//     FOREIGN KEY (ArticoloId) REFERENCES Articolo(ArticoloId)
// );

// CREATE TABLE Legami (
//     IdPadre INT,
//     IdFiglio INT,
//     CoefficienteFabbisogno INT,
//     FOREIGN KEY (IdPadre) REFERENCES Articolo(ArticoloId),
//     FOREIGN KEY (IdFiglio) REFERENCES Articolo(ArticoloId)
// );

// CREATE TABLE Fabbisogni (
//     FabbisognoId INT PRIMARY KEY,
//     OrdineId INT,
//     ArticoloId INT,
//     QuantitaFabbisogno INT,
//     FOREIGN KEY (OrdineId) REFERENCES Ordini(OrdineId),
//     FOREIGN KEY (ArticoloId) REFERENCES Articolo(ArticoloId)
// );

// Insert some data into the tables
// INSERT INTO Articolo (ArticoloId, NomeArticolo, Giacenza) VALUES (1, 'Prodotto A', 100);
// INSERT INTO Articolo (ArticoloId, NomeArticolo, Giacenza) VALUES (2, 'Prodotto B', 200);
// INSERT INTO Legami (IdPadre, IdFiglio, CoefficienteFabbisogno) VALUES (1, 3, 2);
// INSERT INTO Legami (IdPadre, IdFiglio, CoefficienteFabbisogno) VALUES (1, 4, 3);
// INSERT INTO Legami (IdPadre, IdFiglio, CoefficienteFabbisogno) VALUES (2, 5, 4);
// INSERT INTO Legami (IdPadre, IdFiglio, CoefficienteFabbisogno) VALUES (2, 6, 5);

// Now, let's create the models
// Path: src/main/java/com/example/demo/Articolo.java
// package com.example.demo;
// import javax.persistence.Entity;
// import javax.persistence.Id;

// @Entity
// public class Articolo {
//     @Id
//     private int ArticoloId;
//     private String NomeArticolo;
//     private int Giacenza;

//     public int getArticoloId() {
//         return ArticoloId;
//     }

//     public void setArticoloId(int articoloId) {
//         ArticoloId = articoloId;
//     }

//     public String getNomeArticolo() {
//         return NomeArticolo;
//     }

//     public void setNomeArticolo(String nomeArticolo) {
//         NomeArticolo = nomeArticolo;
//     }

//     public int getGiacenza() {
//         return Giacenza;
//     }

//     public void setGiacenza(int giacenza) {
//         Giacenza = giacenza;
//     }

//     @Override
//     public String toString() {
//         return "Articolo{" +
//                 "ArticoloId=" + ArticoloId +
//                 ", NomeArticolo='" + NomeArticolo + '\'' +
//                 ", Giacenza=" + Giacenza +
//                 '}';
//     }
// }

// Path: src/main/java/com/example/demo/Ordini.java
// package com.example.demo;

// import javax.persistence.Entity;
// import javax.persistence.Id;

// @Entity
// public class Ordini {
//     @Id
//     private int OrdineId;
//     private int ArticoloId;
//     private int QuantitaDaProdurre;
//     private boolean ScaricoEffettuato;

//     public int getOrdineId() {
//         return OrdineId;
//     }

//     public void setOrdineId(int ordineId) {
//         OrdineId = ordineId;
//     }

//     public int getArticoloId() {
//         return ArticoloId;
//     }

//     public void setArticoloId(int articoloId) {
//         ArticoloId = articoloId;
//     }

//     public int getQuantitaDaProdurre() {
//         return QuantitaDaProdurre;
//     }

//     public void setQuantitaDaProdurre(int quantitaDaProdurre) {
//         QuantitaDaProdurre = quantitaDaProdurre;
//     }

//     public boolean isScaricoEffettuato() {
//         return ScaricoEffettuato;
//     }

//     public void setScaricoEffettuato(boolean scaricoEffettuato) {
//         ScaricoEffettuato = scaricoEffettuato;
//     }

//     @Override
//     public String toString() {
//         return "Ordini{" +

//                 "OrdineId=" + OrdineId +
//                 ", ArticoloId=" + ArticoloId +
//                 ", QuantitaDaProdurre=" + QuantitaDaProdurre +
//                 ", ScaricoEffettuato=" + ScaricoEffettuato +
//                 '}';

//     }

// }

// Path: src/main/java/com/example/demo/Legami.java
// package com.example.demo;

// import javax.persistence.Entity;
// import javax.persistence.Id;

// @Entity
// public class Legami {
//     @Id
//     private int IdPadre;
//     private int IdFiglio;
//     private int CoefficienteFabbisogno;

//     public int getIdPadre() {
//         return IdPadre;
//     }

//     public void setIdPadre(int idPadre) {
//         IdPadre = idPadre;
//     }

//     public int getIdFiglio() {
//         return IdFiglio;
//     }


//     public void setIdFiglio(int idFiglio) {
//         IdFiglio = idFiglio;
//     }

//     public int getCoefficienteFabbisogno() {
//         return CoefficienteFabbisogno;
//     }

//     public void setCoefficienteFabbisogno(int coefficienteFabbisogno) {
//         CoefficienteFabbisogno = coefficienteFabbisogno;
//     }

//     @Override
//     public String toString() {
//         return "Legami{" +
//                 "IdPadre=" + IdPadre +
//                 ", IdFiglio=" + IdFiglio +
//                 ", CoefficienteFabbisogno=" + CoefficienteFabbisogno +
//                 '}';
//     }
// }

// Path: src/main/java/com/example/demo/Fabbisogni.java
// package com.example.demo;

// import javax.persistence.Entity;
// import javax.persistence.Id;

// @Entity
// public class Fabbisogni {
//     @Id
//     private int FabbisognoId;
//     private int OrdineId;
//     private int ArticoloId;
//     private int QuantitaFabbisogno;

//     public int getFabbisognoId() {
//         return FabbisognoId;
//     }

//     public void setFabbisognoId(int fabbisognoId) {
//         FabbisognoId = fabbisognoId;
//     }

//     public int getOrdineId() {
//         return OrdineId;
//     }

//     public void setOrdineId(int ordineId) {
//         OrdineId = ordineId;
//     }

//     public int getArticoloId() {
//         return ArticoloId;
//     }

//     public void setArticoloId(int articoloId) {
//         ArticoloId = articoloId;
//     }

//     public int getQuantitaFabbisogno() {
//         return QuantitaFabbisogno;
//     }

//     public void setQuantitaFabbisogno(int quantitaFabbisogno) {
//         QuantitaFabbisogno = quantitaFabbisogno;
//     }

//     @Override
//     public String toString() {
//         return "Fabbisogni{" +
//                 "FabbisognoId=" + FabbisognoId +
//                 ", OrdineId=" + OrdineId +
//                 ", ArticoloId=" + ArticoloId +
//                 ", QuantitaFabbisogno=" + QuantitaFabbisogno +
//                 '}';

//     }
// }

// Now, let's create the repositories
// Path: src/main/java/com/example/demo/ArticoloRepository.java
// package com.example.demo;
// import org.springframework.data.jpa.repository.JpaRepository;

// public interface ArticoloRepository extends JpaRepository<Articolo, Integer> {
// }

// Path: src/main/java/com/example/demo/OrdiniRepository.java
// package com.example.demo;
// import org.springframework.data.jpa.repository.JpaRepository;

// public interface OrdiniRepository extends JpaRepository<Ordini, Integer> {
// }

// Path: src/main/java/com/example/demo/LegamiRepository.java
// package com.example.demo;
// import org.springframework.data.jpa.repository.JpaRepository;

// public interface LegamiRepository extends JpaRepository<Legami, Integer> {
// }

// Path: src/main/java/com/example/demo/FabbisogniRepository.java
// package com.example.demo;
// import org.springframework.data.jpa.repository.JpaRepository;


// public interface FabbisogniRepository extends JpaRepository<Fabbisogni, Integer> {
// }
