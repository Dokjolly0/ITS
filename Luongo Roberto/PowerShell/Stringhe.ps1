#Metodi per le stringhe
$stringa = "Ciao mondo"
write-host $stringa

write-host $stringa.Length
# output: 10, restituisce la lunghezza della stringa
write-host $stringa.ToUpper()
# output: CIAO MONDO, trasforma la stringa in maiuscolo
write-host $stringa.ToLower()
# output: ciao mondo, trasforma la stringa in minuscolo
write-host $stringa.Substring(0, 4)
# output: Ciao, restituisce una sottostringa a partire da un indice e per una lunghezza
write-host $stringa.Replace("Ciao", "Hello")
# output: Hello mondo, sostituisce una sottostringa con un'altra
write-host $stringa.Split(" ")
# output: Ciao, mondo, divide la stringa in base a un separatore
write-host $stringa.Contains("Ciao")
# output: True, verifica se una stringa contiene un'altra
write-host $stringa.StartsWith("Ciao")
# output: True, verifica se una stringa inizia con un'altra
write-host $stringa.EndsWith("Ciao")
# output: False, verifica se una stringa finisce con un'altra
write-host $stringa.IndexOf("m")
# output: 5, restituisce l'indice della prima occorrenza di una sottostringa
write-host $stringa.LastIndexOf("o")
# output: 9, restituisce l'indice dell'ultima occorrenza di una sottostringa
write-host $stringa.Insert(5, " bello")
# output: Ciao bello mondo, inserisce una sottostringa in una posizione specifica
write-host $stringa.Remove(5, 5)
# output: Ciao mondo, rimuove una sottostringa a partire da un indice e per una lunghezza
write-host $stringa.PadLeft(10)
# output: "          Ciao mondo", aggiunge spazi a sinistra fino a raggiungere una lunghezza
write-host $stringa.PadRight(10)
# output: "Ciao mondo          ", aggiunge spazi a destra fino a raggiungere una lunghezza
write-host $stringa.Trim()
# output: Ciao mondo, rimuove gli spazi iniziali e finali
write-host $stringa.TrimStart()
# output: Ciao mondo, rimuove gli spazi iniziali
write-host $stringa.TrimEnd()
# output: Ciao mondo, rimuove gli spazi finali
write-host $stringa.ToCharArray()
# output: System.Char[], restituisce un array di caratteri
write-host $stringa.ToCharArray().GetType()
# output: System.Char[], restituisce il tipo dell'array di caratteri
write-host $stringa.ToCharArray().Length
# output: 10, restituisce la lunghezza dell'array di caratteri
write-host $stringa.ToCharArray()[0]
# output: C, restituisce il primo carattere dell'array
Clear-Host

#Esercizio, conta il numero di occorrenze di una parola in una frase
$frase = "ciao ciao ciao ciao ciao ciao amici amici amici amici amici" 
write-host "Totale parole frase:" $frase.Split(" ").Count
write-host "Totale ciao: "$frase.Split(" ").Where({$_ -eq "ciao"}).Count
write-host "Totale amici "$frase.Split(" ").Where({$_ -eq "amici"}).Count
Clear-Host







$testo = Get-Content -Path "C:\Users\violatto_a\Desktop\ITS\Luongo Roberto\PowerShell\promessi_sposi.txt"
write-host "Totale parole frase:" $testo.Split(" ").Count
#Trova la parola più frequente con una parola minima di 4 caratteri
$parola = $testo.Split(" ") | Where-Object { $_.Length -ge 8 } | Group-Object | Sort-Object -Property Count -Descending | Select-Object -First 1
write-host "Parola più frequente:" $parola.Name 
write-host "Occorrenze:" $parola.Count

$parola = $testo.Split(" ") | ForEach-Object { $_ -replace "[^a-zA-Z0-9]", "" } | Where-Object { $_.Length -ge 8 } | Group-Object | Sort-Object -Property Count -Descending | Select-Object -First 1
write-host "Parola più frequente:" $parola.Name
write-host "Occorrenze:" $parola.Count



