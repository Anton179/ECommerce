using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Core.DataAccess.Migrations
{
    public partial class ChangedTableNameUserTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "Auth",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Auth",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Auth",
                newName: "UserTokens",
                newSchema: "Auth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Auth",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "Auth",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                schema: "Auth",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Auth",
                table: "UserTokens");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Auth",
                newName: "UserRoles",
                newSchema: "Auth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Auth",
                table: "UserRoles",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                schema: "Auth",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
