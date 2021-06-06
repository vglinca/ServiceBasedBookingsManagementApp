using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddColourToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ColourId",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    ColourId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.ColourId);
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "ColourId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "Green", 0L },
                    { 2L, "Red", 0L },
                    { 3L, "Blue", 0L },
                    { 4L, "Light Blue", 0L },
                    { 5L, "Yellow", 0L },
                    { 6L, "Orange", 0L },
                    { 7L, "Violet", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ColourId",
                table: "Bookings",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Colours_ColourId",
                table: "Bookings",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "ColourId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Colours_ColourId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ColourId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "Bookings");
        }
    }
}
