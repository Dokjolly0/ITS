package com.example.demo.Modellismo.Classi;

public class Articolo {
    public int articoloId;
    public int getArticoloId() {
        return articoloId;
    }
    public void setArticoloId(int articoloId) {
        this.articoloId = articoloId;
    }

    public String Nome;
    public String getNome() {
        return Nome;
    }
    public void setNome(String nome) {
        this.Nome = Nome;
    }

    public String Tipologia;
    public String getTipologia() {
        return Tipologia;
    }
    public void setTipologia(String tipologia) {
        this.Tipologia = tipologia;
    }

    public int Giacenza;
    public int getGiacenza() {
        return Giacenza;
    }
    public void setGiacenza(int giacenza) {
        this.Giacenza = giacenza;
    }

    public int Prezzo;
    public int getPrezzo() {
        return Prezzo;
    }
    public void setPrezzo(int prezzo) {
        this.Prezzo = prezzo;
    }

    public float costoUnitario;
    public float getCostoUnitario() {
        return costoUnitario;
    }
    public void setCostoUnitario(float costoUnitario) {
        this.costoUnitario = costoUnitario;
    }

    //Costruttore
    public Articolo(int articoloId, String Nome, String Tipologia, int Giacenza, int Prezzo) {
        this.articoloId = articoloId;
        this.Nome = Nome;
        this.Tipologia = Tipologia;
        this.Giacenza = Giacenza;
        this.Prezzo = Prezzo;
    }
    //Costruttore vuoto
    public Articolo() {
    }
}
