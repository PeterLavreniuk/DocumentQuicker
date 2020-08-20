﻿// <auto-generated />
using System;
using DocumentQuicker.DataProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocumentQuicker.DataProvider.Migrations
{
    [DbContext(typeof(DocumentQuickerContext))]
    [Migration("20200820153156_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentQuicker.DataProvider.Models.BankInfoEf", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("BankDescription")
                        .HasColumnType("text");

                    b.Property<string>("Bic")
                        .HasColumnType("text");

                    b.Property<string>("CorrAccount")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("BankInfos");
                });
#pragma warning restore 612, 618
        }
    }
}