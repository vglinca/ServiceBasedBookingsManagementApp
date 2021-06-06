using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Rename_FirstRankClientType_To_CompanyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_FirstRankClientTypes_FirstRankClientTypeId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "FirstRankClientTypes");

            migrationBuilder.DropIndex(
                name: "IX_Companies_FirstRankClientTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "FirstRankClientTypeId",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "CompanyTypeId",
                table: "Companies",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CompanyTypes",
                columns: table => new
                {
                    CompanyTypeId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTypes", x => x.CompanyTypeId);
                });

            migrationBuilder.InsertData(
                table: "CompanyTypes",
                columns: new[] { "CompanyTypeId", "Name" },
                values: new object[,]
                {
                    { 0L, "Juridical Person" },
                    { 1L, "Physical Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies",
                column: "CompanyTypeId",
                principalTable: "CompanyTypes",
                principalColumn: "CompanyTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyTypes_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CompanyTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "FirstRankClientTypeId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "FirstRankClientTypes",
                columns: table => new
                {
                    FirstRankClientTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstRankClientTypes", x => x.FirstRankClientTypeId);
                });

            migrationBuilder.InsertData(
                table: "FirstRankClientTypes",
                columns: new[] { "FirstRankClientTypeId", "Name" },
                values: new object[,]
                {
                    { 0L, "Juridical Person" },
                    { 1L, "Physical Person" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FirstRankClientTypeId",
                table: "Companies",
                column: "FirstRankClientTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_FirstRankClientTypes_FirstRankClientTypeId",
                table: "Companies",
                column: "FirstRankClientTypeId",
                principalTable: "FirstRankClientTypes",
                principalColumn: "FirstRankClientTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
