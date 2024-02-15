package org.example;

import java.sql.*;
import java.util.Scanner;
//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        //A capo
        System.out.println("Ciao");
        //Non a capo
        System.out.print("Ciao");
        System.out.println();

        try{
            //Provo a connettermi al server
            //Registriamo il driver per accedere a SQL Server
            DriverManager.registerDriver(new com.microsoft.sqlserver.jdbc.SQLServerDriver());
            System.out.println("Registrazione driver riuscita");

            String connectionString = "jdbc:sqlserver://localhost;databaseName=Gestionale;integratedSecurity=true; encrypt=true;trustServerCertificate=true;";
            Connection conn = DriverManager.getConnection(connectionString);

            if(conn != null){
                System.out.println("Connessione riuscita");
                Scanner scanner = new Scanner(System.in);
                boolean verificaErrore = true;
                int numeroMenu = 1;
                while(numeroMenu >= 1 && numeroMenu <= 5 || verificaErrore == true){
                    verificaErrore  = false;
                        System.out.println();
                        System.out.println();
                        System.out.println("Seleziona un numero dal menu sottostante:");
                        System.out.println("1. Visualizza lista");
                        System.out.println("2. Inserisci nuovo articolo");
                        System.out.println("3. Elimina un aritcolo");
                        System.out.println("4. Aggiorna un articolo");
                        System.out.println("5. Esci dal menu");

                        try{
                            numeroMenu = scanner.nextInt();

                        }catch (Exception ex){
                            System.out.println("Inserisci un numero valido!");
                            verificaErrore = true;
                            numeroMenu = 0;
                            scanner.next();
                        }
                        if(numeroMenu ==1 ){
                            Statement myStatement = conn.createStatement();
                            String stringaSql = "SELECT * FROM Articoli";
                            ResultSet myResultSet = myStatement.executeQuery(stringaSql);
                            while(myResultSet.next()){
                                //Il numero è la colonna del DB
                                System.out.println();
                                System.out.println();
                                System.out.println("Prossimo articolo");
                                System.out.println("Id: " + myResultSet.getString(1) + " ");
                                System.out.println("Nome: " + myResultSet.getString(2));
                                System.out.println("Descrizione: " + myResultSet.getString(3));
                                System.out.println("Giacenza: " + myResultSet.getString(4));
                                System.out.println("Iva: " + myResultSet.getString(5));
                                System.out.println("Prezzo: " + myResultSet.getString(6));
                            }
                        } else if (numeroMenu == 2) {
                            Scanner scanner2 = new Scanner(System.in);
                            System.out.print("Inserisci il nome dell'articolo\n");
                            String nome = scanner2.nextLine();

                            System.out.println("Inserisci la descrizione dell'articolo");
                            String descrizione = scanner2.nextLine();

                            System.out.println("Inserisci la giacenza dell'articolo");
                            int giacenza = scanner2.nextInt();

                            System.out.println("Inserisci l'aliquota IVA dell'articolo");
                            int iva = scanner2.nextInt();

                            System.out.println("Inserisci il prezzo dell'articolo");
                            int prezzo = scanner2.nextInt();

                            String stringaSql1 = "INSERT INTO Articoli (Nome, Descrizione, Giacenza, AliquotaIva, Prezzo) VALUES (?, ?, ?, ?, ?)";
                            PreparedStatement preparedStatement = conn.prepareStatement(stringaSql1);
                            preparedStatement.setString(1, nome);
                            preparedStatement.setString(2, descrizione);
                            preparedStatement.setInt(3, giacenza);
                            preparedStatement.setInt(4, iva);
                            preparedStatement.setInt(5, prezzo);
                            int rowsInserted = preparedStatement.executeUpdate();
                            if(rowsInserted > 0){
                                System.out.println("Articolo inserito");
                            }else{
                                System.out.println("Errore nell'inserimento dell'articolo, articolo non inserito");
                            }
                        } else if (numeroMenu == 3) {
                            System.out.println("Inserisci l'id dell'articolo");
                            int idElimina = scanner.nextInt();

                            String stringaSql2 = "DELETE FROM Articoli WHERE Id = ?";
                            PreparedStatement preparedStatement2 = conn.prepareStatement(stringaSql2);
                            preparedStatement2.setInt(1, idElimina);
                            int rowsInserted2 = preparedStatement2.executeUpdate();
                            if(rowsInserted2 > 0){
                                System.out.println("Articolo eliminato");
                            }else{
                                System.out.println("Errore nell'eliminazione dell'articolo, articolo non eliminato");
                            }
                        } else if (numeroMenu == 4) {
                            System.out.println("Inserisci l'id dell'articolo");
                            int idUpdate = scanner.nextInt();
                            System.out.println("Inserisci la giacenza dell'articolo");
                            int idUpdateGiacenza = scanner.nextInt();

                            String stringaSql3 = "UPDATE Articoli SET Giacenza = ? WHERE Id = ?";
                            PreparedStatement preparedStatement3 = conn.prepareStatement(stringaSql3);
                            preparedStatement3.setInt(2, idUpdate);
                            preparedStatement3.setInt(1, idUpdateGiacenza);
                            int rowsInserted3 = preparedStatement3.executeUpdate();
                            if(rowsInserted3 > 0){
                                System.out.println("Articolo aggiornato");
                            }else{
                                System.out.println("Errore nell'aggiornamento dell'articolo, articolo non aggiornato");
                            }
                        } else if (numeroMenu == 5) {
                            //Esce dal main
                            System.exit(0);
                            //Uguale al return
                            //return;
                        }else{
                            System.out.println();
                            System.out.println();
                            System.out.println("Comando non esistente, inserisci un comando valido");
                            System.out.println("1. Visualizza lista");
                            System.out.println("2. Inserisci nuovo articolo");
                            System.out.println("3. Elimina un aritcolo");
                            System.out.println("4. Aggiorna un articolo");
                            System.out.println("5. Esci dal menu");
                        try{
                            numeroMenu = scanner.nextInt();

                        }catch (Exception ex){
                            System.out.println("Inserisci un numero valido!");
                            verificaErrore = true;
                            numeroMenu = 0;
                            scanner.next();
                        }
                        }
                }
                conn.close();
            }
        }
        catch (SQLException ex){
            System.out.println("Eccezzione: " + ex.getMessage());
        }
    }
}