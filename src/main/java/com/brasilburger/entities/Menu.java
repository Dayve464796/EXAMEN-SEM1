package com.brasilburger.entities;

public class Menu {

    private int id;
    private String nom;
    private String image;
    private boolean actif;

    public Menu() {
    }

    public Menu(String nom, String image, boolean actif) {
        this.nom = nom;
        this.image = image;
        this.actif = actif;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }

    public boolean isActif() {
        return actif;
    }

    public void setActif(boolean actif) {
        this.actif = actif;
    }
}
