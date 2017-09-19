﻿// <auto-generated />
using GroceriesTool.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GroceriesTool.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20170918084537_Closinghours")]
    partial class Closinghours
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroceriesTool.DAL.Models.Groceries", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuyLocation")
                        .IsRequired();

                    b.Property<string>("Code")
                        .HasMaxLength(4);

                    b.Property<string>("Price");

                    b.Property<string>("Product")
                        .IsRequired();

                    b.Property<string>("Stock")
                        .IsRequired();

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("GroceriesTool.DAL.Models.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Closinghours")
                        .IsRequired();

                    b.Property<string>("Openinghour")
                        .IsRequired();

                    b.Property<string>("Openingshours")
                        .IsRequired();

                    b.Property<string>("StoreLocation")
                        .IsRequired();

                    b.Property<string>("StoreName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
