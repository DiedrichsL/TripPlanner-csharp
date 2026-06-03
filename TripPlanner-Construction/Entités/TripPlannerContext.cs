using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TripPlanner_Construction.Entités;

public partial class TripPlannerContext : DbContext
{
    public TripPlannerContext()
    {
    }

    public TripPlannerContext(DbContextOptions<TripPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Participation> Participations { get; set; }

    public virtual DbSet<Proposition> Propositions { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    public virtual DbSet<Vote> Votes { get; set; }

    public virtual DbSet<Voyage> Voyages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TripPlanner;User Id=sa;Password=Id€c2o25++;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Participation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC07D287FF11");

            entity.ToTable("Participation");

            entity.HasIndex(e => new { e.UtilisateurId, e.VoyageId }, "UQ_Participation_Utilisateur_Voyage").IsUnique();

            entity.HasIndex(e => e.Id, "UQ__Particip__3214EC06176D7BF7").IsUnique();

            entity.Property(e => e.EstActif).HasDefaultValue(true);

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Participations)
                .HasForeignKey(d => d.UtilisateurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Participation_fk1");

            entity.HasOne(d => d.Voyage).WithMany(p => p.Participations)
                .HasForeignKey(d => d.VoyageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Participation_fk2");
        });

        modelBuilder.Entity<Proposition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proposit__3214EC07DF130BF8");

            entity.ToTable("Proposition");

            entity.HasIndex(e => new { e.VoyageId, e.TypeProposition }, "UQ_Proposition_Voyage_Type_Retenue")
                .IsUnique()
                .HasFilter("([EstRetenue]=(1))");

            entity.HasIndex(e => e.Id, "UQ__Proposit__3214EC067AA7DD8A").IsUnique();

            entity.Property(e => e.EstActif).HasDefaultValue(true);
            entity.Property(e => e.PrixEstime).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TypeProposition).HasMaxLength(50);

            entity.HasOne(d => d.Utilisateur).WithMany(p => p.Propositions)
                .HasForeignKey(d => d.UtilisateurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Proposition_fk2");

            entity.HasOne(d => d.Voyage).WithMany(p => p.Propositions)
                .HasForeignKey(d => d.VoyageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Proposition_fk1");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Utilisat__3214EC07916D786A");

            entity.ToTable("Utilisateur");

            entity.HasIndex(e => e.Id, "UQ__Utilisat__3214EC062E9F1B0E").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Utilisat__A9D105344757428C").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EstActif).HasDefaultValue(true);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("Utilisateur");
        });

        modelBuilder.Entity<Vote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vote__3214EC07868EB6A6");

            entity.ToTable("Vote");

            entity.HasIndex(e => new { e.UtilsateurId, e.PropositionId }, "UQ_Vote_Utilisateur_Proposition").IsUnique();

            entity.HasIndex(e => e.Id, "UQ__Vote__3214EC06654C6937").IsUnique();

            entity.Property(e => e.EstActif).HasDefaultValue(true);

            entity.HasOne(d => d.Proposition).WithMany(p => p.Votes)
                .HasForeignKey(d => d.PropositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vote_fk2");

            entity.HasOne(d => d.Utilsateur).WithMany(p => p.Votes)
                .HasForeignKey(d => d.UtilsateurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vote_fk1");
        });

        modelBuilder.Entity<Voyage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voyage__3214EC07A7F1D054");

            entity.ToTable("Voyage");

            entity.HasIndex(e => e.Id, "UQ__Voyage__3214EC06E324FF5D").IsUnique();

            entity.Property(e => e.EstActif).HasDefaultValue(true);

            entity.HasOne(d => d.Organisateur).WithMany(p => p.Voyages)
                .HasForeignKey(d => d.Organisateurid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Voyage_fk1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
