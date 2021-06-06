using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddBookingState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BookingStateId",
                table: "Bookings",
                type: "bigint",
                nullable: false,
                defaultValue: 1L);

            migrationBuilder.CreateTable(
                name: "BookingStates",
                columns: table => new
                {
                    BookingStateId = table.Column<long>(type: "bigint", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingStates", x => x.BookingStateId);
                });

            migrationBuilder.InsertData(
                table: "BookingStates",
                columns: new[] { "BookingStateId", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "access_time", "Waiting For Client", 0L },
                    { 2L, "hail", "Client Arrived", 0L },
                    { 3L, "person_off", "Client Missing", 0L },
                    { 4L, "check", "Client Confirmed", 0L },
                    { 5L, "clear", "Cancelled", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingStateId",
                table: "Bookings",
                column: "BookingStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BookingStates_BookingStateId",
                table: "Bookings",
                column: "BookingStateId",
                principalTable: "BookingStates",
                principalColumn: "BookingStateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BookingStates_BookingStateId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingStates");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingStateId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingStateId",
                table: "Bookings");
        }
    }
}
