using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OnlineBanking.Data.Models
{
    public partial class BankAppContext : DbContext
    {
        public BankAppContext()
        {
        }

        public BankAppContext(DbContextOptions<BankAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeoPoints> GeoPoints { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Data Source=localhost;Database=BankApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoPoints>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("geo_points_pk")
                    .IsClustered(false);

                entity.ToTable("geo_points");

                entity.HasIndex(e => e.Id)
                    .HasName("geo_points_Id_uindex")
                    .IsUnique();

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transactions");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ClientGender).HasColumnName("client_gender");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientYearOfBirth).HasColumnName("client_year_of_birth");

                entity.Property(e => e.MerchantCategory).HasColumnName("merchant_category");

                entity.Property(e => e.MerchantCategoryId).HasColumnName("merchant_category_id");

                entity.Property(e => e.MerchantUid)
                    .HasColumnName("merchant_uid")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShopTags)
                    .HasColumnName("shop_tags")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShopType)
                    .HasColumnName("shop_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShopUid)
                    .HasColumnName("shop_uid")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("transaction_id");

                entity.Property(e => e.TxDate).HasColumnName("tx_date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
