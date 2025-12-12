package com.brasilburger;

import com.brasilburger.entities.Burger;
import com.brasilburger.repositories.BurgerRepository;

public class App {
    public static void main(String[] args) {

        BurgerRepository burgerRepo = new BurgerRepository();

        // ➕ Ajouter un burger
        Burger burger = new Burger("Brasil Burger", 3500, "burger.jpg", true);
        burgerRepo.addBurger(burger);

        
        System.out.println(" Liste des burgers :");
        burgerRepo.findAll().forEach(b ->
                System.out.println(b.getId() + " - " + b.getNom() + " - " + b.getPrix())
        );
    }
}