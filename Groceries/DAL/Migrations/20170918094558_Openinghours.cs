using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GroceriesTool.DAL.Migrations
{
    public partial class Openinghours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Openinghour",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Openingshours",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "Openinghours",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Openinghours",
                table: "Stores");

            migrationBuilder.AddColumn<string>(
                name: "Openinghour",
                table: "Stores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Openingshours",
                table: "Stores",
                nullable: false,
                defaultValue: "");
        }
    }
}
