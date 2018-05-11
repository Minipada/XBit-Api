using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddCoinAndMiner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoinId",
                table: "CoinAlgorithms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PriceUrl = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Miners",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoinAlgorithmId = table.Column<Guid>(nullable: false),
                    MinerTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Miners_CoinAlgorithms_CoinAlgorithmId",
                        column: x => x.CoinAlgorithmId,
                        principalTable: "CoinAlgorithms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Miners_MinerTypes_MinerTypeId",
                        column: x => x.MinerTypeId,
                        principalTable: "MinerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlgorithms_CoinId",
                table: "CoinAlgorithms",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Miners_CoinAlgorithmId",
                table: "Miners",
                column: "CoinAlgorithmId");

            migrationBuilder.CreateIndex(
                name: "IX_Miners_MinerTypeId",
                table: "Miners",
                column: "MinerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoinAlgorithms_Coins_CoinId",
                table: "CoinAlgorithms",
                column: "CoinId",
                principalTable: "Coins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoinAlgorithms_Coins_CoinId",
                table: "CoinAlgorithms");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Miners");

            migrationBuilder.DropIndex(
                name: "IX_CoinAlgorithms_CoinId",
                table: "CoinAlgorithms");

            migrationBuilder.DropColumn(
                name: "CoinId",
                table: "CoinAlgorithms");
        }
    }
}
