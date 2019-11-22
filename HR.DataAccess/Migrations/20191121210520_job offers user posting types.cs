using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DataAccess.Migrations
{
    public partial class joboffersuserpostingtypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APP_OFFERS_DCT_OFFER_STATUSES",
                table: "APP_JOBOFFERS");

            migrationBuilder.DropTable(
                name: "DCT_OFFER_STATUSES");

            migrationBuilder.DropIndex(
                name: "IX_APP_JOBOFFERS_isActive",
                table: "APP_JOBOFFERS");

            migrationBuilder.AlterColumn<string>(
                name: "userPosting",
                table: "APP_JOBOFFERS",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "userApply",
                table: "APP_JOBOFFERS",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "APP_JOBOFFERS",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "userPosting",
                table: "APP_JOBOFFERS",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userApply",
                table: "APP_JOBOFFERS",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "isActive",
                table: "APP_JOBOFFERS",
                nullable: false,
                oldClrType: typeof(bool));

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

            migrationBuilder.CreateIndex(
                name: "IX_APP_JOBOFFERS_isActive",
                table: "APP_JOBOFFERS",
                column: "isActive");

            migrationBuilder.AddForeignKey(
                name: "FK_APP_OFFERS_DCT_OFFER_STATUSES",
                table: "APP_JOBOFFERS",
                column: "isActive",
                principalTable: "DCT_OFFER_STATUSES",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
