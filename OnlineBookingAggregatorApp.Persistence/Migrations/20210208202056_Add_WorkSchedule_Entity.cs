using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_WorkSchedule_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkSchedule",
                schema: "Auth",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "DayTypes",
                columns: table => new
                {
                    DayTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTypes", x => x.DayTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WeekendTypes",
                columns: table => new
                {
                    WeekendTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendTypes", x => x.WeekendTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartingWorkAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DayTypeId = table.Column<long>(type: "bigint", nullable: false),
                    WeekendTypeId = table.Column<long>(type: "bigint", nullable: true),
                    WorkingHoursFrom = table.Column<int>(type: "integer", nullable: false),
                    WorkingMinutesFrom = table.Column<int>(type: "integer", nullable: false),
                    WorkingHoursTo = table.Column<int>(type: "integer", nullable: false),
                    WorkingMinutesTo = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_DayTypes_DayTypeId",
                        column: x => x.DayTypeId,
                        principalTable: "DayTypes",
                        principalColumn: "DayTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_Users_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_WeekendTypes_WeekendTypeId",
                        column: x => x.WeekendTypeId,
                        principalTable: "WeekendTypes",
                        principalColumn: "WeekendTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DayTypes",
                columns: new[] { "DayTypeId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "Work Day", 0L },
                    { 2L, "Weekend", 0L }
                });

            migrationBuilder.InsertData(
                table: "WeekendTypes",
                columns: new[] { "WeekendTypeId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "Sick", 0L },
                    { 2L, "Leave", 0L },
                    { 3L, "Paid Holiday", 0L },
                    { 4L, "Unpaid Holiday", 0L },
                    { 5L, "Standard Weekend (SAT/SUN)", 0L },
                    { 6L, "Absence", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_DayTypeId",
                table: "WorkSchedules",
                column: "DayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_EmployeeId",
                table: "WorkSchedules",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_WeekendTypeId",
                table: "WorkSchedules",
                column: "WeekendTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "DayTypes");

            migrationBuilder.DropTable(
                name: "WeekendTypes");

            migrationBuilder.AddColumn<string>(
                name: "WorkSchedule",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: true);
        }
    }
}
