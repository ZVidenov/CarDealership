﻿// <auto-generated />
using System;
using CarDealership.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarDealership.Migrations
{
    [DbContext(typeof(DealershipContext))]
    partial class DealershipContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarDealership.Data.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarDealership.Data.Models.CarFeature", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("CarFeatures");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Salesman", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Profits")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Salesmen");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Model", "Model")
                        .WithMany("Cars")
                        .HasForeignKey("ModelId");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("CarDealership.Data.Models.CarFeature", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Car", "Car")
                        .WithMany("Features")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarDealership.Data.Models.Feature", "Feature")
                        .WithMany("Cars")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Model", b =>
                {
                    b.HasOne("CarDealership.Data.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Car", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Feature", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarDealership.Data.Models.Model", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
