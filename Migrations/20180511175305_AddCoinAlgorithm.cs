using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddCoinAlgorithm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoinAlgorithms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlgorithmId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinAlgorithms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoinAlgorithms_Algorithms_AlgorithmId",
                        column: x => x.AlgorithmId,
                        principalTable: "Algorithms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoinAlgorithms_AlgorithmId",
                table: "CoinAlgorithms",
                column: "AlgorithmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinAlgorithms");
        }
    }
}
