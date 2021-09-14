using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedProductConfigurationOnDeleteAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicsValue_Products_ProductId",
                table: "CharacteristicsValue");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicsValue_Products_ProductId",
                table: "CharacteristicsValue",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CharacteristicsValue_Products_ProductId",
                table: "CharacteristicsValue");

            migrationBuilder.AddForeignKey(
                name: "FK_CharacteristicsValue_Products_ProductId",
                table: "CharacteristicsValue",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
