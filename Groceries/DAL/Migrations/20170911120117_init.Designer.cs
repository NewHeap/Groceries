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
    [Migration("20170911120117_init")]
    partial class init
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

                    b.Property<string>("BuyLocation");

                    b.Property<string>("Code");

                    b.Property<string>("Price");

                    b.Property<string>("Stock");

                    b.Property<string>("StoreName");

                    b.HasKey("Id");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("GroceriesTool.DAL.Models.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Openingshours");

                    b.Property<string>("StoreName");

                    b.Property<string>("StoreLocation");

                    b.HasKey("Id");

                    b.ToTable("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
