package com.example.demo.articolo;

public class articolo {

    //Id dell'articolo
    private Integer id;
    public Integer getId() {
        return id;
    }
    public void setId(Integer id) {
        this.id = id;
    }

    //Nome dell'articolo
    public String nome;
    public String getNome() {
        return nome;
    }
    public void setNome(String nome) {
        this.nome = nome;
    }

    //Descrizione dell'articolo
    public String descrizione;
    public String getDescrizione() {
        return descrizione;
    }
    public void setDescrizione(String descrizione) {
        this.descrizione = descrizione;
    }

    //Prezzo dell'articolo
    public Double prezzo;
    public Double getPrezzo() {
        return prezzo;
    }
    public void setPrezzo(Double prezzo) {
        this.prezzo = prezzo;
    }

    //Giacenza dell'articolo
    public Integer giacenza;
    public Integer getGiacenza() {
        return giacenza;
    }
    public void setGiacenza(Integer giacenza) {
        this.giacenza = giacenza;
    }

    //Iva dell'articolo
    public Integer iva;
    public Integer getIva() {
        return iva;
    }
    public void setIva(Integer iva) {
        this.iva = iva;
    }

    //Costruttore dell'articolo
    public articolo(Integer id, String nome, String descrizione, Double prezzo, Integer giacenza, Integer iva) {
        this.id = id;
        this.nome = nome;
        this.descrizione = descrizione;
        this.prezzo = prezzo;
        this.giacenza = giacenza;
        this.iva = iva;
    }

    //Costruttore vuoto dell'articolo
    public articolo() {
    }
}
