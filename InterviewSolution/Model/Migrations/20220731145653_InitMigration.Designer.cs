﻿// <auto-generated />
using System;
using InterviewSolution.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InterviewSolution.Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220731145653_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InterviewSolution.Model.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressRecipient")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressSender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("CargoWeight")
                        .HasColumnType("real");

                    b.Property<string>("CityRecipient")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CitySender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReceiptDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressRecipient = "st. Lenina",
                            AddressSender = "st. Velkanskaya",
                            CargoWeight = 2.05f,
                            CityRecipient = "Moscow",
                            CitySender = "Orenburg",
                            ReceiptDateTime = new DateTime(2022, 6, 21, 12, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            AddressRecipient = "st. Woosh",
                            AddressSender = "st. Ocean Gateway",
                            CargoWeight = 25.15f,
                            CityRecipient = "Los-Santos",
                            CitySender = "Berlin",
                            ReceiptDateTime = new DateTime(2016, 6, 29, 16, 43, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            AddressRecipient = "Wall street",
                            AddressSender = "Avenue Victor Hugo",
                            CargoWeight = 300f,
                            CityRecipient = "New-York",
                            CitySender = "Paris",
                            ReceiptDateTime = new DateTime(2020, 3, 15, 14, 33, 52, 0, DateTimeKind.Utc)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
