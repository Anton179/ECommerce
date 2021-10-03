using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class RemovedImageIdFromProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
