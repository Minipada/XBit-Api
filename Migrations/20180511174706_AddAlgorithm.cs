using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddAlgorithm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlgorithmId",
                table: "MinerAlgorithms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Algorithms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Algorithms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MinerAlgorithms_AlgorithmId",
                table: "MinerAlgorithms",
                column: "AlgorithmId");

            migrationBuilder.AddForeignKey(
                name: "FK_MinerAlgorithms_Algorithms_AlgorithmId",
                table: "MinerAlgorithms",
                column: "AlgorithmId",
                principalTable: "Algorithms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MinerAlgorithms_Algorithms_AlgorithmId",
                table: "MinerAlgorithms");

            migrationBuilder.DropTable(
                name: "Algorithms");

            migrationBuilder.DropIndex(
                name: "IX_MinerAlgorithms_AlgorithmId",
                table: "MinerAlgorithms");

            migrationBuilder.DropColumn(
                name: "AlgorithmId",
                table: "MinerAlgorithms");
        }
    }
}
