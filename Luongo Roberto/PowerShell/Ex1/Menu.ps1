#1 Creare una cartella (input: percorso della cartella padre e il nome della nuova cartella)
#2 Creare un file di testo (input: percorso dove creare il file e nome del file) e inserire dentro al file il testo di una canzone a scelta
#3 Copiare una cartella contenente dei file (input: percorso cartella origine e percorso cartella destinazione)
#4 Copiare un file (input: percorso file origine e percorso file destinazione)
#5 Cancellare una cartella (contente file) (input: percorso della cartella da cancellare)
#6 Cancellare un file (input: percorso del file da cancellare)
#7 Spostare una cartella (input: percorso cartella origine e percorso cartella padre destinazione)
#8 Spostare un file   (input: percorso file origine e percorso cartella padre destinazione)
#9 Rinominare una cartella (input: percorso cartella origine e nuovo nome)
#10 Rinominare un file  (input: percorso file origine e nuovo nome)
#11 Data una cartella contenente dei file-> comprimerla
#12 Data la  cartella compressa creata nel punto precedente: scomprimerla


function MostraMenu {
    Clear-Host
    Write-Host "1. Crea una cartella"
    Write-Host "2. Crea un file di testo"
    Write-Host "3. Copia una cartella"
    Write-Host "4. Copia un file"
    Write-Host "5. Cancella una cartella"
    Write-Host "6. Cancella un file"
    Write-Host "7. Sposta una cartella"
    Write-Host "8. Sposta un file"
    Write-Host "9. Rinomina una cartella"
    Write-Host "10. Rinomina un file"
    Write-Host "11. Comprimi una cartella"
    Write-Host "12. Scompatta una cartella"
    Write-Host "13. Esci"
}


