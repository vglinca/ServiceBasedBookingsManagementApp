using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_Position_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PositionId",
                table: "CompanyUsers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_PositionId",
                table: "CompanyUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CompanyId",
                table: "Positions",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyUsers_Positions_PositionId",
                table: "CompanyUsers",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyUsers_Positions_PositionId",
                table: "CompanyUsers");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_CompanyUsers_PositionId",
                table: "CompanyUsers");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "CompanyUsers");
        }
    }
}
