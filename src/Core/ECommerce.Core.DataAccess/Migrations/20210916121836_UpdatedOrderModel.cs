using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedOrderModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryPrice",
                table: "Orders",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "DeliveryPrice");
        }
    }
}
