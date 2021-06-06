using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_WeekDayToWorkSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_DayTypes_DayTypeId",
                table: "WorkSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkSchedules_WeekendTypes_WeekendTypeId",
                table: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "DayTypes");

            migrationBuilder.DropTable(
                name: "WeekendTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedules_DayTypeId",
                table: "WorkSchedules");

            migrationBuilder.DropIndex(
                name: "IX_WorkSchedules_WeekendTypeId",
                table: "WorkSchedules");

            migrationBuilder.DropColumn(
                name: "DayTypeId",
                table: "WorkSchedules");

            migrationBuilder.DropColumn(
                name: "WeekendTypeId",
                table: "WorkSchedules");

            migrationBuilder.CreateTable(
                name: "DaysOfWeek",
                columns: table => new
                {
                    WeekDayId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfWeek", x => x.WeekDayId);
                });

            migrationBuilder.CreateTable(
                name: "WeekDayWorkSchedules",
                columns: table => new
                {
                    WeekDayWorkScheduleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkScheduleId = table.Column<long>(type: "bigint", nullable: false),
                    WeekDayId = table.Column<long>(type: "bigint", nullable: false),
                    SystemCreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDayWorkSchedules", x => x.WeekDayWorkScheduleId);
                    table.ForeignKey(
                        name: "FK_WeekDayWorkSchedules_DaysOfWeek_WeekDayId",
                        column: x => x.WeekDayId,
                        principalTable: "DaysOfWeek",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeekDayWorkSchedules_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekDayWorkSchedules_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeekDayWorkSchedules_WorkSchedules_WorkScheduleId",
                        column: x => x.WorkScheduleId,
                        principalTable: "WorkSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DaysOfWeek",
                columns: new[] { "WeekDayId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "Sunday", 0L },
                    { 2L, "Monday", 0L },
                    { 3L, "Tuesday", 0L },
                    { 4L, "Wednesday", 0L },
                    { 5L, "Thursday", 0L },
                    { 6L, "Friday", 0L },
                    { 7L, "Saturday", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayWorkSchedules_CreatedById",
                table: "WeekDayWorkSchedules",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayWorkSchedules_UpdatedById",
                table: "WeekDayWorkSchedules",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayWorkSchedules_WeekDayId",
                table: "WeekDayWorkSchedules",
                column: "WeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDayWorkSchedules_WorkScheduleId",
                table: "WeekDayWorkSchedules",
                column: "WorkScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDayWorkSchedules");

            migrationBuilder.DropTable(
                name: "DaysOfWeek");

            migrationBuilder.AddColumn<long>(
                name: "DayTypeId",
                table: "WorkSchedules",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WeekendTypeId",
                table: "WorkSchedules",
                type: "bigint",
                nullable: true);

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
                name: "IX_WorkSchedules_WeekendTypeId",
                table: "WorkSchedules",
                column: "WeekendTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_DayTypes_DayTypeId",
                table: "WorkSchedules",
                column: "DayTypeId",
                principalTable: "DayTypes",
                principalColumn: "DayTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkSchedules_WeekendTypes_WeekendTypeId",
                table: "WorkSchedules",
                column: "WeekendTypeId",
                principalTable: "WeekendTypes",
                principalColumn: "WeekendTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
