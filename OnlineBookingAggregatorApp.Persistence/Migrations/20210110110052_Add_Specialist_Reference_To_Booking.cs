using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_Specialist_Reference_To_Booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<long>(
                name: "SpecialistId",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SpecialistId",
                table: "Bookings",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_SpecialistId",
                table: "Bookings",
                column: "SpecialistId",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_SpecialistId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SpecialistId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Bookings");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Bookings",
                type: "text",
                nullable: true);
        }
    }
}
