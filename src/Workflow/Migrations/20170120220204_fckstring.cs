using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class fckstring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Metadata");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Metadata",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Metadata");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Metadata",
                nullable: false,
                defaultValue: 0);
        }
    }
}
