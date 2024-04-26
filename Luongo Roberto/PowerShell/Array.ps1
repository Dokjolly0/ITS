#Array
$array = @('Padova', 'Venezia', 'Verona', 'Treviso', 'Rovigo', 'Belluno')
write-host $array.Length
write-host "Ti restituisce la lunghezza dell'array"
Write-Host "-----------------------------------------------------------"
write-host $array[0]
Write-Host "Ti restituisce l'elemento in posizione 0 dell'array"
Write-Host "-----------------------------------------------------------"
for($i = 0; $i -lt $array.Length; $i++) {
    write-host $array[$i]
}
Write-Host "Stampa tutti gli elementi dell'array"
Write-Host "-----------------------------------------------------------"
foreach($element in $array) {
    write-host $element
}
Write-Host "Stampa tutti gli elementi dell'array"
Write-Host "-----------------------------------------------------------"
$array += 'Vicenza'
write-host "Aggiunge un elemento all'array"
write-host $array
Write-Host "-----------------------------------------------------------"