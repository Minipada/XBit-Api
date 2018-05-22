using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class EditAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNr",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "HouseNr",
                table: "Addresses",
                nullable: true);
        }
    }
}
