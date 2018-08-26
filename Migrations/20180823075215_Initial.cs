using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Watts",
                table: "MinerTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Coins",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Watts",
                table: "MinerTypes");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Coins");
        }
    }
}
