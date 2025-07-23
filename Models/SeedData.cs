using Microsoft.EntityFrameworkCore;

namespace heheshop.Models
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // ===== USER =====
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Email = "admin@gmail.com", PasswordHash = "123", Role = "Admin" },
                new User { Id = 2, Username = "duy", Email = "duy@gmail.com", PasswordHash = "123", Role = "Customer" },
                new User { Id = 3, Username = "khanh", Email = "khanh@gmail.com", PasswordHash = "123", Role = "Customer" },
                new User { Id = 4, Username = "ngoc", Email = "ngoc@gmail.com", PasswordHash = "123", Role = "Customer" },
                new User { Id = 5, Username = "lan", Email = "lan@gmail.com", PasswordHash = "123", Role = "Customer" }
            );

            // ===== ADDRESS =====
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, UserId = 2, Street = "123 Lê Lợi", City = "Huế", State = "Thừa Thiên Huế", ZipCode = "530000" },
                new Address { Id = 2, UserId = 3, Street = "456 Phan Bội Châu", City = "Đà Nẵng", State = "Đà Nẵng", ZipCode = "550000" },
                new Address { Id = 3, UserId = 4, Street = "789 Trần Hưng Đạo", City = "Hà Nội", State = "Hà Nội", ZipCode = "100000" },
                new Address { Id = 4, UserId = 5, Street = "12 Nguyễn Huệ", City = "Sài Gòn", State = "TP.HCM", ZipCode = "700000" }
            );

            // ===== BRAND =====
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Nike" },
                new Brand { Id = 2, Name = "Adidas" },
                new Brand { Id = 3, Name = "Puma" },
                new Brand { Id = 4, Name = "Converse" }
            );

            // ===== CATEGORY =====
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Thể thao" },
                new Category { Id = 2, Name = "Thời trang" },
                new Category { Id = 3, Name = "Giày chạy bộ" },
                new Category { Id = 4, Name = "Sneaker" }
            );

            // ===== PRODUCT =====
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Nike Air Max", Description = "Giày thể thao cao cấp", Price = 2500000, Stock = 10, ThumbnailUrl = "/images/nike_airmax.jpg", BrandId = 1, CategoryId = 1 },
                new Product { Id = 2, Name = "Adidas UltraBoost", Description = "Chạy bộ cực êm", Price = 2700000, Stock = 15, ThumbnailUrl = "/images/adidas_ub.jpg", BrandId = 2, CategoryId = 3 },
                new Product { Id = 3, Name = "Puma RS-X", Description = "Sneaker độc đáo", Price = 1900000, Stock = 12, ThumbnailUrl = "/images/puma_rsx.jpg", BrandId = 3, CategoryId = 4 },
                new Product { Id = 4, Name = "Converse Classic", Description = "Thiết kế đơn giản", Price = 1200000, Stock = 20, ThumbnailUrl = "/images/converse.jpg", BrandId = 4, CategoryId = 2 },
                new Product { Id = 5, Name = "Nike Pegasus", Description = "Giày chạy thoáng khí", Price = 2100000, Stock = 8, ThumbnailUrl = "/images/nike_pegasus.jpg", BrandId = 1, CategoryId = 3 }
            );

            // ===== PRODUCT IMAGE =====
            modelBuilder.Entity<ProductImage>().HasData(
                new ProductImage { Id = 1, ProductId = 1, ImageUrl = "/images/nike1.jpg" },
                new ProductImage { Id = 2, ProductId = 1, ImageUrl = "/images/nike2.jpg" },
                new ProductImage { Id = 3, ProductId = 2, ImageUrl = "/images/adidas1.jpg" },
                new ProductImage { Id = 4, ProductId = 3, ImageUrl = "/images/puma1.jpg" },
                new ProductImage { Id = 5, ProductId = 4, ImageUrl = "/images/converse1.jpg" },
                new ProductImage { Id = 6, ProductId = 5, ImageUrl = "/images/nike_pegasus1.jpg" }
            );

            // ===== PRODUCT VARIANT =====
            modelBuilder.Entity<ProductVariant>().HasData(
                new ProductVariant { Id = 1, ProductId = 1, Color = "Trắng", Size = "42" },
                new ProductVariant { Id = 2, ProductId = 1, Color = "Đen", Size = "43" },
                new ProductVariant { Id = 3, ProductId = 2, Color = "Xám", Size = "41" },
                new ProductVariant { Id = 4, ProductId = 3, Color = "Xanh dương", Size = "40" },
                new ProductVariant { Id = 5, ProductId = 4, Color = "Đỏ", Size = "39" },
                new ProductVariant { Id = 6, ProductId = 5, Color = "Xanh lá", Size = "42" }
            );

            // ===== CART ITEM =====
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 1, UserId = 2, ProductVariantId = 1, Quantity = 2 },
                new CartItem { Id = 2, UserId = 3, ProductVariantId = 3, Quantity = 1 },
                new CartItem { Id = 3, UserId = 4, ProductVariantId = 5, Quantity = 1 }
            );

            // ===== ORDER =====
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, UserId = 2, AddressId = 1, OrderDate = DateTime.Now, Status = "Processing" },
                new Order { Id = 2, UserId = 3, AddressId = 2, OrderDate = DateTime.Now.AddDays(-2), Status = "Shipped" },
                new Order { Id = 3, UserId = 4, AddressId = 3, OrderDate = DateTime.Now.AddDays(-5), Status = "Delivered" }
            );

            // ===== ORDER ITEM =====
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductVariantId = 1, Quantity = 2, UnitPrice = 2500000 },
                new OrderItem { Id = 2, OrderId = 2, ProductVariantId = 3, Quantity = 1, UnitPrice = 2700000 },
                new OrderItem { Id = 3, OrderId = 3, ProductVariantId = 5, Quantity = 1, UnitPrice = 1200000 }
            );

            // ===== PAYMENT =====
            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, OrderId = 1 },
                new Payment { Id = 2, OrderId = 2 },
                new Payment { Id = 3, OrderId = 3 }
            );

            // ===== DISCOUNT CODE =====
            modelBuilder.Entity<DiscountCode>().HasData(
                new DiscountCode { Id = 1, Code = "SALE10", ExpiryDate = DateTime.Now.AddMonths(1) },
                new DiscountCode { Id = 2, Code = "FREESHIP", ExpiryDate = DateTime.Now.AddMonths(2) }
            );

            // ===== REVIEW =====
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, UserId = 2, ProductId = 1, Rating = 5, CreatedAt = DateTime.Now },
                new Review { Id = 2, UserId = 3, ProductId = 2, Rating = 4, CreatedAt = DateTime.Now.AddDays(-1) },
                new Review { Id = 3, UserId = 4, ProductId = 4, Rating = 5, CreatedAt = DateTime.Now.AddDays(-2) },
                new Review { Id = 4, UserId = 5, ProductId = 5, Rating = 4, CreatedAt = DateTime.Now.AddDays(-3) }
            );
        }
    }
}
