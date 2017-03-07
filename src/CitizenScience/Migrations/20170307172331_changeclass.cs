using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenScience.Migrations
{
    public partial class changeclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaunaLocation",
                table: "Faunas");

            migrationBuilder.AddColumn<string>(
                name: "FaunaLatitude",
                table: "Faunas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaunaLongitude",
                table: "Faunas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaunaLatitude",
                table: "Faunas");

            migrationBuilder.DropColumn(
                name: "FaunaLongitude",
                table: "Faunas");

            migrationBuilder.AddColumn<string>(
                name: "FaunaLocation",
                table: "Faunas",
                nullable: true);
        }
    }
}
