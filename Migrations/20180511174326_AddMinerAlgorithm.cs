using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddMinerAlgorithm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinerType_Manufacturers_ManufacturerId",
                table: "MinerType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MinerType",
                table: "MinerType");

            migrationBuilder.RenameTable(
                name: "MinerType",
                newName: "MinerTypes");

            migrationBuilder.RenameIndex(
                name: "IX_MinerType_ManufacturerId",
                table: "MinerTypes",
                newName: "IX_MinerTypes_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MinerTypes",
                table: "MinerTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MinerAlgorithms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Hashrate = table.Column<double>(nullable: false),
                    MinerTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinerAlgorithms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinerAlgorithms_MinerTypes_MinerTypeId",
                        column: x => x.MinerTypeId,
                        principalTable: "MinerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MinerAlgorithms_MinerTypeId",
                table: "MinerAlgorithms",
                column: "MinerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MinerTypes_Manufacturers_ManufacturerId",
                table: "MinerTypes",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinerTypes_Manufacturers_ManufacturerId",
                table: "MinerTypes");

            migrationBuilder.DropTable(
                name: "MinerAlgorithms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MinerTypes",
                table: "MinerTypes");

            migrationBuilder.RenameTable(
                name: "MinerTypes",
                newName: "MinerType");

            migrationBuilder.RenameIndex(
                name: "IX_MinerTypes_ManufacturerId",
                table: "MinerType",
                newName: "IX_MinerType_ManufacturerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MinerType",
                table: "MinerType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MinerType_Manufacturers_ManufacturerId",
                table: "MinerType",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
