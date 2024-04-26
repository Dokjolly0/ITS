#New-Item -Path 'C:\Temp\Test_folder1' -ItemType Directory
# New-Item -Path 'C:\Temp\Test_folder/test.txt' -ItemType File

# Scrivi un messaggio a schermo
# write-host "Hello World"

# # Calcoli
# $var1 = 10
# $var2 = 20
# $var3 = $var1 + $var2
# write-host $var3

# Operatori
# + somma
# - sottrazione
# * moltiplicazione
# / divisione
# % modulo
# -eq uguale
# -ne diverso
# -gt maggiore
# -ge maggiore o uguale
# -lt minore
# -le minore o uguale
# -igt maggiore (per stringhe)
# -ige maggiore o uguale (per stringhe)
# -ilt minore (per stringhe)
# -ile minore o uguale (per stringhe)
# -and e
# -or o
# -not negazione

# If
# if ($var1 -eq 10) {
#     write-host "Var1 è uguale a 10"
# }

#◘ Fai un programma che dati 2 numeri in input calcoli qualsiasi operazione tra +, -, *, / e %.
# $var1 = Read-Host "Inserisci il primo numero"
# $var2 = Read-Host "Inserisci il secondo numero"

# write-host "Il risultato sommato è: " ([float]$var1 + [float]$var2)
# write-host "Il risultato sottratto è: " ([float]$var1 - [float]$var2)
# write-host "Il risultato moltiplicato è: " ([float]$var1 * [float]$var2)

# if ([float]$var2 -ne 0) {
#     write-host "Il risultato diviso è: " ([float]$var1 / [float]$var2)
# }

# else{
#     write-host "Non puoi dividere per 0"
# }

#For da 1 a 10 normale e inverso
for ($i = 1; $i -le 10; $i++) {
    write-host $i
}

for ($i = 10; $i -ge 1; $i--) {
    write-host $i
}