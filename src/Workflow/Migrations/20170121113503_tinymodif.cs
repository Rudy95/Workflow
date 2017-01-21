using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Workflow.Migrations
{
    public partial class tinymodif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Metadata_MetaDataID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Status_StatusID",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Metadata_MetaDataID",
                table: "Keyword");

            migrationBuilder.DropForeignKey(
                name: "FK_Metadata_Date_CreatedID",
                table: "Metadata");

            migrationBuilder.RenameColumn(
                name: "CreatedID",
                table: "Metadata",
                newName: "CreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Metadata_CreatedID",
                table: "Metadata",
                newName: "IX_Metadata_CreatedId");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "Document",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "MetaDataID",
                table: "Document",
                newName: "MetaDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_StatusID",
                table: "Document",
                newName: "IX_Document_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_MetaDataID",
                table: "Document",
                newName: "IX_Document_MetaDataId");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedId",
                table: "Metadata",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MetaDataID",
                table: "Keyword",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Document",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MetaDataId",
                table: "Document",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Metadata_MetaDataId",
                table: "Document",
                column: "MetaDataId",
                principalTable: "Metadata",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Status_StatusId",
                table: "Document",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Metadata_MetaDataID",
                table: "Keyword",
                column: "MetaDataID",
                principalTable: "Metadata",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Metadata_Date_CreatedId",
                table: "Metadata",
                column: "CreatedId",
                principalTable: "Date",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Document_Metadata_MetaDataId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Status_StatusId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyword_Metadata_MetaDataID",
                table: "Keyword");

            migrationBuilder.DropForeignKey(
                name: "FK_Metadata_Date_CreatedId",
                table: "Metadata");

            migrationBuilder.RenameColumn(
                name: "CreatedId",
                table: "Metadata",
                newName: "CreatedID");

            migrationBuilder.RenameIndex(
                name: "IX_Metadata_CreatedId",
                table: "Metadata",
                newName: "IX_Metadata_CreatedID");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Document",
                newName: "StatusID");

            migrationBuilder.RenameColumn(
                name: "MetaDataId",
                table: "Document",
                newName: "MetaDataID");

            migrationBuilder.RenameIndex(
                name: "IX_Document_StatusId",
                table: "Document",
                newName: "IX_Document_StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_Document_MetaDataId",
                table: "Document",
                newName: "IX_Document_MetaDataID");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedID",
                table: "Metadata",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MetaDataID",
                table: "Keyword",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "Document",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MetaDataID",
                table: "Document",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Metadata_MetaDataID",
                table: "Document",
                column: "MetaDataID",
                principalTable: "Metadata",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Status_StatusID",
                table: "Document",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Keyword_Metadata_MetaDataID",
                table: "Keyword",
                column: "MetaDataID",
                principalTable: "Metadata",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metadata_Date_CreatedID",
                table: "Metadata",
                column: "CreatedID",
                principalTable: "Date",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
