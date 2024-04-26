$testo = Get-Content -Path "C:\Users\violatto_a\Desktop\ITS\Luongo Roberto\PowerShell\promessi_sposi.txt"
write-host "Totale parole frase:" $testo.Split(" ").Count
#Trova la parola più frequente con una parola minima di 4 caratteri
$parola = $testo.Split(" ") | Where-Object { $_.Length -ge 8 } | Group-Object | Sort-Object -Property Count -Descending | Select-Object -First 1
write-host "Parola più frequente:" $parola.Name 
write-host "Occorrenze:" $parola.Count

$parola = $testo.Split(" ") | ForEach-Object { $_ -replace "[^a-zA-Z0-9]", "" } | Where-Object { $_.Length -ge 8 } | Group-Object | Sort-Object -Property Count -Descending | Select-Object -First 1
write-host "Parola più frequente:" $parola.Name
write-host "Occorrenze:" $parola.Count