using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_BusinessArea_And_Update_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Warrants");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 0L);

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SubType",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OfficeSpaceArea",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Companies");

            migrationBuilder.RenameColumn(
                name: "ServiceTypeId",
                table: "ServiceTypes",
                newName: "BusinessTypeId");

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "ServiceTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BusinessTypeId",
                table: "Services",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "CompanyTypes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BusinessTypeId",
                table: "Companies",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ParentId",
                table: "AuthorizeRoles",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    ClientId = table.Column<long>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ClientCustomName = table.Column<string>(nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(nullable: false),
                    DateTo = table.Column<DateTimeOffset>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    TotalCost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAreas",
                columns: table => new
                {
                    BusinessAreaId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAreas", x => x.BusinessAreaId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyBusinessAreas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false),
                    BusinessAreaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBusinessAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyBusinessAreas_BusinessAreas_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BusinessAreas",
                        principalColumn: "BusinessAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyBusinessAreas_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessAreas",
                columns: new[] { "BusinessAreaId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "Beauty Salon", 1L },
                    { 62L, "Tuning Center", 7L },
                    { 61L, "Car Showroom", 7L },
                    { 60L, "Auto Body Shop", 7L },
                    { 59L, "Car Wash", 7L },
                    { 58L, "Other Household Services", 6L },
                    { 57L, "Equipment Rental", 6L },
                    { 56L, "Zoo Services", 6L },
                    { 55L, "Equipment Repair", 6L },
                    { 54L, "Cleaning", 6L },
                    { 53L, "Dry Cleaning", 6L },
                    { 52L, "Atelier", 6L },
                    { 51L, "Photo Studio", 6L },
                    { 50L, "Other Entertainment", 5L },
                    { 49L, "Karting", 5L },
                    { 48L, "Massage Salon", 5L },
                    { 47L, "Restaurant", 5L },
                    { 45L, "Cyber Sport", 5L },
                    { 63L, "Vehicle Inspection", 7L },
                    { 44L, "Bowling", 5L },
                    { 64L, "Detailing Center", 7L },
                    { 66L, "Tyre Shop", 7L },
                    { 83L, "Self-employed Specialist", 0L },
                    { 82L, "RealEstate", 9L },
                    { 80L, "Event Management", 9L },
                    { 79L, "Accounting And Auditing", 9L },
                    { 81L, "Law Firm", 9L },
                    { 78L, "Notary", 9L },
                    { 77L, "Other Retail", 8L },
                    { 76L, "Wedding Salon", 8L },
                    { 75L, "Boutique And Showroom", 8L },
                    { 74L, "Shopping Center", 8L },
                    { 73L, "Book Store", 8L },
                    { 72L, "Food Store", 8L },
                    { 71L, "Furniture And Interior", 8L },
                    { 70L, "Cosmetics Store", 8L },
                    { 69L, "Optics Salon", 8L },
                    { 68L, "Another Auto Business", 7L },
                    { 67L, "Car Rental", 7L },
                    { 65L, "Private Mechanic", 7L },
                    { 43L, "Sauna", 5L },
                    { 46L, "Quest", 5L },
                    { 41L, "Driving School", 4L },
                    { 19L, "Hospital", 2L },
                    { 42L, "Other Education", 4L },
                    { 17L, "Psychotherapy And Psychology", 2L },
                    { 16L, "Analysis", 2L },
                    { 15L, "Vet Clinic", 2L },
                    { 14L, "Dentist", 2L },
                    { 13L, "Medical Center", 2L },
                    { 12L, "Other Beauty Business", 1L },
                    { 20L, "Polyclinic", 2L },
                    { 11L, "Other Beauty Services", 1L },
                    { 9L, "Nail Service", 1L },
                    { 8L, "Eyebrows And Eyelashes", 1L },
                    { 7L, "Cosmetology", 1L },
                    { 6L, "Tattoo", 1L },
                    { 5L, "SPA", 1L },
                    { 4L, "Kids Hairdresser", 1L },
                    { 3L, "Private Employee", 1L },
                    { 2L, "Barber Shop", 1L },
                    { 10L, "Waxing", 1L },
                    { 21L, "Diagnostic Center", 2L },
                    { 18L, "Alternative Medicine", 2L },
                    { 23L, "Wellness Massage", 2L },
                    { 40L, "Test Preparation", 4L },
                    { 39L, "School of Music", 4L },
                    { 38L, "Language School", 4L },
                    { 37L, "Kids Workshop", 4L },
                    { 22L, "Women's Consultation", 2L },
                    { 35L, "Other Sport", 3L },
                    { 34L, "Private Services", 3L },
                    { 33L, "Yoga", 3L },
                    { 36L, "Multidisciplinary Courses", 4L },
                    { 31L, "EMS", 3L },
                    { 32L, "Personal Coach", 3L },
                    { 25L, "Fitness Club", 3L },
                    { 26L, "Sport School", 3L },
                    { 24L, "Other Medical Business", 2L },
                    { 28L, "Tennis And Squash", 3L },
                    { 29L, "Swimming Pool", 3L },
                    { 30L, "Trampoline Center", 3L },
                    { 27L, "Dance School", 3L }
                });

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 1L,
                column: "Name",
                value: "Beauty");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 2L,
                column: "Name",
                value: "Healthcare");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 3L,
                column: "Name",
                value: "Sport");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 4L,
                column: "Name",
                value: "Education");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "BusinessTypeId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 5L, "Entertainment", 0L },
                    { 6L, "HouseholdServices", 0L },
                    { 7L, "Auto", 0L },
                    { 8L, "Retail", 0L },
                    { 9L, "Other", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessTypeId",
                table: "Services",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_BusinessTypeId",
                table: "Companies",
                column: "BusinessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBusinessAreas_BusinessAreaId",
                table: "CompanyBusinessAreas",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBusinessAreas_CompanyId",
                table: "CompanyBusinessAreas",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_ServiceTypes_BusinessTypeId",
                table: "Companies",
                column: "BusinessTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "BusinessTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_BusinessTypeId",
                table: "Services",
                column: "BusinessTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "BusinessTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_ServiceTypes_BusinessTypeId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_BusinessTypeId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "CompanyBusinessAreas");

            migrationBuilder.DropTable(
                name: "BusinessAreas");

            migrationBuilder.DropIndex(
                name: "IX_Services_BusinessTypeId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Companies_BusinessTypeId",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ServiceTypes",
                keyColumn: "BusinessTypeId",
                keyValue: 9L);

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "CompanyTypes");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AuthorizeRoles");

            migrationBuilder.RenameColumn(
                name: "BusinessTypeId",
                table: "ServiceTypes",
                newName: "ServiceTypeId");

            migrationBuilder.AddColumn<long>(
                name: "ServiceTypeId",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "SubType",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OfficeSpaceArea",
                table: "Companies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Warrants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientCustomName = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warrants_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warrants_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 1L,
                column: "Name",
                value: "Informational Service");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 2L,
                column: "Name",
                value: "Medical Service");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 3L,
                column: "Name",
                value: "Commercial Service");

            migrationBuilder.UpdateData(
                table: "ServiceTypes",
                keyColumn: "ServiceTypeId",
                keyValue: 4L,
                column: "Name",
                value: "Hotel Service");

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name" },
                values: new object[] { 0L, "Everyday Service" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warrants_ClientId",
                table: "Warrants",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Warrants_ServiceId",
                table: "Warrants",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
