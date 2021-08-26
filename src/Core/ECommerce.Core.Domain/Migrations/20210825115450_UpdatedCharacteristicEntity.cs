using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedCharacteristicEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "CharacteristicsValue",
                newName: "ValueStr");

            migrationBuilder.RenameColumn(
                name: "CharacteristicIntType_Value",
                table: "CharacteristicsValue",
                newName: "ValueInt");

            migrationBuilder.RenameColumn(
                name: "CharacteristicDecimalType_Value",
                table: "CharacteristicsValue",
                newName: "ValueDec");

            migrationBuilder.RenameColumn(
                name: "CharacteristicDateType_Value",
                table: "CharacteristicsValue",
                newName: "ValueDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValueStr",
                table: "CharacteristicsValue",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "ValueInt",
                table: "CharacteristicsValue",
                newName: "CharacteristicIntType_Value");

            migrationBuilder.RenameColumn(
                name: "ValueDec",
                table: "CharacteristicsValue",
                newName: "CharacteristicDecimalType_Value");

            migrationBuilder.RenameColumn(
                name: "ValueDate",
                table: "CharacteristicsValue",
                newName: "CharacteristicDateType_Value");
        }
    }
}
