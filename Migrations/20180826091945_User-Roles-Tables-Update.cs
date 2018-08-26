using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace XBitApi.Migrations
{
    public partial class UserRolesTablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Claim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimsId = table.Column<int>(nullable: false),
                    RolesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClaimRoles_Claims_ClaimsId",
                        column: x => x.ClaimsId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClaimRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaimRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimRolesId = table.Column<int>(nullable: false),
                    UserInformationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaimRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaimRoles_ClaimRoles_ClaimRolesId",
                        column: x => x.ClaimRolesId,
                        principalTable: "ClaimRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClaimRoles_UserInformations_UserInformationId",
                        column: x => x.UserInformationId,
                        principalTable: "UserInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRoles_ClaimsId",
                table: "ClaimRoles",
                column: "ClaimsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClaimRoles_RolesId",
                table: "ClaimRoles",
                column: "RolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimRoles_ClaimRolesId",
                table: "UserClaimRoles",
                column: "ClaimRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaimRoles_UserInformationId",
                table: "UserClaimRoles",
                column: "UserInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClaimRoles");

            migrationBuilder.DropTable(
                name: "ClaimRoles");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Roles");
            
        }
    }
}
