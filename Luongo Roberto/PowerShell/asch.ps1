#Oggetti chiave valore
$hash = @{}
$hash["Nome"] = "Andrea"
$hash["Cognome"] = "Schirru"
$hash["Età"] = 30
$hash["Sesso"] = "M"
$hash["Città"] = "Cagliari"
$hash["Provincia"] = "CA"
$hash["Stato"] = "Italia"

#Stampa dell'oggetto
write-host $hash
# output: System.Collections.Hashtable, restituisce l'oggetto hashtable
write-host $hash.GetType()
# output: System.Collections.Hashtable, restituisce il tipo dell'oggetto hashtable
write-host $hash.Count
# output: 7, restituisce il numero di elementi dell'oggetto hashtable
write-host $hash.Keys
# output: Nome, Cognome, Età, Sesso, Città, Provincia, Stato, restituisce le chiavi dell'oggetto hashtable
write-host $hash.Values
# output: Andrea, Schirru, 30, M, Cagliari, CA, Italia, restituisce i valori dell'oggetto hashtable
write-host $hash["Nome"]
# output: Andrea, restituisce il valore associato alla chiave "Nome"
write-host $hasch.Remove("Età")
# output: 30, rimuove l'elemento con chiave "Età" e restituisce il valore
write-host $hash.ContainsKey("Età")
# output: False, verifica se l'oggetto contiene una chiave specifica
write-host $hash.ContainsValue("Andrea")
# output: True, verifica se l'oggetto contiene un valore specifico
write-host $hash.GetEnumerator()
# output: System.Collections.DictionaryEntry, restituisce un enumeratore per l'oggetto hashtable
foreach($entry in $hash.GetEnumerator()) {
    write-host $entry.Key
    write-host $entry.Value
}
