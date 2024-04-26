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

do {
    MostraMenu
    $scelta = Read-Host "Fai una scelta: "
    switch ($scelta) {
        "1" {
            do {
                $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
                if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
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
                    Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
                }
            } until ($percorsoPersonalizzato)            
        } 
    
      "2"
      {
        do {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
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
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
            }
        } until ($percorsoPersonalizzato)        
      } 

      "3" 
      {
        do {
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorsoOrigine = Read-Host "Inserisci il percorso della cartella origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
                $percorsoPersonalizzato = $true
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_copiata'
                $percorsoPersonalizzato = $true
                
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorsoOrigine = Read-Host "Inserisci il percorso del file origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso del file destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu\test.txt'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu\test_copia.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorso = Read-Host "Inserisci il percorso del file"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu\test.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorsoOrigine = Read-Host "Inserisci il percorso della cartella origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_spostata'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorsoOrigine = Read-Host "Inserisci il percorso del file origine"
                $percorsoDestinazione = Read-Host "Inserisci il percorso della cartella destinazione"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorsoOrigine = 'C:\Temp\Cartella_menu\test.txt'
                $percorsoDestinazione = 'C:\Temp\Cartella_menu_spostata\test.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorso = Read-Host "Inserisci il percorso della cartella"
                $nuovoNome = Read-Host "Inserisci il nuovo nome della cartella"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu'
                $nuovoNome = 'Cartella_menu_rinominata'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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
            $sceltaPercorso = Read-Host "Vuoi inserire un percorso personalizzato? (s/n)"
            if ($sceltaPercorso -eq "s" -or $sceltaPercorso -eq 'S') {
                $percorso = Read-Host "Inserisci il percorso del file"
                $nomeFile = Read-Host "Inserisci il nome del file da rinominare"
                $nuovoNome = Read-Host "Inserisci il nuovo nome del file"
            } elseif ($sceltaPercorso -eq "n" -or $sceltaPercorso -eq 'N') {
                $percorso = 'C:\Temp\Cartella_menu\test.txt'
                $nuovoNome = 'test_rinominato.txt'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 's' per sì o 'n' per no."
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

        "11" {
            $customPathChoice = Read-Host "Vuoi specificare un percorso personalizzato per la cartella da comprimere? (y/n)"
            if ($customPathChoice -eq "y" -or $customPathChoice -eq 'Y') {
                $folderPathToCompress = Read-Host "Inserisci il percorso della cartella da comprimere"
            } elseif ($customPathChoice -eq "n" -or $customPathChoice -eq 'N') {
                $folderPathToCompress = 'C:\Temp\FolderToCompress'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $folderPathToCompress)) {
                Write-Host 'La cartella da comprimere non esiste'
            } else {
                Write-Host 'Ora comprimerò la cartella'
                Compress-Archive -Path $folderPathToCompress -DestinationPath 'C:\Temp\CompressedFolder.zip'
                if (Test-Path 'C:\Temp\CompressedFolder.zip') {
                    Write-Host 'Cartella compressa correttamente'
                }
            }
        }

        "12" {
            $customPathChoice = Read-Host "Vuoi specificare un percorso personalizzato per la cartella da scompattare? (y/n)"
            if ($customPathChoice -eq "y" -or $customPathChoice -eq 'Y') {
                $compressedFolderPath = Read-Host "Inserisci il percorso della cartella compressa"
            } elseif ($customPathChoice -eq "n" -or $customPathChoice -eq 'N') {
                $compressedFolderPath = 'C:\Temp\CompressedFolder.zip'
            } else {
                Write-Host "Risposta non valida. Per favore, inserisci 'y' per sì o 'n' per no."
            }

            if (-not (Test-Path $compressedFolderPath)) {
                Write-Host 'La cartella compressa non esiste'
            } else {
                Write-Host 'Ora scompatterò la cartella'
                Expand-Archive -Path $compressedFolderPath -DestinationPath 'C:\Temp\ExtractedFolder'
                if (Test-Path 'C:\Temp\ExtractedFolder') {
                    Write-Host 'Cartella scompattata correttamente'
                }
            }
        }

        "13" {
            Write-Host 'Arrivederci'
            break
        }
    }
    pause
}
until ($scelta -eq 13)
