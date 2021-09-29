using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedCharacteristicModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Characteristics",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Characteristics");
        }
    }
}
