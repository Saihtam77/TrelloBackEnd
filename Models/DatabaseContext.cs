using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrelloBack.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commentaire> Commentaires { get; set; }

    public virtual DbSet<Liste> Listes { get; set; }

    public virtual DbSet<Projet> Projets { get; set; }

    public virtual DbSet<Tache> Taches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database/Database.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Commentaire>(entity =>
        {
            entity.ToTable("Commentaire");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenu).HasColumnName("contenu");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.TacheId)
                .HasColumnType("INT")
                .HasColumnName("tache_id");

            entity.HasOne(d => d.Tache).WithMany(p => p.Commentaires)
                .HasForeignKey(d => d.TacheId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Liste>(entity =>
        {
            entity.ToTable("Liste");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");
            entity.Property(e => e.ProjetId)
                .HasColumnType("INT")
                .HasColumnName("projet_id");

            entity.HasOne(d => d.Projet).WithMany(p => p.Listes)
                .HasForeignKey(d => d.ProjetId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.ToTable("Projet");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.ToTable("Tache");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("TIMESTAMP")
                .HasColumnName("createdAt");
            entity.Property(e => e.ListeId)
                .HasColumnType("INT")
                .HasColumnName("liste_id");
            entity.Property(e => e.Nom)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("nom");

            entity.HasOne(d => d.Liste).WithMany(p => p.Taches)
                .HasForeignKey(d => d.ListeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
