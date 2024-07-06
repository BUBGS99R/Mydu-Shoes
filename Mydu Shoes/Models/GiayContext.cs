using Microsoft.EntityFrameworkCore;
using Mydu_Shoes.Models;

namespace Mydu_Shoes.Models
{
    public class GiayContext : DbContext
    {
        public GiayContext() { }
        public GiayContext(DbContextOptions<GiayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<products> Product { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Username).HasMaxLength(50);
            });
            modelBuilder.Entity<products>(entity =>
            {
                entity.ToTable("products");
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Img).IsUnicode(false);
                entity.Property(e => e.Tensp).HasMaxLength(255);
                entity.Property(e => e.gia).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Description).HasMaxLength(int.MaxValue);
                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories");
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Name).HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("CartItems");
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.Quantity).IsRequired();
                entity.Property(e => e.Size).IsRequired().HasMaxLength(50);

                entity.HasOne(d => d.Product)
                      .WithMany()
                      .HasForeignKey(d => d.ProductId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoices");
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.FullName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(200).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
                entity.Property(e => e.CreatedDate).IsRequired();
            });

           
        }
    }
}
