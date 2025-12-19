using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace aspnet_client.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burger> Burgers { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Commande> Commandes { get; set; }

    public virtual DbSet<CommandeBurger> CommandeBurgers { get; set; }

    public virtual DbSet<CommandeMenu> CommandeMenus { get; set; }

    public virtual DbSet<Complement> Complements { get; set; }

    public virtual DbSet<Livreur> Livreurs { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuBurger> MenuBurgers { get; set; }

    public virtual DbSet<MenuComplement> MenuComplements { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Quartier> Quartiers { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-restless-math-ad8w6jge-pooler.c-2.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_FI6ptUrJ9yxQ;Ssl Mode=Require;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("burger_pkey");

            entity.ToTable("burger");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actif)
                .HasDefaultValue(true)
                .HasColumnName("actif");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(10, 2)
                .HasColumnName("prix");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.Telephone, "client_telephone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .HasColumnName("telephone");
        });

        modelBuilder.Entity<Commande>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commande_pkey");

            entity.ToTable("commande");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.DateCommande)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_commande");
            entity.Property(e => e.Etat)
                .HasMaxLength(50)
                .HasDefaultValueSql("'en cours'::character varying")
                .HasColumnName("etat");
            entity.Property(e => e.MontantTotal)
                .HasPrecision(10, 2)
                .HasColumnName("montant_total");
            entity.Property(e => e.TypeCommande)
                .HasMaxLength(50)
                .HasColumnName("type_commande");
            entity.Property(e => e.ZoneId).HasColumnName("zone_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("commande_client_id_fkey");

            entity.HasOne(d => d.Zone).WithMany(p => p.Commandes)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("commande_zone_id_fkey");
        });

        modelBuilder.Entity<CommandeBurger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commande_burger_pkey");

            entity.ToTable("commande_burger");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BurgerId).HasColumnName("burger_id");
            entity.Property(e => e.CommandeId).HasColumnName("commande_id");
            entity.Property(e => e.Quantite)
                .HasDefaultValue(1)
                .HasColumnName("quantite");

            entity.HasOne(d => d.Burger).WithMany(p => p.CommandeBurgers)
                .HasForeignKey(d => d.BurgerId)
                .HasConstraintName("commande_burger_burger_id_fkey");

            entity.HasOne(d => d.Commande).WithMany(p => p.CommandeBurgers)
                .HasForeignKey(d => d.CommandeId)
                .HasConstraintName("commande_burger_commande_id_fkey");
        });

        modelBuilder.Entity<CommandeMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commande_menu_pkey");

            entity.ToTable("commande_menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommandeId).HasColumnName("commande_id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Quantite)
                .HasDefaultValue(1)
                .HasColumnName("quantite");

            entity.HasOne(d => d.Commande).WithMany(p => p.CommandeMenus)
                .HasForeignKey(d => d.CommandeId)
                .HasConstraintName("commande_menu_commande_id_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.CommandeMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("commande_menu_menu_id_fkey");
        });

        modelBuilder.Entity<Complement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("complement_pkey");

            entity.ToTable("complement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actif)
                .HasDefaultValue(true)
                .HasColumnName("actif");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(10, 2)
                .HasColumnName("prix");
        });

        modelBuilder.Entity<Livreur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("livreur_pkey");

            entity.ToTable("livreur");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(100)
                .HasColumnName("prenom");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Actif)
                .HasDefaultValue(true)
                .HasColumnName("actif");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
        });

        modelBuilder.Entity<MenuBurger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_burger_pkey");

            entity.ToTable("menu_burger");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BurgerId).HasColumnName("burger_id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");

            entity.HasOne(d => d.Burger).WithMany(p => p.MenuBurgers)
                .HasForeignKey(d => d.BurgerId)
                .HasConstraintName("menu_burger_burger_id_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuBurgers)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("menu_burger_menu_id_fkey");
        });

        modelBuilder.Entity<MenuComplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_complement_pkey");

            entity.ToTable("menu_complement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComplementId).HasColumnName("complement_id");
            entity.Property(e => e.MenuId).HasColumnName("menu_id");

            entity.HasOne(d => d.Complement).WithMany(p => p.MenuComplements)
                .HasForeignKey(d => d.ComplementId)
                .HasConstraintName("menu_complement_complement_id_fkey");

            entity.HasOne(d => d.Menu).WithMany(p => p.MenuComplements)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("menu_complement_menu_id_fkey");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("paiement_pkey");

            entity.ToTable("paiement");

            entity.HasIndex(e => e.CommandeId, "paiement_commande_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CommandeId).HasColumnName("commande_id");
            entity.Property(e => e.DatePaiement)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_paiement");
            entity.Property(e => e.Mode)
                .HasMaxLength(50)
                .HasColumnName("mode");
            entity.Property(e => e.Montant)
                .HasPrecision(10, 2)
                .HasColumnName("montant");

            entity.HasOne(d => d.Commande).WithOne(p => p.Paiement)
                .HasForeignKey<Paiement>(d => d.CommandeId)
                .HasConstraintName("paiement_commande_id_fkey");
        });

        modelBuilder.Entity<Quartier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quartier_pkey");

            entity.ToTable("quartier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.ZoneId).HasColumnName("zone_id");

            entity.HasOne(d => d.Zone).WithMany(p => p.Quartiers)
                .HasForeignKey(d => d.ZoneId)
                .HasConstraintName("quartier_zone_id_fkey");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("zone_pkey");

            entity.ToTable("zone");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nom)
                .HasMaxLength(100)
                .HasColumnName("nom");
            entity.Property(e => e.Prix)
                .HasPrecision(10, 2)
                .HasColumnName("prix");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
