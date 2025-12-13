package com.brasilburger.repositories;

import com.brasilburger.database.Database;
import com.brasilburger.entities.Menu;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

public class MenuRepository {

    //  Ajouter un menu
    public void addMenu(Menu menu) {
        String sql = "INSERT INTO menu (nom, image, actif) VALUES (?, ?, ?)";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, menu.getNom());
            stmt.setString(2, menu.getImage());
            stmt.setBoolean(3, menu.isActif());

            stmt.executeUpdate();
            System.out.println(" Menu ajouté avec succès");

        } catch (Exception e) {
            System.out.println(" Erreur ajout menu : " + e.getMessage());
        }
    }

    //  Lister les menus actifs
    public List<Menu> findAll() {
        List<Menu> menus = new ArrayList<>();
        String sql = "SELECT * FROM menu WHERE actif = true";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                Menu menu = new Menu();
                menu.setId(rs.getInt("id"));
                menu.setNom(rs.getString("nom"));
                menu.setImage(rs.getString("image"));
                menu.setActif(rs.getBoolean("actif"));

                menus.add(menu);
            }

        } catch (Exception e) {
            System.out.println(" Erreur liste menus : " + e.getMessage());
        }

        return menus;
    }

    //  Archiver un menu
    public void archiveMenu(int id) {
        String sql = "UPDATE menu SET actif = false WHERE id = ?";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            stmt.executeUpdate();
            System.out.println(" Menu archivé");

        } catch (Exception e) {
            System.out.println(" Erreur archivage menu : " + e.getMessage());
        }
    }
}
