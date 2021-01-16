using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NandaYudhaP_004_UASPAW.Models
{
    public partial class UasParkirContext : DbContext
    {
        public UasParkirContext()
        {
        }

        public UasParkirContext(DbContextOptions<UasParkirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JenisKendaraan> JenisKendaraan { get; set; }
        public virtual DbSet<KendaraanKeluar> KendaraanKeluar { get; set; }
        public virtual DbSet<KendaraanMasukk> KendaraanMasukk { get; set; }
        public virtual DbSet<Persetujuan> Persetujuan { get; set; }
        public virtual DbSet<RekapKeuntungan> RekapKeuntungan { get; set; }
        public virtual DbSet<TarifParkir> TarifParkir { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdKendaraan);

                entity.ToTable("Jenis_Kendaraan");

                entity.Property(e => e.IdKendaraan).HasColumnName("Id_Kendaraan");

                entity.Property(e => e.JenisKendaraan1)
                    .HasColumnName("Jenis_Kendaraan")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KendaraanKeluar>(entity =>
            {
                entity.HasKey(e => e.IdParkir);

                entity.ToTable("Kendaraan_Keluar");

                entity.Property(e => e.IdParkir)
                    .HasColumnName("Id_Parkir")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("No_Polisi")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tarif)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParkirNavigation)
                    .WithOne(p => p.KendaraanKeluar)
                    .HasForeignKey<KendaraanKeluar>(d => d.IdParkir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kendaraan_Keluar_Persetujuan");
            });

            modelBuilder.Entity<KendaraanMasukk>(entity =>
            {
                entity.HasKey(e => e.IdParkir);

                entity.ToTable("Kendaraan_Masukk");

                entity.Property(e => e.IdParkir)
                    .HasColumnName("Id_Parkir")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisKendaraan)
                    .IsRequired()
                    .HasColumnName("Jenis_Kendaraan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoPolisi)
                    .HasColumnName("No_Polisi")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persetujuan>(entity =>
            {
                entity.HasKey(e => e.IdParkir);

                entity.Property(e => e.IdParkir)
                    .HasColumnName("Id_Parkir")
                    .ValueGeneratedNever();

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParkirNavigation)
                    .WithOne(p => p.Persetujuan)
                    .HasForeignKey<Persetujuan>(d => d.IdParkir)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persetujuan_Kendaraan_Masukk");
            });

            modelBuilder.Entity<RekapKeuntungan>(entity =>
            {
                entity.HasKey(e => e.IdRekap);

                entity.ToTable("Rekap_Keuntungan");

                entity.Property(e => e.IdRekap).HasColumnName("Id_Rekap");

                entity.Property(e => e.Bulan)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPemasukan).HasColumnName("Total_Pemasukan");
            });

            modelBuilder.Entity<TarifParkir>(entity =>
            {
                entity.HasKey(e => e.IdTarif);

                entity.ToTable("Tarif_Parkir");

                entity.Property(e => e.IdTarif).HasColumnName("Id_Tarif");

                entity.Property(e => e.JenisKendaraan)
                    .HasColumnName("Jenis_Kendaraan")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
