package com.brasilburger;

import com.brasilburger.entities.Burger;
import com.brasilburger.entities.Menu;
import com.brasilburger.entities.Complement;
import com.brasilburger.repositories.BurgerRepository;
import com.brasilburger.repositories.MenuRepository;
import com.brasilburger.repositories.ComplementRepository;

import java.util.Scanner;

public class App {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        BurgerRepository burgerRepo = new BurgerRepository();
        MenuRepository menuRepo = new MenuRepository();
        ComplementRepository complementRepo = new ComplementRepository();

        int choix;

        do {
            System.out.println("\n===== BRASIL BURGER - JAVA CONSOLE =====");
            System.out.println("1. Ajouter un Burger");
            System.out.println("2. Ajouter un Menu");
            System.out.println("3. Ajouter un Complément");
            System.out.println("4. Lister les Burgers");
            System.out.println("5. Lister les Menus");
            System.out.println("6. Lister les Compléments");
            System.out.println("0. Quitter");
            System.out.print("Votre choix : ");

            choix = scanner.nextInt();
            scanner.nextLine();

            switch (choix) {

                case 1 -> {
                    System.out.print("Nom du burger : ");
                    String nom = scanner.nextLine();
                    System.out.print("Prix : ");
                    double prix = scanner.nextDouble();
                    scanner.nextLine();

                    burgerRepo.addBurger(new Burger(nom, prix, "burger.jpg", true));
                }

                case 2 -> {
                    System.out.print("Nom du menu : ");
                    String nom = scanner.nextLine();

                    menuRepo.addMenu(new Menu(nom, "menu.jpg", true));
                }

                case 3 -> {
                    System.out.print("Nom du complément : ");
                    String nom = scanner.nextLine();
                    System.out.print("Prix : ");
                    double prix = scanner.nextDouble();
                    scanner.nextLine();

                    complementRepo.addComplement(new Complement(nom, prix, "complement.jpg", true));
                }

                case 4 -> burgerRepo.findAll()
                        .forEach(b -> System.out.println(b.getId() + " - " + b.getNom() + " - " + b.getPrix()));

                case 5 -> menuRepo.findAll()
                        .forEach(m -> System.out.println(m.getId() + " - " + m.getNom()));

                case 6 -> complementRepo.findAll()
                        .forEach(c -> System.out.println(c.getId() + " - " + c.getNom() + " - " + c.getPrix()));

                case 0 -> System.out.println(" Au revoir");

                default -> System.out.println(" Choix invalide");
            }

        } while (choix != 0);
    }
}