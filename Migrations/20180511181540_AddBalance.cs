using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CoinId = table.Column<Guid>(nullable: false),
                    MiningFarmId = table.Column<Guid>(nullable: false),
                    TotalFarmedAmount = table.Column<double>(nullable: false),
                    WalletAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_Coins_CoinId",
                        column: x => x.CoinId,
                        principalTable: "Coins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Balances_MiningFarms_MiningFarmId",
                        column: x => x.MiningFarmId,
                        principalTable: "MiningFarms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_CoinId",
                table: "Balances",
                column: "CoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_MiningFarmId",
                table: "Balances",
                column: "MiningFarmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");
        }
    }
}
