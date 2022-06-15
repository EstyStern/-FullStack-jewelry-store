using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class Jewelry_dbContext : DbContext
    {
        public Jewelry_dbContext()
        {
        }

        public Jewelry_dbContext(DbContextOptions<Jewelry_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuyDetailsTbl> BuyDetailsTbls { get; set; }
        public virtual DbSet<BuyTbl> BuyTbls { get; set; }
        public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }
        public virtual DbSet<CustomersTbl> CustomersTbls { get; set; }
        public virtual DbSet<JewelryTbl> JewelryTbls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-42NCSL4\\SQLEXPRESS;Database=Jewelry_db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<BuyDetailsTbl>(entity =>
            {
                entity.HasKey(e => e.IdBuyDetails);

                entity.ToTable("BuyDetails_tbl");

                entity.Property(e => e.IdBuyDetails).HasColumnName("idBuyDetails");

                entity.Property(e => e.IdBuy).HasColumnName("idBuy");

                entity.Property(e => e.JewelryId).HasColumnName("jewelryId");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.IdBuyNavigation)
                    .WithMany(p => p.BuyDetailsTbls)
                    .HasForeignKey(d => d.IdBuy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuyDetails_tbl_Buy_tbl");

                entity.HasOne(d => d.Jewelry)
                    .WithMany(p => p.BuyDetailsTbls)
                    .HasForeignKey(d => d.JewelryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuyDetails_tbl_Jewelry_tbl");
            });

            modelBuilder.Entity<BuyTbl>(entity =>
            {
                entity.HasKey(e => e.IdBuy);

                entity.ToTable("Buy_tbl");

                entity.Property(e => e.AmountToPay).HasColumnName("amountToPay");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.DateBuy).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BuyTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buy_tbl_Customers_tbl");
            });

            modelBuilder.Entity<CategoryTbl>(entity =>
            {
                entity.HasKey(e => e.CodeCategory);

                entity.ToTable("Category_tbl");

                entity.Property(e => e.CodeCategory).HasColumnName("codeCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(30)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<CustomersTbl>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("Customers_tbl");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.CreditNumber)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("creditNumber");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("customerName");

                entity.Property(e => e.CustomerPassword).HasColumnName("customerPassword");
            });

            modelBuilder.Entity<JewelryTbl>(entity =>
            {
                entity.HasKey(e => e.JewelryId);

                entity.ToTable("Jewelry_tbl");

                entity.Property(e => e.JewelryId).HasColumnName("jewelryId");

                entity.Property(e => e.CodeCategory).HasColumnName("codeCategory");

                entity.Property(e => e.JewelryImage)
                    .HasMaxLength(50)
                    .HasColumnName("jewelryImage");

                entity.Property(e => e.JewelryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("jewelryName");

                entity.Property(e => e.JewelryPrice).HasColumnName("jewelryPrice");

                entity.Property(e => e.Material)
                    .HasMaxLength(50)
                    .HasColumnName("material");

                entity.Property(e => e.UnitsInStock).HasColumnName("unitsInStock");

                entity.HasOne(d => d.CodeCategoryNavigation)
                    .WithMany(p => p.JewelryTbls)
                    .HasForeignKey(d => d.CodeCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jewelry_tbl_Category_tbl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
