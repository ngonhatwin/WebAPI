﻿using Microsoft.EntityFrameworkCore;

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
        public DbSet<Account> Accounts { get; set;}

        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //định nghĩa mô hình order
            modelBuilder.Entity<Order>(e =>
            {
                //đặt tên bảng
                e.ToTable("Order");
                //xác định khóa chính là trường ID
                e.HasKey(or => or.ID);
                //lấy thời gian hiện tại theo múi giờ UTC 
                e.Property(or => or.OrderDate).HasDefaultValueSql("getutcdate()");
                //yêu cầu trường name bắt buộc không null và có chiều dài tối đa 100 kí tự
                e.Property(or => or.Name).IsRequired().HasMaxLength(100);
            });

            //một chi tiết đơn hàng chỉ liên kết 1 đơn hàng
            //một đơn hàng sẽ có nhiều chi tiết đơn hàng( sản phẩm chứa trong chi tiết đơn hàng)
            //--
            //một chi tiết đơn hàng chỉ có 1 sản phẩm
            //một sản phẩm liên kết với nhiều chi tiết đơn hàng
            modelBuilder.Entity<OrderDetails>(e =>
            {
                //đặt tên bảng
                e.ToTable("OrderDetails");
                //xác định khóa chính là 2 trường
                e.HasKey(e => new { e.IDDetails, e.IDProduct });
                //// Thiết lập mối quan hệ N:1 với mô hình Order thông qua trường IDDetails
                e.HasOne(e => e.MyOrder)
                .WithMany(e => e.order_Detail)
                .HasForeignKey(e => e.IDDetails)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");
                // Thiết lập mối quan hệ N:1 với mô hình Product thông qua trường IDProduct
                e.HasOne(e => e.MyProduct)
                .WithMany(e => e.ListOrderDetail)
                .HasForeignKey(e => e.IDProduct)
                .HasConstraintName("FK_DonHangChiTiet_SanPham");
            });
        }
    }
}
