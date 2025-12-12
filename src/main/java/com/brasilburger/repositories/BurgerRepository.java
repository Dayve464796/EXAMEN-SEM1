package com.brasilburger.repositories;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import com.brasilburger.database.Database;
import com.brasilburger.entities.Burger;

public class BurgerRepository {

    // ➕ Ajouter un burger
    public void addBurger(Burger burger) {
        String sql = "INSERT INTO burger (nom, prix, image, actif) VALUES (?, ?, ?, ?)";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, burger.getNom());
            stmt.setDouble(2, burger.getPrix());
            stmt.setString(3, burger.getImage());
            stmt.setBoolean(4, burger.isActif());

            stmt.executeUpdate();
            System.out.println(" Burger ajouté avec succès");

        } catch (Exception e) {
            System.out.println(" Erreur ajout burger : " + e.getMessage());
        }
    }

    // 📄 Lister tous les burgers actifs
    public List<Burger> findAll() {
        List<Burger> burgers = new ArrayList<>();
        String sql = "SELECT * FROM burger WHERE actif = true";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                Burger burger = new Burger();
                burger.setId(rs.getInt("id"));
                burger.setNom(rs.getString("nom"));
                burger.setPrix(rs.getDouble("prix"));
                burger.setImage(rs.getString("image"));
                burger.setActif(rs.getBoolean("actif"));

                burgers.add(burger);
            }

        } catch (Exception e) {
            System.out.println(" Erreur liste burgers : " + e.getMessage());
        }

        return burgers;
    }

    // 🗄️ Archiver un burger
    public void archiveBurger(int id) {
        String sql = "UPDATE burger SET actif = false WHERE id = ?";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            stmt.executeUpdate();
            System.out.println(" Burger archivé");

        } catch (Exception e) {
            System.out.println(" Erreur archivage : " + e.getMessage());
        }
    }
}
