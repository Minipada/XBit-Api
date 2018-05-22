using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class ChangeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MiningFarms_MiningFarms_MiningFarmId",
                table: "MiningFarms");

            migrationBuilder.DropIndex(
                name: "IX_MiningFarms_MiningFarmId",
                table: "MiningFarms");

            migrationBuilder.DropColumn(
                name: "MiningFarmId",
                table: "MiningFarms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MiningFarmId",
                table: "MiningFarms",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiningFarms_MiningFarmId",
                table: "MiningFarms",
                column: "MiningFarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_MiningFarms_MiningFarms_MiningFarmId",
                table: "MiningFarms",
                column: "MiningFarmId",
                principalTable: "MiningFarms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
