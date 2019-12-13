using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DataAccess.Migrations
{
    public partial class foreignkeyfromoffertouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPosting",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Offers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Offers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId1",
                table: "Offers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId1",
                table: "Offers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId1",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserId1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "UserPosting",
                table: "Offers",
                nullable: true);
        }
    }
}
