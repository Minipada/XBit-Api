using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class AddFinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdminCustomerId",
                table: "MiningFarms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "MiningFarms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MiningFarmId",
                table: "MiningFarms",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserInformationId",
                table: "Administrators",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FarmRights",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CanBuyMiningPackages = table.Column<bool>(nullable: false),
                    CanSwitchCoins = table.Column<bool>(nullable: false),
                    CanWithdrawCoins = table.Column<bool>(nullable: false),
                    HasReadRights = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    FarmMail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserInformationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_UserInformations_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FarmMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    FarmRightId = table.Column<Guid>(nullable: false),
                    MiningFarmId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FarmMembers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmMembers_FarmRights_FarmRightId",
                        column: x => x.FarmRightId,
                        principalTable: "FarmRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FarmMembers_MiningFarms_MiningFarmId",
                        column: x => x.MiningFarmId,
                        principalTable: "MiningFarms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiningFarms_CustomerId",
                table: "MiningFarms",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MiningFarms_MiningFarmId",
                table: "MiningFarms",
                column: "MiningFarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserInformationId",
                table: "Administrators",
                column: "UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserInformationId",
                table: "Customers",
                column: "UserInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmMembers_CustomerId",
                table: "FarmMembers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmMembers_FarmRightId",
                table: "FarmMembers",
                column: "FarmRightId");

            migrationBuilder.CreateIndex(
                name: "IX_FarmMembers_MiningFarmId",
                table: "FarmMembers",
                column: "MiningFarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_UserInformations_UserInformationId",
                table: "Administrators",
                column: "UserInformationId",
                principalTable: "UserInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MiningFarms_Customers_CustomerId",
                table: "MiningFarms",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MiningFarms_MiningFarms_MiningFarmId",
                table: "MiningFarms",
                column: "MiningFarmId",
                principalTable: "MiningFarms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_UserInformations_UserInformationId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_MiningFarms_Customers_CustomerId",
                table: "MiningFarms");

            migrationBuilder.DropForeignKey(
                name: "FK_MiningFarms_MiningFarms_MiningFarmId",
                table: "MiningFarms");

            migrationBuilder.DropTable(
                name: "FarmMembers");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FarmRights");

            migrationBuilder.DropTable(
                name: "UserInformations");

            migrationBuilder.DropIndex(
                name: "IX_MiningFarms_CustomerId",
                table: "MiningFarms");

            migrationBuilder.DropIndex(
                name: "IX_MiningFarms_MiningFarmId",
                table: "MiningFarms");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_UserInformationId",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "AdminCustomerId",
                table: "MiningFarms");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "MiningFarms");

            migrationBuilder.DropColumn(
                name: "MiningFarmId",
                table: "MiningFarms");

            migrationBuilder.DropColumn(
                name: "UserInformationId",
                table: "Administrators");
        }
    }
}
