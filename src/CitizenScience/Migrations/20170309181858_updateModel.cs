using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitizenScience.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faunas_FaunaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FaunaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FaunaId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Faunas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Faunas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faunas_ApplicationUserId1",
                table: "Faunas",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Faunas_AspNetUsers_ApplicationUserId1",
                table: "Faunas",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faunas_AspNetUsers_ApplicationUserId1",
                table: "Faunas");

            migrationBuilder.DropIndex(
                name: "IX_Faunas_ApplicationUserId1",
                table: "Faunas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Faunas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Faunas");

            migrationBuilder.AddColumn<int>(
                name: "FaunaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FaunaId",
                table: "AspNetUsers",
                column: "FaunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faunas_FaunaId",
                table: "AspNetUsers",
                column: "FaunaId",
                principalTable: "Faunas",
                principalColumn: "FaunaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
