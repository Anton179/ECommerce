using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedProductImageProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "ShippingMethods",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "ImagePath");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "ShippingMethods",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Categories",
                newName: "Image");
        }
    }
}
