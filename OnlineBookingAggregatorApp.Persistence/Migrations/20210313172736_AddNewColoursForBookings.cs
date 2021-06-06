using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddNewColoursForBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Primary",
                table: "Colours",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Secondary",
                table: "Colours",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 1L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Red", "#ff1744", "#ef5350" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 2L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Pink", "#f06292", "#ec407a" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 3L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Purple", "#9c27b0", "#7b1fa2" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 4L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Deep Purple", "#7e57c2", "#673ab7" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 5L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Indigo", "#3f51b5", "#303f9f" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 6L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Blue", "#1e88e5", "#1565c0" });

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 7L,
                columns: new[] { "Name", "Primary", "Secondary" },
                values: new object[] { "Light Blue", "#29b6f6", "#03a9f4" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "ColourId", "Name", "ParentId", "Primary", "Secondary" },
                values: new object[,]
                {
                    { 19L, "Blue Grey", 0L, "#78909c", "#546e7a" },
                    { 18L, "Grey", 0L, "#9e9e9e", "#757575" },
                    { 17L, "Brown", 0L, "#795548", "#5d4037" },
                    { 15L, "Orange", 0L, "#ff9800", "#f57c00" },
                    { 14L, "Amber", 0L, "#ffca28", "#ffb300" },
                    { 13L, "Yellow", 0L, "#ffeb3b", "#fdd835" },
                    { 12L, "Lime", 0L, "#cddc39", "#c0ca33" },
                    { 11L, "Light Green", 0L, "#9ccc65", "#7cb342" },
                    { 10L, "Green", 0L, "#66bb6a", "#43a047" },
                    { 9L, "Teal", 0L, "#26a69a", "#00897b" },
                    { 16L, "Deep Orange", 0L, "#ff7043", "#ff5722" },
                    { 8L, "Cyan", 0L, "#4dd0e1", "#00acc1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 19L);

            migrationBuilder.DropColumn(
                name: "Primary",
                table: "Colours");

            migrationBuilder.DropColumn(
                name: "Secondary",
                table: "Colours");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 1L,
                column: "Name",
                value: "Green");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 2L,
                column: "Name",
                value: "Red");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 3L,
                column: "Name",
                value: "Blue");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 4L,
                column: "Name",
                value: "Light Blue");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 5L,
                column: "Name",
                value: "Yellow");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 6L,
                column: "Name",
                value: "Orange");

            migrationBuilder.UpdateData(
                table: "Colours",
                keyColumn: "ColourId",
                keyValue: 7L,
                column: "Name",
                value: "Violet");
        }
    }
}
