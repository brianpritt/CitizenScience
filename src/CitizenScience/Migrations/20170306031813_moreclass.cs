using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CitizenScience.Migrations
{
    public partial class moreclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faunas",
                columns: table => new
                {
                    FaunaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaunaColor = table.Column<string>(nullable: true),
                    FaunaDescripton = table.Column<string>(nullable: true),
                    FaunaHeight = table.Column<int>(nullable: false),
                    FaunaLength = table.Column<int>(nullable: false),
                    FaunaLocation = table.Column<string>(nullable: true),
                    FaunaName = table.Column<string>(nullable: true),
                    FaunaPhoto = table.Column<byte[]>(nullable: true),
                    SubmitterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faunas", x => x.FaunaId);
                    table.ForeignKey(
                        name: "FK_Faunas_AspNetUsers_SubmitterId",
                        column: x => x.SubmitterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faunas_SubmitterId",
                table: "Faunas",
                column: "SubmitterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faunas");
        }
    }
}
