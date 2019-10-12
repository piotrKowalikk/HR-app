using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCT_OFFER_STATUSES",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCT_OFFER_STATUSES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DCT_ROLES",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    roleName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCT_ROLES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "APP_OFFERS",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    company = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    position = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    salaryFrom = table.Column<int>(nullable: true),
                    salaryTo = table.Column<int>(nullable: true),
                    isActive = table.Column<int>(nullable: false),
                    datePosted = table.Column<DateTime>(type: "date", nullable: false),
                    dateExpiration = table.Column<DateTime>(type: "date", nullable: false),
                    userPosting = table.Column<int>(nullable: false),
                    userApply = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APP_OFFERS", x => x.id);
                    table.ForeignKey(
                        name: "FK_APP_OFFERS_DCT_OFFER_STATUSES",
                        column: x => x.isActive,
                        principalTable: "DCT_OFFER_STATUSES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "APP_USERS",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: false),
                    lastname = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 30, nullable: false),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APP_USERS", x => x.id);
                    table.ForeignKey(
                        name: "FK_APP_USERS_DCT_ROLES",
                        column: x => x.roleId,
                        principalTable: "DCT_ROLES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APP_OFFERS_isActive",
                table: "APP_OFFERS",
                column: "isActive");

            migrationBuilder.CreateIndex(
                name: "IX_APP_USERS_roleId",
                table: "APP_USERS",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APP_OFFERS");

            migrationBuilder.DropTable(
                name: "APP_USERS");

            migrationBuilder.DropTable(
                name: "DCT_OFFER_STATUSES");

            migrationBuilder.DropTable(
                name: "DCT_ROLES");
        }
    }
}
