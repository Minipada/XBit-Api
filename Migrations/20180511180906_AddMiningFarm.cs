using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddMiningFarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MiningFarmId",
                table: "Miners",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MiningFarms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiningFarms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Miners_MiningFarmId",
                table: "Miners",
                column: "MiningFarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Miners_MiningFarms_MiningFarmId",
                table: "Miners",
                column: "MiningFarmId",
                principalTable: "MiningFarms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miners_MiningFarms_MiningFarmId",
                table: "Miners");

            migrationBuilder.DropTable(
                name: "MiningFarms");

            migrationBuilder.DropIndex(
                name: "IX_Miners_MiningFarmId",
                table: "Miners");

            migrationBuilder.DropColumn(
                name: "MiningFarmId",
                table: "Miners");
        }
    }
}
