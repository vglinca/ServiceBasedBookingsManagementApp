using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddPoliciesToRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_ClientCategories_ClientCategoryId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AuthorizeRoles");

            migrationBuilder.DropTable(
                name: "ClientCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Users_ClientCategoryId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClientCategoryId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                schema: "Auth",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                schema: "Auth",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                schema: "Auth",
                table: "Users",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Positions",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EmployeesSizeId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                defaultValue: 1L,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Clients",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalPhoneNumber",
                table: "Clients",
                type: "character varying(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Bookings",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Positions_Name",
                table: "Positions",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "PolicyId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 8L, "CanAddService", 0L },
                    { 16L, "CanEditRoles", 0L },
                    { 15L, "CanAmendOtherEmployeesBookings", 0L },
                    { 14L, "CanRemoveBooking", 0L },
                    { 13L, "CanAmendBooking", 0L },
                    { 12L, "CanCreateBooking", 0L },
                    { 11L, "CanViewOtherPeoplesBookings", 0L },
                    { 10L, "CanDeleteService", 0L },
                    { 9L, "CanEditService", 0L },
                    { 17L, "CanManageRolePolicies", 0L },
                    { 18L, "CanEditCompanyInfo", 0L },
                    { 6L, "CanViewClients", 0L },
                    { 5L, "CanManagePositions", 0L },
                    { 4L, "CanChangeEmployeeWorkSchedule", 0L },
                    { 3L, "CanAddEmployee", 0L },
                    { 2L, "CanManageEmployees", 0L },
                    { 1L, "CanViewEmployees", 0L },
                    { 7L, "CanManageClients", 0L }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 3L, "57d1e893-49e5-4df9-9f1d-6eeabc06ef72", "Specialist", null },
                    { 2L, "a489f96f-04aa-47eb-be18-8b3112cc3902", "CompanyAdminDeputy", null },
                    { 1L, "ad93aebb-c404-4bf3-b3e6-b46c856c5aa5", "CompanyAdmin", null }
                });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("fe88cbd4-7816-4ce7-b093-5f78076373e6"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(1248), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("31ce432a-2527-4119-9bd4-5000d34bfffd"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7253), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("0a83f98b-d947-451b-8167-6ac2ef47cecc"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("6a5ad867-661f-46b7-89d4-a37081be0c53"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("d45c4f51-2203-44fe-8c12-0664242a491f"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("2683d2c7-90c8-421d-843b-43ecb6cd1656"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("d190356a-c161-4984-b823-c047e13ac188"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7852), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("09cbc571-8f8d-4554-ad8e-9ad706d287c8"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("a2a027f2-9144-441e-b4cf-0ba0544c90f0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7905), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("576aa95d-0af6-40da-8c93-18d4647431ae"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("369f0617-b105-4152-9420-165bfd9729c9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("e32d536c-652b-4a8e-8b0e-c4016091fbc0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("c7a09edc-8fc3-4e6f-8093-7190bcc338d9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8549), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("5d2c16e7-4f45-485a-a88e-092e3fc9feba"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("7326bdae-4e36-4662-9ce8-3247cd18c9ae"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("e8a83d22-25b0-48f1-b238-e3157b7f39ff"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9102), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("da9ebfea-7ef2-4af2-b4c8-70934e19f1a0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7009), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("e240fbfc-e227-4c4c-bd5d-5e61624998a3"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6760), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("147d566e-55a2-4c05-b3df-8bb87f9f9152"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6735), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("04ee0006-712d-4cf1-b57c-8d8ceab583b7"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("75bdd9e6-c627-4f9c-a439-54eabcf50498"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("df40bb77-7a3d-41dc-b678-6bff85692503"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4371), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("d3f517fb-1669-4051-8d58-0484aefdfd43"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4402), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("681ef95c-bd4f-4874-90c5-eea5b216d7d5"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4752), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("c5b99129-cd66-4a39-bab7-5d4e078f3663"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5059), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("14b99acb-176d-4d85-9ea2-765fb48d3640"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5088), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("be9bee09-8e0b-453d-96df-00b9bd896001"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("2bcb2b55-149c-4eee-a61e-5219ed64f4db"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("4116bb2f-928e-4c73-8771-1d2d22301cd9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("d68ebf9c-b252-4e8a-9bd6-17ba7234fca4"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("a416e58d-7f75-4e27-a7c5-19c2f7d266bb"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("facefb2b-5883-49a7-ae86-3e0477b4ca54"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("bf9dd31f-2790-4fc4-91ae-21dbfc894ad0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("a238f33e-b039-47f6-a5f6-aa7050462918"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("cf3aefdd-3cc3-448e-9495-871d56219151"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("95366bcf-80aa-4944-a9d4-14bcaa157d08"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("8bfb8780-94f8-4eee-a86a-2090e55ec490"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5484), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("dab100cf-98b0-4f4b-aab1-7b2b891a22ee"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_PolicyId",
                table: "PolicyRoles",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_RoleId",
                table: "PolicyRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "PolicyRoles");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Positions_Name",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_Name",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients");

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Information",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ClientCategoryId",
                schema: "Auth",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Services",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2000)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Positions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeesSizeId",
                table: "Companies",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 1L);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Companies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdditionalPhoneNumber",
                table: "Clients",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Bookings",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AuthorizeRoles",
                columns: table => new
                {
                    AuthorizeRoleId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizeRoles", x => x.AuthorizeRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ClientCompanies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorizeRoles",
                columns: new[] { "AuthorizeRoleId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "System Administrator", 0L },
                    { 2L, "Company User", 0L },
                    { 3L, "Plain User", 0L },
                    { 4L, "Limited in actions User", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientCategoryId",
                schema: "Auth",
                table: "Users",
                column: "ClientCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_ClientId",
                table: "ClientCompanies",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCompanies_CompanyId",
                table: "ClientCompanies",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_ClientCategories_ClientCategoryId",
                schema: "Auth",
                table: "Users",
                column: "ClientCategoryId",
                principalTable: "ClientCategories",
                principalColumn: "ClientCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
