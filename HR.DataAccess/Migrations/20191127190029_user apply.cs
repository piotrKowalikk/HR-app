using Microsoft.EntityFrameworkCore.Migrations;

namespace HR.DataAccess.Migrations
{
    public partial class userapply : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserApply",
                table: "Offers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserApply",
                table: "Offers",
                nullable: true);
        }
    }
}
