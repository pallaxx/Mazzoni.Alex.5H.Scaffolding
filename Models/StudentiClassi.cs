using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Mazzoni.Alex._5H.Scaffolding.Models
{
    public partial class StudentiClassi : DbContext
    {
        public StudentiClassi()
        {
        }

        public StudentiClassi(DbContextOptions<StudentiClassi> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<Studente> Studentes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=StudentiClassi.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.Idclasse);

                entity.ToTable("Classe");

                entity.HasIndex(e => e.Idclasse, "IX_Classe_IDClasse")
                    .IsUnique();

                entity.Property(e => e.Idclasse).HasColumnName("IDClasse");

                entity.Property(e => e.As)
                    .IsRequired()
                    .HasColumnName("AS");

                entity.Property(e => e.Sezione).IsRequired();
            });

            modelBuilder.Entity<Studente>(entity =>
            {
                entity.ToTable("Studente");

                entity.HasIndex(e => e.Id, "IX_Studente_ID")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodiceFiscale).IsRequired();

                entity.Property(e => e.Cognome).IsRequired();

                entity.Property(e => e.FkIdclasse).HasColumnName("FK_IDClasse");

                entity.Property(e => e.Nome).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
