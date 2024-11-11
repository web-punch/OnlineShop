﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240529203902_ChangedProductModel_2")]
    partial class ChangedProductModel_2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.Property<Guid>("FavoritesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FavoritesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("FavoritesProduct");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Favorites", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.OrderInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrderInfo");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagesPaths")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86a0f74c-8b5b-4c1c-94b0-218d3728a4b7"),
                            Cost = 400m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/roses.jpg",
                            ImagesPaths = "[]",
                            Name = "Розы"
                        },
                        new
                        {
                            Id = new Guid("98b4dfd6-95d5-4793-b0b8-f42862fd3a4a"),
                            Cost = 300m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/chrysanthemums.jpg",
                            ImagesPaths = "[]",
                            Name = "Хризантемы"
                        },
                        new
                        {
                            Id = new Guid("175ee3b4-5064-4a1e-a272-0b0d741c7829"),
                            Cost = 250m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/carnations.jpg",
                            ImagesPaths = "[]",
                            Name = "Гвоздики"
                        },
                        new
                        {
                            Id = new Guid("d1e3fee7-2cd7-4fe2-b83e-8a8ad501dfca"),
                            Cost = 200m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/peonies.jpg",
                            ImagesPaths = "[]",
                            Name = "Пионы"
                        },
                        new
                        {
                            Id = new Guid("8df0a7ef-ac9c-42a5-8203-42cecd57a2f2"),
                            Cost = 150m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/chamomiles.jpg",
                            ImagesPaths = "[]",
                            Name = "Ромашки"
                        },
                        new
                        {
                            Id = new Guid("756795c8-d812-4e3f-be04-c274b8c44da5"),
                            Cost = 200m,
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.",
                            ImagePath = "/images/tulips.jpg",
                            ImagesPaths = "[]",
                            Name = "Тюльпаны"
                        });
                });

            modelBuilder.Entity("FavoritesProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Favorites", null)
                        .WithMany()
                        .HasForeignKey("FavoritesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Db.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.OrderInfo", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Info");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}