using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddShelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShelfId",
                table: "Miners",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Shelves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelves", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miners_ShelfId",
                table: "Miners",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miners_Shelves_ShelfId",
                table: "Miners",
                column: "ShelfId",
                principalTable: "Shelves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miners_Shelves_ShelfId",
                table: "Miners");

            migrationBuilder.DropTable(
                name: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Miners_ShelfId",
                table: "Miners");

            migrationBuilder.DropColumn(
                name: "ShelfId",
                table: "Miners");
        }
    }
}
