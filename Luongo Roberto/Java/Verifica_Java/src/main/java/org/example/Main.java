package org.example;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numero = 1;
        Connection conn = null;
        try
        {
            //Provo a connettermi al server
            //Registriamo il driver per accedere a SQL Server
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
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
                    int scarico = 1;
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
                            int rowsInserted = preparedStatement.executeUpdate();
                            if(rowsInserted > 0)
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
                            int rowsInserted = preparedStatement.executeUpdate();
                            if(rowsInserted > 0)
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







//                    System.out.print("Inserisci il nome dell'articolo\n");
//                    String nome = scanner.nextLine();
//
//                    System.out.println("Inserisci la descrizione dell'articolo");
//                    String descrizione = scanner.nextLine();
//
//                    System.out.println("Inserisci la giacenza dell'articolo");
//                    int giacenza = scanner.nextInt();
//
//                    System.out.println("Inserisci l'aliquota IVA dell'articolo");
//                    int iva = scanner.nextInt();
//
//                    System.out.println("Inserisci il prezzo dell'articolo");
//                    int prezzo = scanner.nextInt();
//
//                    String stringaSql1 = "";
//                    PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
//                    preparedStatement.setString(1, nome);
//                    preparedStatement.setString(2, descrizione);
//                    preparedStatement.setInt(3, giacenza);
//                    preparedStatement.setInt(4, iva);
//                    preparedStatement.setInt(5, prezzo);
//                    int rowsInserted = preparedStatement.executeUpdate();
//                    if(rowsInserted > 0){
//                        System.out.println("Articolo inserito");
//                    }else{
//                        System.out.println("Errore nell'inserimento dell'articolo, articolo non inserito");
//                    }
                }
                else if(numero == 2)
                {
//                System.out.println("Calcola fabbisogni per un ordine");
                }
                else if(numero == 3)
                {
//                System.out.println("Visualizza fabbisogni per un ordine");
                }
                else if(numero == 4)
                {
//                System.out.println("Scarico magazzino");
                }
                else if(numero == 5)
                {
                    return;
                }
                else
                {
                    System.out.println("Inserisci un numero da 1 a 5");
                }
            }
        }
        else
        {
            System.out.println("Connessione fallita");
        }
    }
}
