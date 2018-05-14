using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Locations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HouseNr = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Locations");
        }
    }
}
