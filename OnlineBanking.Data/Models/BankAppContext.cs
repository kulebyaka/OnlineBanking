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

        public virtual DbSet<BankTransaction> BankTransaction { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:kulebyaka-server-name.database.windows.net,1433;Database=BankApp;User ID=kulebyaka;Password=Dc&W5bX9%f9kDE");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("transactions_pk")
                    .IsClustered(false);

                entity.ToTable("bank_transaction");

                entity.HasIndex(e => e.Id)
                    .HasName("transactions_transaction_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.ClientGender).HasColumnName("client_gender");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientYearOfBirth).HasColumnName("client_year_of_birth");

                entity.Property(e => e.MerchantCategory).HasColumnName("merchant_category");

                entity.Property(e => e.MerchantUid)
                    .HasColumnName("merchant_uid")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShopTags)
                    .HasColumnName("shop_tags")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ShopType)
                    .IsRequired()
                    .HasColumnName("shop_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ShopUid)
                    .IsRequired()
                    .HasColumnName("shop_uid")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TxDate).HasColumnName("tx_date");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("shops_pk")
                    .IsClustered(false);

                entity.ToTable("shop");

                entity.HasIndex(e => e.Id)
                    .HasName("shops_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.PragueId).HasColumnName("prague_id");

                entity.Property(e => e.ShopUid)
                    .IsRequired()
                    .HasColumnName("shop_uid")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
