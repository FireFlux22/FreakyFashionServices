﻿// <auto-generated />
using FreakyFashionServices.Catalog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FreakyFashionServices.Catalog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210103092833_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FreakyFashionServices.Catalog.Data.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AvailableStock")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailableStock = 4,
                            Description = "Lorem ipsum dolor",
                            Name = "Black pants",
                            Price = 499m
                        },
                        new
                        {
                            Id = 2,
                            AvailableStock = 2,
                            Description = "Trouble on two legs",
                            Name = "Red dress",
                            Price = 899m
                        },
                        new
                        {
                            Id = 3,
                            AvailableStock = 10,
                            Description = "Howdy, partner!",
                            Name = "Cowboy hat",
                            Price = 250m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
