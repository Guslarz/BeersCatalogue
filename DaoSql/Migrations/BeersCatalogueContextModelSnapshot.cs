﻿// <auto-generated />
using System;
using Kaczmarek.BeersCatalogue.DaoSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kaczmarek.BeersCatalogue.DaoSql.Migrations
{
    [DbContext(typeof(BeersCatalogueContext))]
    partial class BeersCatalogueContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("Kaczmarek.BeersCatalogue.DaoSql.Beer", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Abv")
                        .HasColumnType("REAL");

                    b.Property<int?>("BreweryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ibu")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Style")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BreweryId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("Kaczmarek.BeersCatalogue.DaoSql.Brewery", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("Kaczmarek.BeersCatalogue.DaoSql.Beer", b =>
                {
                    b.HasOne("Kaczmarek.BeersCatalogue.DaoSql.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryId");
                });
#pragma warning restore 612, 618
        }
    }
}
