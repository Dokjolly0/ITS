package org.example;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int numero = 1;
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
//                System.out.println("Inserisci un nuovo ordine");
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
}
