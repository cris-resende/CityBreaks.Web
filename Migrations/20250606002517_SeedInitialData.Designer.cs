﻿// <auto-generated />
using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityBreaks.Web.Migrations
{
    [DbContext(typeof(CityBreaksContext))]
    [Migration("20250606002517_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("CityBreaks.Web.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("CityName");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "São Paulo"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Nova Iorque"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 3,
                            Name = "Toronto"
                        },
                        new
                        {
                            Id = 6,
                            CountryId = 3,
                            Name = "Vancouver"
                        });
                });

            modelBuilder.Entity("CityBreaks.Web.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryCode = "BR",
                            CountryName = "Brasil"
                        },
                        new
                        {
                            Id = 2,
                            CountryCode = "US",
                            CountryName = "Estados Unidos"
                        },
                        new
                        {
                            Id = 3,
                            CountryCode = "CA",
                            CountryName = "Canadá"
                        });
                });

            modelBuilder.Entity("CityBreaks.Web.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT")
                        .HasColumnName("PropertyName");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Properties", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Apartamento Copacabana",
                            PricePerNight = 250.00m
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Hotel Ipanema",
                            PricePerNight = 400.00m
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            Name = "Times Square Studio",
                            PricePerNight = 300.00m
                        },
                        new
                        {
                            Id = 4,
                            CityId = 4,
                            Name = "Hollywood Hills Villa",
                            PricePerNight = 600.00m
                        },
                        new
                        {
                            Id = 5,
                            CityId = 5,
                            Name = "CN Tower View Condo",
                            PricePerNight = 200.00m
                        },
                        new
                        {
                            Id = 6,
                            CityId = 6,
                            Name = "Stanley Park Cottage",
                            PricePerNight = 350.00m
                        });
                });

            modelBuilder.Entity("CityBreaks.Web.Models.City", b =>
                {
                    b.HasOne("CityBreaks.Web.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CityBreaks.Web.Models.Property", b =>
                {
                    b.HasOne("CityBreaks.Web.Models.City", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityBreaks.Web.Models.City", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("CityBreaks.Web.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
