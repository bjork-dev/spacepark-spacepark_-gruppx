﻿// <auto-generated />
using System;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassLibrary.Migrations
{
    [DbContext(typeof(SpaceContext))]
    partial class SpaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassLibrary.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Fee")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxLength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<string>("ParkedBy")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShipName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Parkings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fee = 10,
                            MaxLength = 50m,
                            Occupied = false
                        },
                        new
                        {
                            Id = 2,
                            Fee = 50,
                            MaxLength = 100m,
                            Occupied = false
                        },
                        new
                        {
                            Id = 3,
                            Fee = 100,
                            MaxLength = 200m,
                            Occupied = false
                        },
                        new
                        {
                            Id = 4,
                            Fee = 1000,
                            MaxLength = 2000m,
                            Occupied = false
                        },
                        new
                        {
                            Id = 5,
                            Fee = 5,
                            MaxLength = 15m,
                            Occupied = false
                        });
                });

            modelBuilder.Entity("ClassLibrary.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
