using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_EmployeesSize_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iban",
                table: "Companies");

            migrationBuilder.AddColumn<long>(
                name: "EmployeesSizeId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SizeOfEmployees",
                columns: table => new
                {
                    EmployeesSizeId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SizeOfEmployees", x => x.EmployeesSizeId);
                });

            migrationBuilder.InsertData(
                table: "SizeOfEmployees",
                columns: new[] { "EmployeesSizeId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "1", 0L },
                    { 2L, "2-5", 0L },
                    { 3L, "6-10", 0L },
                    { 4L, "11-20", 0L },
                    { 5L, "21+", 0L }
                });
            
            migrationBuilder.Sql("UPDATE \"Companies\" SET \"EmployeesSizeId\" = 1");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_EmployeesSizeId",
                table: "Companies",
                column: "EmployeesSizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_SizeOfEmployees_EmployeesSizeId",
                table: "Companies",
                column: "EmployeesSizeId",
                principalTable: "SizeOfEmployees",
                principalColumn: "EmployeesSizeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_SizeOfEmployees_EmployeesSizeId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "SizeOfEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Companies_EmployeesSizeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "EmployeesSizeId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Iban",
                table: "Companies",
                type: "text",
                nullable: true);
        }
    }
}
