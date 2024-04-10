package com.example.demo.Modellismo.Classi;

public class Ordine {
    public int ordineId;
    public int getOrdineId() {
        return ordineId;
    }
    public void setOrdineId(int ordineId) {
        this.ordineId = ordineId;
    }

    public int articoloId;
    public int getArticoloId() {
        return articoloId;
    }
    public void setArticoloId(int articoloId) {
        this.articoloId = articoloId;
    }

    public int quantita;
    public int getQuantita() {
        return quantita;
    }
    public void setQuantita(int quantita) {
        this.quantita = quantita;
    }

    public boolean scaricoEffettuato;
    public boolean isScaricoEffettuato() {
        return scaricoEffettuato;
    }
    public void setScaricoEffettuato(boolean scaricoEffettuato) {
        this.scaricoEffettuato = scaricoEffettuato;
    }
}
