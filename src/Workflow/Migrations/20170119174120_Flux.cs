using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workflow.Migrations
{
    public partial class Flux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FluxID",
                table: "Document",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Document",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flux",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flux", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FluxID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Department_Flux_FluxID",
                        column: x => x.FluxID,
                        principalTable: "Flux",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_FluxID",
                table: "Document",
                column: "FluxID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FluxID",
                table: "Department",
                column: "FluxID");

            migrationBuilder.CreateIndex(
                name: "IX_Department_UserID",
                table: "Department",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Flux_FluxID",
                table: "Document",
                column: "FluxID",
                principalTable: "Flux",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Flux_FluxID",
                table: "Document");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Flux");

            migrationBuilder.DropIndex(
                name: "IX_Document_FluxID",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "FluxID",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Document");
        }
    }
}
