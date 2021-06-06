using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class ChangeCompanyDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Auth",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyId",
                schema: "Auth",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