do
 {
    MostraMenu
    $scelta = Read-Host "fai una scelta: "
    switch ($scelta)
    {
        "1" {
            do {
                $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
                if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                    $percorsoPadre = Read-Host "Inserisci il percorso della cartella padre"
                    $nomeCartella = Read-Host "Inserisci il nome della nuova cartella"
                    $percorso = Join-Path -Path $percorsoPadre -ChildPath $nomeCartella
                    $percorsoPersonalizzato = $true
                    
                    # Verifica se il percorso inserito dall'utente è valido
                    if (-not (Test-Path $percorso)) {
                        Write-Host 'Ora creerò una cartella'
                        New-Item -Path $percorso -ItemType Directory
                        if (Test-Path $percorso) {
                            Write-Host 'Cartella creata correttamente'
                        }
                    } else {
                        Write-Host 'La cartella esiste già'
                        $percorsoPersonalizzato = $false
                    }
                } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                    $percorso = 'C:\Temp\Cartella_menu'
                    Write-Host 'Ora creerò una cartella'
                    New-Item -Path $percorso -ItemType Directory
                    if (Test-Path $percorso) {
                        Write-Host 'Cartella creata correttamente'
                    }
                    $percorsoPersonalizzato = $true
                } else {
                    Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
                }
            } until ($percorsoPersonalizzato)            
        } 
    
      "2"
      {
        do {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
                $nomeFile = Read-Host "Inserisci il nome del file da creare"
                $percorsoCompleto = Join-Path -Path $percorso -ChildPath $nomeFile
                $percorsoPersonalizzato = $true
                
                # Verifica se il percorso inserito dall'utente è valido
                if (-not (Test-Path $percorso)) {
                    Write-Host 'La cartella non esiste'
                    $percorsoPersonalizzato = $false
                } else {
                    $testoDaInserire = Read-Host "Inserisci il testo da inserire nel file"
                    $testoDaInserire | Out-File -FilePath $percorsoCompleto
                    if (Test-Path $percorsoCompleto) {
                        Write-Host 'File creato correttamente'
                    }
                }
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
                $nomeFile = 'test.txt'
                $percorsoCompleto = Join-Path -Path $percorso -ChildPath $nomeFile
                $testoDaInserire = "Testo di prova"
                $testoDaInserire | Out-File -FilePath $percorsoCompleto
                if (Test-Path $percorsoCompleto) {
                    Write-Host 'File creato correttamente'
                }
                $percorsoPersonalizzato = $true
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }
        } until ($percorsoPersonalizzato)        
      } 

      "3" 
      {
        do {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorsoOrigine = Read-Host "Inserisci il percorso della cartella origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
                $percorsoPersonalizzato = $true
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_copiata'
                $percorsoPersonalizzato = $true
                
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }
        } until ($percorsoPersonalizzato)

        if (-not (Test-Path $percorsoOrigine)) {
            Write-Host 'La cartella origine non esiste'
        } else {
            Write-Host 'Ora copierò una cartella'
            Copy-Item -Path $percorsoOrigine -Destination $percorsoDestinazione -Recurse
            if (Test-Path $percorsoDestinazione) {
                Write-Host 'Cartella copiata correttamente'
            }
        }
      }

      "4"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorsoOrigine = Read-Host "Inserisci il percorso del file origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso del file destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu\test.txt'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu\test_copia.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorsoOrigine)) {
                Write-Host 'Il file origine non esiste'
            } else {
                Write-Host 'Ora copierò un file'
                Copy-Item -Path $percorsoOrigine -Destination $percorsoDestinazione
                if (Test-Path $percorsoDestinazione) {
                    Write-Host 'File copiato correttamente'
                }
            }
        }
        "5"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'La cartella non esiste'
            } else {
                Write-Host 'Ora cancellerò una cartella'
                Remove-Item -Path $percorso -Recurse
                if (-not (Test-Path $percorso)) {
                    Write-Host 'Cartella cancellata correttamente'
                }
            }
        }

        "6"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso del file"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu\test.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'Il file non esiste'
            } else {
                Write-Host 'Ora cancellerò un file'
                Remove-Item -Path $percorso
                if (-not (Test-Path $percorso)) {
                    Write-Host 'File cancellato correttamente'
                }
            }
        }

        "7"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorsoOrigine = Read-Host "Inserisci il percorso della cartella origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_spostata'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorsoOrigine)) {
                Write-Host 'La cartella origine non esiste'
            } else {
                Write-Host 'Ora sposterò una cartella'
                Move-Item -Path $percorsoOrigine -Destination $percorsoDestinazione
                if (Test-Path $percorsoDestinazione) {
                    Write-Host 'Cartella spostata correttamente'
                }
            }
        }

        "8"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorsoOrigine = Read-Host "Inserisci il percorso del file origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu\test.txt'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_spostata\test.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorsoOrigine)) {
                Write-Host 'Il file origine non esiste'
            } else {
                Write-Host 'Ora sposterò un file'
                Move-Item -Path $percorsoOrigine -Destination $percorsoDestinazione
                if (Test-Path $percorsoDestinazione) {
                    Write-Host 'File spostato correttamente'
                }
            }
        }

        "9"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
                $nuovoNome = Read-Host "Inserisci il nuovo nome della cartella"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
                $nuovoNome = 'Cartella_menu_rinominata'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'La cartella non esiste'
            } else {
                Write-Host 'Ora rinominerò una cartella'
                Rename-Item -Path $percorso -NewName $nuovoNome
                if (Test-Path $nuovoNome) {
                    Write-Host 'Cartella rinominata correttamente'
                }
            }
        }

        "10"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso del file"
                $nomeFile = Read-Host "Inserisci il nome del file da rinominare"
                $nuovoNome = Read-Host "Inserisci il nuovo nome del file"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu\test.txt'
                $nuovoNome = 'test_rinominato.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'Il file non esiste'
            } else {
                Write-Host 'Ora rinominerò un file'
                Rename-Item -Path $percorso -NewName $nuovoNome
                if (Test-Path $nuovoNome) {
                    Write-Host 'File rinominato correttamente'
                }
            }
        }

        "11"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'La cartella non esiste'
            } else {
                Write-Host 'Ora comprimerò una cartella'
                Compress-Archive -Path $percorso -DestinationPath 'C:\Temp\Cartella_menu.zip'
                if (Test-Path 'C:\Temp\Cartella_menu.zip') {
                    Write-Host 'Cartella compressa correttamente'
                }
            }
        }

        "12"
        {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (y/n)"
            if ($sceltaPercorso -eq "y" -or $sceltaPercorso -eq 'Y') {
                $percorso = Read-Host "Inserisci il percorso della cartella compressa"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu.zip'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $percorso)) {
                Write-Host 'La cartella compressa non esiste'
            } else {
                Write-Host 'Ora scompatterò una cartella'
                Expand-Archive -Path $percorso -DestinationPath 'C:\Temp\Cartella_menu_scompattata'
                if (Test-Path 'C:\Temp\Cartella_menu_scompattata') {
                    Write-Host 'Cartella scompattata correttamente'
                }
            }
        }

        "13"
        {
            write-host 'Arrivederci'
            break
        }
    }
    pause
 }
 until ($scelta -eq 13)