package com.brasilburger.repositories;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.List;

import com.brasilburger.database.Database;
import com.brasilburger.entities.Complement;

public class ComplementRepository {

    // ➕ Ajouter un complément
    public void addComplement(Complement complement) {
        String sql = "INSERT INTO complement (nom, prix, image, actif) VALUES (?, ?, ?, ?)";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setString(1, complement.getNom());
            stmt.setDouble(2, complement.getPrix());
            stmt.setString(3, complement.getImage());
            stmt.setBoolean(4, complement.isActif());

            stmt.executeUpdate();
            System.out.println(" Complément ajouté avec succès");

        } catch (Exception e) {
            System.out.println(" Erreur ajout complément : " + e.getMessage());
        }
    }

    //  Lister les compléments actifs
    public List<Complement> findAll() {
        List<Complement> complements = new ArrayList<>();
        String sql = "SELECT * FROM complement WHERE actif = true";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql);
             ResultSet rs = stmt.executeQuery()) {

            while (rs.next()) {
                Complement c = new Complement();
                c.setId(rs.getInt("id"));
                c.setNom(rs.getString("nom"));
                c.setPrix(rs.getDouble("prix"));
                c.setImage(rs.getString("image"));
                c.setActif(rs.getBoolean("actif"));

                complements.add(c);
            }

        } catch (Exception e) {
            System.out.println(" Erreur liste compléments : " + e.getMessage());
        }

        return complements;
    }

    //  Archiver un complément
    public void archiveComplement(int id) {
        String sql = "UPDATE complement SET actif = false WHERE id = ?";

        try (Connection conn = Database.getConnection();
             PreparedStatement stmt = conn.prepareStatement(sql)) {

            stmt.setInt(1, id);
            stmt.executeUpdate();
            System.out.println(" Complément archivé");

        } catch (Exception e) {
            System.out.println(" Erreur archivage complément : " + e.getMessage());
        }
    }
}
