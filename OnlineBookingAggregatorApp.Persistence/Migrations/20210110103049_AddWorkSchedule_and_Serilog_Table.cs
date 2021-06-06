using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddWorkSchedule_and_Serilog_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkSchedule",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.Sql(@"CREATE TABLE IF NOT EXISTS public.serilog (id BIGSERIAL PRIMARY KEY NOT NULL, 
                                    message TEXT, message_template TEXT, level VARCHAR(128), time_stamp TIMESTAMP, 
                                    exception TEXT, properties TEXT)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkSchedule",
                schema: "Auth",
                table: "Users");
        }
    }
}
