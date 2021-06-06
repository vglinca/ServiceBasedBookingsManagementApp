using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class RemoveDefaultValueFromIsSetByDefaultInPolicyRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSetByDefault",
                table: "PolicyRoles",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsSetByDefault",
                table: "PolicyRoles",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
