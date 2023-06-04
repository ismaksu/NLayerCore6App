﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NLayer.Repository;

#nullable disable

namespace NLayer.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230604182055_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NLayer.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kitaplar"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(858),
                            Name = "Faber Castell",
                            Price = 100m,
                            Stock = 65
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(866),
                            Name = "Rotring",
                            Price = 150m,
                            Stock = 55
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(867),
                            Name = "Studi",
                            Price = 40m,
                            Stock = 100
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(869),
                            Name = "Dostoyevski",
                            Price = 30m,
                            Stock = 25
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(870),
                            Name = "Ömer Seyfettin",
                            Price = 25m,
                            Stock = 33
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            CreationDate = new DateTime(2023, 6, 4, 21, 20, 54, 742, DateTimeKind.Local).AddTicks(872),
                            Name = "Müzik Defteri",
                            Price = 20m,
                            Stock = 40
                        });
                });

            modelBuilder.Entity("NLayer.Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Turkuaz",
                            Height = 3,
                            ProductId = 1,
                            Width = 20
                        },
                        new
                        {
                            Id = 2,
                            Color = "Kırmızı",
                            Height = 2,
                            ProductId = 2,
                            Width = 15
                        });
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.HasOne("NLayer.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("NLayer.Core.ProductFeature", b =>
                {
                    b.HasOne("NLayer.Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("NLayer.Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("NLayer.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("NLayer.Core.Product", b =>
                {
                    b.Navigation("ProductFeature")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
