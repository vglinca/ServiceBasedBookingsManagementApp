using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class NullableCreatedByAndUpdatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_Users_CreatedById",
                table: "PolicyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_Users_UpdatedById",
                table: "PolicyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "WorkSchedules",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "WorkSchedules",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Services",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Services",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "ServiceEmployees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "ServiceEmployees",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Positions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Positions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "PolicyRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "PolicyRoles",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "CompanyBusinessAreas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "CompanyBusinessAreas",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Companies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Companies",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Clients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Clients",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Categories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Categories",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Bookings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Bookings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_Users_CreatedById",
                table: "PolicyRoles",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_Users_UpdatedById",
                table: "PolicyRoles",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_Users_CreatedById",
                table: "PolicyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_Users_UpdatedById",
                table: "PolicyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services");

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "WorkSchedules",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "WorkSchedules",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "ServiceEmployees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "ServiceEmployees",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Positions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Positions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "PolicyRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "PolicyRoles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "CompanyBusinessAreas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "CompanyBusinessAreas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UpdatedById",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CreatedById",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_Users_CreatedById",
                table: "PolicyRoles",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_Users_UpdatedById",
                table: "PolicyRoles",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
