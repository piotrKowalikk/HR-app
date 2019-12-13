using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DataAccess.Migrations
{
    public partial class foreignkeyofferuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Offers_Users_UserId1",
            //    table: "Offers");

            //migrationBuilder.DropIndex(
            //    name: "IX_Offers_UserId1",
            //    table: "Offers");

            //migrationBuilder.DropColumn(
            //    name: "UserId1",
            //    table: "Offers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "UserId",
            //    table: "Offers",
            //    nullable: false,
            //    oldClrType: typeof(string));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Offers_UserId",
            //    table: "Offers",
            //    column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Offers_Users_UserId",
            //    table: "Offers",
            //    column: "UserId",
            //    principalTable: "Users",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_UserId",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(int));

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
    }
}
