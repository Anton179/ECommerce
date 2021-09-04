using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class UpdatedCharacteristicsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValueDate",
                table: "CharacteristicsValue",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ValueInt",
                table: "CharacteristicsValue",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueDate",
                table: "CharacteristicsValue");

            migrationBuilder.DropColumn(
                name: "ValueInt",
                table: "CharacteristicsValue");
        }
    }
}
