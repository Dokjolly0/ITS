package org.example;
import com.microsoft.sqlserver.jdbc.SQLServerDriver;

import java.sql.*;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) throws SQLException {
        Scanner scanner = new Scanner(System.in);
        int numero = 1;
        Connection conn = null;
        try
        {
            //Provo a connettermi al server
            //Registriamo il driver per accedere a SQL Server
            DriverManager.registerDriver(new SQLServerDriver());
            System.out.println("Registrazione driver riuscita");

            String connectionString = "jdbc:sqlserver://localhost;databaseName=AziendaModellismo;integratedSecurity=true; encrypt=true;trustServerCertificate=true;";
            conn = DriverManager.getConnection(connectionString);
        }
        catch(Exception e)
        {
            System.out.println("Errore di connessione al database");
        }
        if(conn != null)
        {
            while(numero >= 1 && numero <= 5)
            {
                System.out.println();
                System.out.println();
                System.out.println("Inserisci un numero da 1 a 5:");
                System.out.println("1. Inserimento nuovo ordine");
                System.out.println("2. Calcola fabbisopgni per un ordine");
                System.out.println("3. Visualizza fabbisogni per un ordine");
                System.out.println("4. Scarico magazzino");
                System.out.println("5. Esci dal menu");

                numero = scanner.nextInt();

                if(numero == 1)
                {
                    System.out.println("Inserisci la tipologia di veicolo (A/B o 'exit' per uscire)");
                    String tipologia = scanner.nextLine();
                    while(!tipologia.equalsIgnoreCase("A") && !tipologia.equalsIgnoreCase("B") && !tipologia.equalsIgnoreCase("exit"))
                    {
                        System.out.println("Inserisci 'A' o 'B' o 'exit' per uscire dal menu");
                        tipologia = scanner.nextLine();
                    }
                    int scarico = 0;
                    if(tipologia.equalsIgnoreCase("A"))
                    {
                        int articoloId = 1;
                        System.out.println("Inserisci la quantità da produrre");
                        int quantitaDaProdurre = scanner.nextInt();
                        try
                        {
                            String stringaSql1 = "INSERT INTO Ordini (ArticoloId, QuantitaDaProdurre, ScaricoEffettuato) VALUES (?, ?, ?);";
                            PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
                            preparedStatement.setInt(1, articoloId);
                            preparedStatement.setInt(2, quantitaDaProdurre);
                            preparedStatement.setInt(3, scarico);
                            int rowsInserted1 = preparedStatement.executeUpdate();
                            if(rowsInserted1 > 0)
                            {
                                System.out.println("Ordine inserito");
                            }
                            else
                            {
                                System.out.println("Errore nell'inserimento dell'ordine, ordine non inserito");
                            }
                        }
                        catch(Exception e)
                        {
                            System.out.println("Errore nell'inserimento dell'ordine");
                        }

                    }
                    else if(tipologia.equalsIgnoreCase("B"))
                    {
                        int articoloId = 2;
                        System.out.println("Inserisci la quantità da produrre");
                        int quantitaDaProdurre = scanner.nextInt();
                        try
                        {
                            String stringaSql1 = "INSERT INTO Ordini (ArticoloId, QuantitaDaProdurre, ScaricoEffettuato) VALUES (?, ?, ?);";
                            PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
                            preparedStatement.setInt(1, articoloId);
                            preparedStatement.setInt(2, quantitaDaProdurre);
                            preparedStatement.setInt(3, scarico);
                            int rowsInserted1 = preparedStatement.executeUpdate();
                            if(rowsInserted1 > 0)
                            {
                                System.out.println("Ordine inserito");
                            }
                            else
                            {
                                System.out.println("Errore nell'inserimento dell'ordine, ordine non inserito");
                            }
                        }
                        catch(Exception e)
                        {
                            System.out.println("Errore nell'inserimento dell'ordine");
                        }
                    }
                    else if(tipologia.equalsIgnoreCase("exit"))
                    {
                        System.out.println("Uscita dal menu...");
                        continue;
                    }
                }
                else if(numero == 2)
                {
                        try {
                            System.out.println("Inserisci l'ID dell'Ordine");
                            int OrdineID = scanner.nextInt();
                            String checkOrderSql = "SELECT * FROM Fabbisogni WHERE OrdineId = ?";
                            PreparedStatement preparedStatementCheck = conn.prepareStatement(checkOrderSql);
                            preparedStatementCheck.setInt(1, OrdineID);
                            ResultSet resultSet = preparedStatementCheck.executeQuery();
                            int rowsUpdated = preparedStatementCheck.executeUpdate();
                                if (rowsUpdated == 0) {
                                    System.out.println("Fabbisogno non inserito");
                                }
                            if (resultSet.next()) {
                                //se ritorna true, significa che esistono dei fabbisogni, quindi devo andare ad eliminarli
                                String deleteFabbisogni = "DELETE FROM Fabbisogni WHERE OrdineId = ?";
                                PreparedStatement deleteStatement = conn.prepareStatement(deleteFabbisogni);
                                deleteStatement.setInt(1, OrdineID);
                                deleteStatement.execute();
                            }
                            //se esistevano dei fabbisogni ora solo eliminati
                            //in caso contrario, non esistevano, posso inserirli

                            //devo ottenere gli articoli e le quantitÃ  necessarie
                            String getArticoliQuantita = "SELECT ArticoloId, QuantitaDaProdurre from Ordini where OrdineId = ?";
                            PreparedStatement getStatement = conn.prepareStatement(getArticoliQuantita);
                            getStatement.setInt(1, OrdineID);
                            ResultSet getResult = getStatement.executeQuery();
                            int ArticoloID = 0, QuantitàDaProdurre = 0;
                            if (getResult.next()) {
//                            System.out.print(resultSet.getString("NomeArticolo") + " ");
                                ArticoloID = getResult.getInt("ArticoloId");
                                QuantitàDaProdurre = getResult.getInt("QuantitaDaProdurre");
                            }
                            //query nei legami, ottengo figlio id e coefficiente
                            String selectLegami = "SELECT IdFiglio, CoefficenteFabbisogno FROM Legami where IdPadre = ?";
                            PreparedStatement selectLegamiStatement1 = conn.prepareStatement(selectLegami);
                            selectLegamiStatement1.setInt(1, ArticoloID);
                            ResultSet resultSelect1 = selectLegamiStatement1.executeQuery();
                            while (resultSelect1.next()) {
                                int ArticoloFiglio = resultSelect1.getInt("IdFiglio");
                                int CoefficienteFabbisogno = resultSelect1.getInt("CoefficenteFabbisogno");

                                int QuantitàFabbisogno = CoefficienteFabbisogno * QuantitàDaProdurre;
                                //per ogni articolo figlio ( semi lavorato ) di un determinato articolo padre ( prodotto finito ),
                                //genero un fabbisogno con figlio e quantita
                                String insertFabbisogni = "INSERT INTO Fabbisogni (OrdineId, ArticoloId, QuantitaFabbisogno) values (?,?,?)";
                                PreparedStatement insertStatement = conn.prepareStatement(insertFabbisogni);
                                //ArticoloID = figlioid
                                //quantitaFabbisogno = coefficiente * quantita da produrre
                                insertStatement.setInt(1, OrdineID);
                                insertStatement.setInt(2, ArticoloFiglio);
                                insertStatement.setInt(3, QuantitàFabbisogno);
                                insertStatement.execute();
                            }
                        } catch (Exception ex) {
                            System.out.println("Errore nel calcolo del fabbisogno" + ex.getMessage());
                        }



                    }
                else if(numero == 3)
                {
                    try {
                        System.out.println("Inserisci l'ID di cui vuoi visualizzare i fabbisogni");
                        int OrdineId = scanner.nextInt();
                        String MostraFabbisogni = "SELECT QuantitaFabbisogno, ArticoloId FROM Fabbisogni WHERE OrdineId = ?";
                        PreparedStatement getStatement = conn.prepareStatement(MostraFabbisogni);
                        getStatement.setInt(1, OrdineId);
                        ResultSet getResult = getStatement.executeQuery();
                        while (getResult.next()) {
                            int ArticoloID = getResult.getInt("ArticoloID");
                            int Quantita = getResult.getInt("QuantitaFabbisogno");
                            System.out.print("ArticoloID: " + ArticoloID + "\n");
                            System.out.println("Quantità Fabbisogno: " + Quantita);
                        }
                        int rowsUpdated = getStatement.executeUpdate();
                        if (rowsUpdated > 0) {
                            System.out.println("Fabbisogni visualizzati con successo");
                        }
                        else if (rowsUpdated == 0) {
                            System.out.println("Non ci sono fabbisogni per l'ordine selezionato");
                        }
                    }catch(Exception exe) {
                        System.out.println("Errore " + exe.getMessage());
                        System.out.println();
                        System.out.println();
                        System.out.println("Inserisci un numero valido da 1 a 5");
                        System.out.println("1. Inserimento nuovo ordine");
                        System.out.println("2. Calcola fabbisopgni per un ordine");
                        System.out.println("3. Visualizza fabbisogni per un ordine");
                        System.out.println("4. Scarico magazzino");
                        System.out.println("5. Esci dal menu");

                        numero = scanner.nextInt();
                    }

                }
                else if(numero == 4)
                {
                    try {
                        System.out.println("Inserisci l'ID  dell'Ordine");
                        int ordineID = scanner.nextInt();
                        String AggiornaGiacenza = "SELECT ArticoloId, QuantitaFabbisogno FROM Fabbisogni WHERE OrdineId = ?";
                        PreparedStatement preparedStatement = conn.prepareStatement(AggiornaGiacenza);
                        try {
                            preparedStatement.setInt(1, ordineID);
                        } catch(Exception exx) {
                            System.out.println();
                        }
                        ResultSet resultSet = preparedStatement.executeQuery();
                        while (resultSet.next()) {
                            int ArticoloID = resultSet.getInt("ArticoloId");
                            int quantitaFabbisogno = resultSet.getInt("QuantitaFabbisogno");
                            //System.out.println("ArticoloID: " + ArticoloID + " Quantità Fabbisogno: " + quantitaFabbisogno);
                            String queryAggGiac = "UPDATE Articolo SET Giacenza = Giacenza - ? WHERE ArticoloId = ?";
                            try {
                                preparedStatement= conn.prepareStatement(queryAggGiac);
                                preparedStatement.setInt(1, quantitaFabbisogno);
                                preparedStatement.setInt(2, ArticoloID);
                                preparedStatement.executeUpdate();
                            }
                            catch(Exception ess) {
                                System.out.println();
                            }
                        }
                        String Aggiornamento = "UPDATE Ordini SET ScaricoEffettuato = ? WHERE OrdineId = ?";
                        try {
                            preparedStatement = conn.prepareStatement(Aggiornamento);
                            preparedStatement.setBoolean(1, true);
                            preparedStatement.setInt(2, ordineID);
                            preparedStatement.executeUpdate();
                            int rowsUpdated = preparedStatement.executeUpdate();
                            if (rowsUpdated > 0) {
                                System.out.println("Lo scarico magazzino per l'OrdineID " + ordineID + " è stato effettuato con successo.");
                            }
                        } catch(Exception ev) {
                            System.out.println(ev.getMessage());
                        } System.out.println("Lo scarico magazzino per l'OrdineID " + ordineID + " è stato effettuato con successo.");
                    }
                    catch(Exception ex) {
                        System.out.println("Errore" + ex.getMessage());
                    }

                }
                else if(numero == 5)
                {
                    return;
                }
                else
                {
                    System.out.println();
                    System.out.println();
                    System.out.println("Inserisci un numero valido da 1 a 5");
                    System.out.println("1. Inserimento nuovo ordine");
                    System.out.println("2. Calcola fabbisopgni per un ordine");
                    System.out.println("3. Visualizza fabbisogni per un ordine");
                    System.out.println("4. Scarico magazzino");
                    System.out.println("5. Esci dal menu");

                    numero = scanner.nextInt();
                }
            }
        }
        else
        {
            System.out.println("Connessione fallita");
        }
    }
}
