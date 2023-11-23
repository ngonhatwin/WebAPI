using Microsoft.EntityFrameworkCore;

namespace MyWeb.Data
{
    public class DbContextProduct : DbContext
    {
        public DbContextProduct(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set;}
        #endregion
        public DbSet<Type> Types { get; set;}
        public DbSet<Order> Orders { get; set;}
        public DbSet<OrderDetails> OrderDetails { get; set;}
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(or => or.ID);
                //trả về chính xác múi giờ từng khu vực
                e.Property(or => or.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(or => or.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetails>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(e => new { e.IDDetails, e.IDProduct });

                e.HasOne(e => e.MyOrder)
                .WithMany(e => e.ListOrderDetail)
                .HasForeignKey(e => e.IDDetails)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");

                e.HasOne(e => e.MyProduct)
                .WithMany(e => e.ListOrderDetail)
                .HasForeignKey(e => e.IDProduct)
                .HasConstraintName("FK_DonHangChiTiet_SanPham");
            });
        }
    }
}
