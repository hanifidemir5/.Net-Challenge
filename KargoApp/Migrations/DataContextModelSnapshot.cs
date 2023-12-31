﻿// <auto-generated />
using System;
using KargoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KargoApp.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KargoApp.Models.CarrierConfigurations", b =>
                {
                    b.Property<int>("CarrierConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierConfigurationId"));

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.Property<int?>("CarriersCarrierId")
                        .HasColumnType("int");

                    b.HasKey("CarrierConfigurationId");

                    b.HasIndex("CarriersCarrierId");

                    b.ToTable("CarrierConfigurations");
                });

            modelBuilder.Entity("KargoApp.Models.Carriers", b =>
                {
                    b.Property<int>("CarrierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarrierId"));

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("CarrierId");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("KargoApp.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int?>("CarriersCarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CarriersCarrierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KargoApp.Models.CarrierConfigurations", b =>
                {
                    b.HasOne("KargoApp.Models.Carriers", null)
                        .WithMany("CarrierConfigurations")
                        .HasForeignKey("CarriersCarrierId");
                });

            modelBuilder.Entity("KargoApp.Models.Orders", b =>
                {
                    b.HasOne("KargoApp.Models.Carriers", null)
                        .WithMany("Orders")
                        .HasForeignKey("CarriersCarrierId");
                });

            modelBuilder.Entity("KargoApp.Models.Carriers", b =>
                {
                    b.Navigation("CarrierConfigurations");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
