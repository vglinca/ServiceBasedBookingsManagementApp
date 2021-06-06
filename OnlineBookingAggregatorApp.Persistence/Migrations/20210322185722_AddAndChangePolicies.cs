using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddAndChangePolicies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1L,
                column: "Name",
                value: "ViewPermissions");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 2L,
                column: "Name",
                value: "EditPermissions");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 3L,
                column: "Name",
                value: "ViewCompanyDetails");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 4L,
                column: "Name",
                value: "EditCompanyDetails");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 5L,
                column: "Name",
                value: "ViewAllBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 6L,
                column: "Name",
                value: "EditUnrelatedBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 7L,
                column: "Name",
                value: "DeleteUnrelatedBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 8L,
                column: "Name",
                value: "CreateUnrelatedBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 9L,
                column: "Name",
                value: "ViewClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 10L,
                column: "Name",
                value: "AddClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 11L,
                column: "Name",
                value: "EditClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 12L,
                column: "Name",
                value: "DeleteClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 13L,
                column: "Name",
                value: "ViewEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 14L,
                column: "Name",
                value: "AddEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 15L,
                column: "Name",
                value: "EditEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 16L,
                column: "Name",
                value: "DeleteEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 17L,
                column: "Name",
                value: "ViewWorkSchedule");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 18L,
                column: "Name",
                value: "EditWorkSchedule");

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 29L, "EditServices", 0L },
                    { 28L, "AddServices", 0L },
                    { 27L, "ViewServices", 0L },
                    { 26L, "DeletePositions", 0L },
                    { 25L, "EditPositions", 0L },
                    { 24L, "AddPositions", 0L },
                    { 23L, "ViewPositions", 0L },
                    { 22L, "DeleteCategories", 0L },
                    { 21L, "EditCategories", 0L },
                    { 20L, "AddCategories", 0L },
                    { 30L, "DeleteServices", 0L },
                    { 19L, "ViewCategories", 0L }
                });

            migrationBuilder.Sql("DELETE FROM public.\"PolicyRoles\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 30L);

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1L,
                column: "Name",
                value: "CanViewEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 2L,
                column: "Name",
                value: "CanManageEmployees");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 3L,
                column: "Name",
                value: "CanAddEmployee");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 4L,
                column: "Name",
                value: "CanChangeEmployeeWorkSchedule");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 5L,
                column: "Name",
                value: "CanManagePositions");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 6L,
                column: "Name",
                value: "CanViewClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 7L,
                column: "Name",
                value: "CanManageClients");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 8L,
                column: "Name",
                value: "CanAddService");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 9L,
                column: "Name",
                value: "CanEditService");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 10L,
                column: "Name",
                value: "CanDeleteService");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 11L,
                column: "Name",
                value: "CanViewOtherPeoplesBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 12L,
                column: "Name",
                value: "CanCreateBooking");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 13L,
                column: "Name",
                value: "CanAmendBooking");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 14L,
                column: "Name",
                value: "CanRemoveBooking");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 15L,
                column: "Name",
                value: "CanAmendOtherEmployeesBookings");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 16L,
                column: "Name",
                value: "CanEditRoles");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 17L,
                column: "Name",
                value: "CanManageRolePolicies");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 18L,
                column: "Name",
                value: "CanEditCompanyInfo");
        }
    }
}
