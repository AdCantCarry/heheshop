﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using heheshop.Data;

#nullable disable

namespace heheshop.Migrations
{
    [DbContext(typeof(HeheDbContext))]
    [Migration("20250724175017_updatedb")]
    partial class updatedb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("heheshop.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Huế",
                            State = "Thừa Thiên Huế",
                            Street = "123 Lê Lợi",
                            UserId = 2,
                            ZipCode = "530000"
                        },
                        new
                        {
                            Id = 2,
                            City = "Đà Nẵng",
                            State = "Đà Nẵng",
                            Street = "456 Phan Bội Châu",
                            UserId = 3,
                            ZipCode = "550000"
                        },
                        new
                        {
                            Id = 3,
                            City = "Hà Nội",
                            State = "Hà Nội",
                            Street = "789 Trần Hưng Đạo",
                            UserId = 4,
                            ZipCode = "100000"
                        },
                        new
                        {
                            Id = 4,
                            City = "Sài Gòn",
                            State = "TP.HCM",
                            Street = "12 Nguyễn Huệ",
                            UserId = 5,
                            ZipCode = "700000"
                        });
                });

            modelBuilder.Entity("heheshop.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Puma"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Converse"
                        });
                });

            modelBuilder.Entity("heheshop.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductVariantId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductVariantId");

                    b.HasIndex("UserId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductVariantId = 1,
                            Quantity = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            ProductVariantId = 3,
                            Quantity = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            ProductVariantId = 5,
                            Quantity = 1,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("heheshop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Thể thao"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Thời trang"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Giày chạy bộ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sneaker"
                        });
                });

            modelBuilder.Entity("heheshop.Models.DiscountCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("DiscountCodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SALE10",
                            DiscountAmount = 0m,
                            ExpiryDate = new DateTime(2025, 8, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1424),
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            Code = "FREESHIP",
                            DiscountAmount = 0m,
                            ExpiryDate = new DateTime(2025, 9, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1430),
                            IsActive = true
                        });
                });

            modelBuilder.Entity("heheshop.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            OrderDate = new DateTime(2025, 7, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1318),
                            Status = "Processing",
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            OrderDate = new DateTime(2025, 7, 23, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1359),
                            Status = "Shipped",
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            OrderDate = new DateTime(2025, 7, 20, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1367),
                            Status = "Delivered",
                            UserId = 4
                        });
                });

            modelBuilder.Entity("heheshop.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductVariantId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductVariantId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductVariantId = 1,
                            Quantity = 2,
                            UnitPrice = 2500000m
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductVariantId = 3,
                            Quantity = 1,
                            UnitPrice = 2700000m
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 3,
                            ProductVariantId = 5,
                            Quantity = 1,
                            UnitPrice = 1200000m
                        });
                });

            modelBuilder.Entity("heheshop.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaidAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsPaid = false,
                            Method = "COD",
                            OrderId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsPaid = false,
                            Method = "COD",
                            OrderId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsPaid = false,
                            Method = "COD",
                            OrderId = 3
                        });
                });

            modelBuilder.Entity("heheshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "Giày thể thao cao cấp",
                            Name = "Nike Air Max",
                            Price = 2500000m,
                            Stock = 10,
                            ThumbnailUrl = "/images/nike_airmax.jpg"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 3,
                            Description = "Chạy bộ cực êm",
                            Name = "Adidas UltraBoost",
                            Price = 2700000m,
                            Stock = 15,
                            ThumbnailUrl = "/images/adidas_ub.jpg"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 4,
                            Description = "Sneaker độc đáo",
                            Name = "Puma RS-X",
                            Price = 1900000m,
                            Stock = 12,
                            ThumbnailUrl = "/images/puma_rsx.jpg"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 4,
                            CategoryId = 2,
                            Description = "Thiết kế đơn giản",
                            Name = "Converse Classic",
                            Price = 1200000m,
                            Stock = 20,
                            ThumbnailUrl = "/images/converse.jpg"
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            CategoryId = 3,
                            Description = "Giày chạy thoáng khí",
                            Name = "Nike Pegasus",
                            Price = 2100000m,
                            Stock = 8,
                            ThumbnailUrl = "/images/nike_pegasus.jpg"
                        });
                });

            modelBuilder.Entity("heheshop.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "/images/nike1.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "/images/nike2.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "/images/adidas1.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "/images/puma1.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "/images/converse1.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "/images/nike_pegasus1.jpg",
                            ProductId = 5
                        });
                });

            modelBuilder.Entity("heheshop.Models.ProductVariant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Trắng",
                            ProductId = 1,
                            Size = "42",
                            Stock = 0
                        },
                        new
                        {
                            Id = 2,
                            Color = "Đen",
                            ProductId = 1,
                            Size = "43",
                            Stock = 0
                        },
                        new
                        {
                            Id = 3,
                            Color = "Xám",
                            ProductId = 2,
                            Size = "41",
                            Stock = 0
                        },
                        new
                        {
                            Id = 4,
                            Color = "Xanh dương",
                            ProductId = 3,
                            Size = "40",
                            Stock = 0
                        },
                        new
                        {
                            Id = 5,
                            Color = "Đỏ",
                            ProductId = 4,
                            Size = "39",
                            Stock = 0
                        },
                        new
                        {
                            Id = 6,
                            Color = "Xanh lá",
                            ProductId = 5,
                            Size = "42",
                            Stock = 0
                        });
                });

            modelBuilder.Entity("heheshop.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comment = "",
                            CreatedAt = new DateTime(2025, 7, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1449),
                            ProductId = 1,
                            Rating = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Comment = "",
                            CreatedAt = new DateTime(2025, 7, 24, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1450),
                            ProductId = 2,
                            Rating = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Comment = "",
                            CreatedAt = new DateTime(2025, 7, 23, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1452),
                            ProductId = 4,
                            Rating = 5,
                            UserId = 4
                        },
                        new
                        {
                            Id = 4,
                            Comment = "",
                            CreatedAt = new DateTime(2025, 7, 22, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1453),
                            ProductId = 5,
                            Rating = 4,
                            UserId = 5
                        });
                });

            modelBuilder.Entity("heheshop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@gmail.com",
                            PasswordHash = "123",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "duy@gmail.com",
                            PasswordHash = "123",
                            Role = "Customer",
                            Username = "duy"
                        },
                        new
                        {
                            Id = 3,
                            Email = "khanh@gmail.com",
                            PasswordHash = "123",
                            Role = "Customer",
                            Username = "khanh"
                        },
                        new
                        {
                            Id = 4,
                            Email = "ngoc@gmail.com",
                            PasswordHash = "123",
                            Role = "Customer",
                            Username = "ngoc"
                        },
                        new
                        {
                            Id = 5,
                            Email = "lan@gmail.com",
                            PasswordHash = "123",
                            Role = "Customer",
                            Username = "lan"
                        });
                });

            modelBuilder.Entity("heheshop.Models.Address", b =>
                {
                    b.HasOne("heheshop.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("heheshop.Models.CartItem", b =>
                {
                    b.HasOne("heheshop.Models.ProductVariant", "ProductVariant")
                        .WithMany()
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("heheshop.Models.User", "User")
                        .WithMany("CartItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductVariant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("heheshop.Models.Order", b =>
                {
                    b.HasOne("heheshop.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("heheshop.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("heheshop.Models.OrderItem", b =>
                {
                    b.HasOne("heheshop.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("heheshop.Models.ProductVariant", "ProductVariant")
                        .WithMany()
                        .HasForeignKey("ProductVariantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductVariant");
                });

            modelBuilder.Entity("heheshop.Models.Payment", b =>
                {
                    b.HasOne("heheshop.Models.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("heheshop.Models.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("heheshop.Models.Product", b =>
                {
                    b.HasOne("heheshop.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("heheshop.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("heheshop.Models.ProductImage", b =>
                {
                    b.HasOne("heheshop.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("heheshop.Models.ProductVariant", b =>
                {
                    b.HasOne("heheshop.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("heheshop.Models.Review", b =>
                {
                    b.HasOne("heheshop.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("heheshop.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("heheshop.Models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("heheshop.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("heheshop.Models.Order", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("heheshop.Models.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Reviews");

                    b.Navigation("Variants");
                });

            modelBuilder.Entity("heheshop.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CartItems");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
