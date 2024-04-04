using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using testtt.Repository.Models;

namespace testtt.Repository
{
    public partial class SistemaTesteDbContext : DbContext
    {
        public SistemaTesteDbContext()
        {
        }

        public SistemaTesteDbContext(DbContextOptions<SistemaTesteDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Motoristum> Motorista { get; set; } = null!;
        public virtual DbSet<OrdemServiço> OrdemServiços { get; set; } = null!;
        public virtual DbSet<Posto> Postos { get; set; } = null!;
        public virtual DbSet<TipoCombustivel> TipoCombustivels { get; set; } = null!;
        public virtual DbSet<Veiculo> Veiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PC03LAB2056\\SENAI;Initial Catalog=SistemaTeste;User ID=sa;Password=senai.123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motoristum>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PK__Motorist__C1F89730E4CC5E9A");
            });

            modelBuilder.Entity<OrdemServiço>(entity =>
            {
                entity.HasKey(e => e.OrdemId)
                    .HasName("PK__OrdemSer__C356421D23DB3A24");

                entity.HasOne(d => d.MotoristaCpfNavigation)
                    .WithMany(p => p.OrdemServiços)
                    .HasForeignKey(d => d.MotoristaCpf)
                    .HasConstraintName("FK__OrdemServ__Motor__3E52440B");
            });

            modelBuilder.Entity<TipoCombustivel>(entity =>
            {
                entity.HasKey(e => e.Tipo)
                    .HasName("PK__TipoComb__E7F956488A76C421");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.PlacaVeiculo)
                    .HasName("PK__Veiculo__C12B6E396D799953");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
