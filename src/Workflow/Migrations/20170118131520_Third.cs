using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Workflow.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UserLog");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Metadata");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Metadata");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "UserLog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CreatedID",
                table: "Metadata",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileExtension",
                table: "Document",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<int>(nullable: false),
                    Hour = table.Column<int>(nullable: false),
                    Minute = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Second = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_DateID",
                table: "UserLog",
                column: "DateID");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_CreatedID",
                table: "Metadata",
                column: "CreatedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Metadata_Date_CreatedID",
                table: "Metadata",
                column: "CreatedID",
                principalTable: "Date",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLog_Date_DateID",
                table: "UserLog",
                column: "DateID",
                principalTable: "Date",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metadata_Date_CreatedID",
                table: "Metadata");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLog_Date_DateID",
                table: "UserLog");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropIndex(
                name: "IX_UserLog_DateID",
                table: "UserLog");

            migrationBuilder.DropIndex(
                name: "IX_Metadata_CreatedID",
                table: "Metadata");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "UserLog");

            migrationBuilder.DropColumn(
                name: "CreatedID",
                table: "Metadata");

            migrationBuilder.DropColumn(
                name: "FileExtension",
                table: "Document");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "UserLog",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created",
                table: "Metadata",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Version",
                table: "Metadata",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
