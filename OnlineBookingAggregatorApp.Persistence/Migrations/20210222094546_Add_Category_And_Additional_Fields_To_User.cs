using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_Category_And_Additional_Fields_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_BusinessAreas_BusinessAreaId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BusinessAreaId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("08c1c576-ed7a-4440-88f4-65e074bfab3c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0bcd333b-f7eb-4b18-b3d6-e8eb50101aa7"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e0dd476-c60a-4941-985f-75588047c9fc"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("14ea1746-604e-48fc-ac82-7c508107c48c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b45936c-da68-42b0-8d33-27b702651920"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("267691e6-ecbb-4e5e-be91-0417e2391f64"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("26ff0a49-3e88-4b88-bf8e-9e66d40bd1b1"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ce4f2ef-0014-455e-99a8-071d72efd222"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2efd052b-23d8-447f-acfb-c7685ebed742"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("3758948a-c2d2-497f-b6b3-3e9dadf68a25"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("421e9776-6dbf-475d-80e1-b462382af40f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a9e3f3f-6906-4974-94bf-ef6f4ff2cb38"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4b049df6-6a7f-45bb-a8a7-a20c796d397c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("5188e8d2-52c7-4e8e-8696-0e7a7a5d76e5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c3fa96a-a2d5-4798-a9e0-3a3cfc537d23"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e99e122-8ac6-467e-86c2-b20617b5708c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("600eeb5e-4c63-4b9d-9d6a-908804f8131b"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6784c9bf-4f9b-4852-87bf-241b95a6f1c5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6db87c4b-abfa-49cd-90b7-dd27bd03dad4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f22b70f-9a64-4a84-8351-0b4be2cb4afd"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("719318b8-6edc-4a62-b914-3ea8818a8fa0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("720170d7-6b10-449e-902a-ee07e1c0559a"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7754e554-f98c-4bf9-9d11-a03aae17d2d4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("817b7bff-64a2-4fc7-a1ed-4124a2fccbaf"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("89b3698c-d324-4b96-9197-d507efe95736"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("91a2a5ea-0b6a-4ba8-8f23-1aee200b8ec4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a450324d-f94a-4250-a1c7-989d04c46c4c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b230b0ca-1416-423b-ba14-3aa2f589661b"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b32c93b7-4f88-430d-b362-8d566019e8ee"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b358b78f-b399-4d35-ac41-c08704e28c81"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ba0e2bda-475f-4008-9d07-0b494ff21686"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c27f7170-3104-407b-90ef-b03ad88dc0b2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c606eaea-6928-495a-9b6b-799f94897eb0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d23795ec-5e09-43f2-ba46-b6bb552dd8f5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("df84dc72-5b49-44e2-a7f4-bf67578ef9e7"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7785bbf-bbd7-48c4-8971-a89b047ac300"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f30ca7be-ed78-4b77-b49e-dff796a8efb9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5bce1a1-5c0b-4230-af8f-40cc08302acc"));

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BusinessAreaId",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Services",
                newName: "MinPrice");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Services",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CompanyId",
                table: "Services",
                newName: "IX_Services_CategoryId");

            migrationBuilder.AddColumn<long>(
                name: "EmployeeStatusId",
                schema: "Auth",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 1L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FiredAt",
                schema: "Auth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OnHolidayFrom",
                schema: "Auth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "OnHolidayTo",
                schema: "Auth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoPath",
                table: "Services",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxPrice",
                table: "Services",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    EmployeeStatusId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.EmployeeStatusId);
                });

            migrationBuilder.CreateTable(
                name: "TargetGroups",
                columns: table => new
                {
                    ServiceTargetGroupId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetGroups", x => x.ServiceTargetGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BusinessAreaId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceTargetGroupId = table.Column<long>(type: "bigint", nullable: false, defaultValue: 3L),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_BusinessAreas_BusinessAreaId",
                        column: x => x.BusinessAreaId,
                        principalTable: "BusinessAreas",
                        principalColumn: "BusinessAreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_TargetGroups_ServiceTargetGroupId",
                        column: x => x.ServiceTargetGroupId,
                        principalTable: "TargetGroups",
                        principalColumn: "ServiceTargetGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmployeeStatuses",
                columns: new[] { "EmployeeStatusId", "Description", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 4L, "An employee is fired, but not removed from the system.", "person_off", "Fired", 0L },
                    { 3L, "An employee is hidden for some reason.", "person_outline", "Hidden", 0L },
                    { 2L, "An employee is currently on holiday.", "logout", "On Holiday", 0L },
                    { 1L, "An employee is currently active.", "person", "Active", 0L }
                });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("6fc680d9-9390-4d95-ac7c-0f740f2a9bf1"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 633, DateTimeKind.Unspecified).AddTicks(7372), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("7ba76a67-4a10-4c7a-ab8e-0cf1083ae45b"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3399), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("cd56f9e2-2d35-428c-8b25-d3e4890813fb"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3425), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("9c0b85e1-dcbf-4e85-b2b6-9247d0576051"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3711), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("e12d6f30-93fc-48e5-9b97-c7fb7f34f725"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3738), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("fae12d8e-839d-4bf7-b02f-7474c7e9fd32"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("950d4af4-34ad-408c-876b-ce53699d9b51"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4016), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("02ec7750-a3e5-40f7-b5e7-ae31c2a69839"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4043), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("d8772419-4797-4267-a2c8-1e51ed71fd0a"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4360), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("42840bfc-9eb2-4af8-8a9f-39657ff99d47"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3373), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("b334bce9-0259-4455-9fe3-e4525587d3be"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4390), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("936b274b-0114-496d-a326-19793523d37e"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4630), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("b37acf33-399d-42fa-872c-d3d111ef22bf"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4917), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("2108fc8c-4ba0-45ab-9fdc-13cbba89bf8e"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(5159), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("2e90c1a2-e6c9-428b-9967-15bf42bc9579"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(5186), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L },
                    { new Guid("ad83fdbb-6d60-4aa5-a0d9-75a15d8a40db"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(4068), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("30d42d53-4567-47ce-9bad-5a62166fb9cb"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("aa19ca44-bc9f-4ef2-bd7f-07bc137f77a4"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(3094), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("ae7c4d5f-72e8-4d98-ab3d-64b6c4513814"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1259), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("00bd6a45-cbca-472a-88a3-b3e4e50d624c"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(175), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("7c2b1847-1e88-4feb-87a2-82cd9d1449b5"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(523), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("85967994-0136-4f34-b4ff-aad2d36be5db"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(826), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("da40ff6f-5a71-4acc-95dd-a22d3b12b12f"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(853), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("6655948f-45db-4556-a572-e5cf7f3b794e"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(878), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("42a33959-996d-4074-bd6a-ba7428298641"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1228), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("34b12e2d-8627-4347-9b7c-4349148c8752"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2822), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("6386aab7-9a63-48eb-aef1-179e2db7138d"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1536), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("7ee17695-cb71-4a41-80f7-9afd355be516"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("d29af634-0c11-48bb-895a-e4de2c67965d"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1588), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("c00962b7-a2aa-42df-ab25-62ec0bcaf7cf"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1836), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("c68cfd7d-874d-4e52-bb6e-fc2ef536a46a"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(1863), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("d145541b-e97c-42de-b4b4-b5c496b4f62a"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2106), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("db17966f-66d0-4a72-b46b-31a9515a01a2"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2132), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("a44c2133-98f7-4dcb-a10d-81504edf8083"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2523), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("4a0df0db-c489-4353-b05d-c43138b4a3f7"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2550), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("6c76dd56-deec-4a23-80fe-be909b0024f1"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("20b27a9c-9af5-4c70-8e9c-127e50d4cc16"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 634, DateTimeKind.Unspecified).AddTicks(143), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("803e1d53-bd8d-437e-bd65-019e0cd3e0fe"), new DateTimeOffset(new DateTime(2021, 2, 22, 9, 45, 45, 633, DateTimeKind.Unspecified).AddTicks(8995), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L }
                });

            migrationBuilder.InsertData(
                table: "TargetGroups",
                columns: new[] { "ServiceTargetGroupId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2L, "Women's", 0L },
                    { 1L, "Men's", 0L },
                    { 3L, "General", 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeStatusId",
                schema: "Auth",
                table: "Users",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BusinessAreaId",
                table: "Categories",
                column: "BusinessAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CompanyId",
                table: "Categories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ServiceTargetGroupId",
                table: "Categories",
                column: "ServiceTargetGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_EmployeeStatuses_EmployeeStatusId",
                schema: "Auth",
                table: "Users",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatuses",
                principalColumn: "EmployeeStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_EmployeeStatuses_EmployeeStatusId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");

            migrationBuilder.DropTable(
                name: "TargetGroups");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeeStatusId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("00bd6a45-cbca-472a-88a3-b3e4e50d624c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("02ec7750-a3e5-40f7-b5e7-ae31c2a69839"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("20b27a9c-9af5-4c70-8e9c-127e50d4cc16"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2108fc8c-4ba0-45ab-9fdc-13cbba89bf8e"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e90c1a2-e6c9-428b-9967-15bf42bc9579"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("30d42d53-4567-47ce-9bad-5a62166fb9cb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("34b12e2d-8627-4347-9b7c-4349148c8752"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("42840bfc-9eb2-4af8-8a9f-39657ff99d47"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("42a33959-996d-4074-bd6a-ba7428298641"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a0df0db-c489-4353-b05d-c43138b4a3f7"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6386aab7-9a63-48eb-aef1-179e2db7138d"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6655948f-45db-4556-a572-e5cf7f3b794e"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c76dd56-deec-4a23-80fe-be909b0024f1"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fc680d9-9390-4d95-ac7c-0f740f2a9bf1"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ba76a67-4a10-4c7a-ab8e-0cf1083ae45b"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c2b1847-1e88-4feb-87a2-82cd9d1449b5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ee17695-cb71-4a41-80f7-9afd355be516"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("803e1d53-bd8d-437e-bd65-019e0cd3e0fe"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("85967994-0136-4f34-b4ff-aad2d36be5db"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("936b274b-0114-496d-a326-19793523d37e"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("950d4af4-34ad-408c-876b-ce53699d9b51"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("9c0b85e1-dcbf-4e85-b2b6-9247d0576051"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a44c2133-98f7-4dcb-a10d-81504edf8083"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa19ca44-bc9f-4ef2-bd7f-07bc137f77a4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ad83fdbb-6d60-4aa5-a0d9-75a15d8a40db"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae7c4d5f-72e8-4d98-ab3d-64b6c4513814"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b334bce9-0259-4455-9fe3-e4525587d3be"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b37acf33-399d-42fa-872c-d3d111ef22bf"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c00962b7-a2aa-42df-ab25-62ec0bcaf7cf"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c68cfd7d-874d-4e52-bb6e-fc2ef536a46a"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd56f9e2-2d35-428c-8b25-d3e4890813fb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d145541b-e97c-42de-b4b4-b5c496b4f62a"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d29af634-0c11-48bb-895a-e4de2c67965d"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8772419-4797-4267-a2c8-1e51ed71fd0a"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("da40ff6f-5a71-4acc-95dd-a22d3b12b12f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("db17966f-66d0-4a72-b46b-31a9515a01a2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e12d6f30-93fc-48e5-9b97-c7fb7f34f725"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("fae12d8e-839d-4bf7-b02f-7474c7e9fd32"));

            migrationBuilder.DropColumn(
                name: "EmployeeStatusId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FiredAt",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OnHolidayFrom",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "OnHolidayTo",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LogoPath",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "MinPrice",
                table: "Services",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Services",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CategoryId",
                table: "Services",
                newName: "IX_Services_CompanyId");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "Auth",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "BusinessAreaId",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("08c1c576-ed7a-4440-88f4-65e074bfab3c"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(2466), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("5c3fa96a-a2d5-4798-a9e0-3a3cfc537d23"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("6784c9bf-4f9b-4852-87bf-241b95a6f1c5"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8606), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("7754e554-f98c-4bf9-9d11-a03aae17d2d4"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8929), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("ba0e2bda-475f-4008-9d07-0b494ff21686"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8957), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("c606eaea-6928-495a-9b6b-799f94897eb0"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("b230b0ca-1416-423b-ba14-3aa2f589661b"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9225), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("2efd052b-23d8-447f-acfb-c7685ebed742"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9253), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("267691e6-ecbb-4e5e-be91-0417e2391f64"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9278), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("720170d7-6b10-449e-902a-ee07e1c0559a"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9524), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("d23795ec-5e09-43f2-ba46-b6bb552dd8f5"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9551), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("89b3698c-d324-4b96-9197-d507efe95736"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9577), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("26ff0a49-3e88-4b88-bf8e-9e66d40bd1b1"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9863), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("a450324d-f94a-4250-a1c7-989d04c46c4c"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(9931), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("5188e8d2-52c7-4e8e-8696-0e7a7a5d76e5"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 405, DateTimeKind.Unspecified).AddTicks(177), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("f30ca7be-ed78-4b77-b49e-dff796a8efb9"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 405, DateTimeKind.Unspecified).AddTicks(421), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("f5bce1a1-5c0b-4230-af8f-40cc08302acc"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8334), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("b358b78f-b399-4d35-ac41-c08704e28c81"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8090), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("b32c93b7-4f88-430d-b362-8d566019e8ee"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8064), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("817b7bff-64a2-4fc7-a1ed-4124a2fccbaf"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(8036), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("df84dc72-5b49-44e2-a7f4-bf67578ef9e7"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(4022), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("6db87c4b-abfa-49cd-90b7-dd27bd03dad4"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(5633), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("2ce4f2ef-0014-455e-99a8-071d72efd222"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(5665), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("14ea1746-604e-48fc-ac82-7c508107c48c"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6026), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("600eeb5e-4c63-4b9d-9d6a-908804f8131b"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6475), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("91a2a5ea-0b6a-4ba8-8f23-1aee200b8ec4"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6503), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("4a9e3f3f-6906-4974-94bf-ef6f4ff2cb38"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6530), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("5e99e122-8ac6-467e-86c2-b20617b5708c"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 405, DateTimeKind.Unspecified).AddTicks(660), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("421e9776-6dbf-475d-80e1-b462382af40f"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6796), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("c27f7170-3104-407b-90ef-b03ad88dc0b2"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7095), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("1b45936c-da68-42b0-8d33-27b702651920"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7123), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("719318b8-6edc-4a62-b914-3ea8818a8fa0"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7149), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("0bcd333b-f7eb-4b18-b3d6-e8eb50101aa7"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7397), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("3758948a-c2d2-497f-b6b3-3e9dadf68a25"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7425), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("6f22b70f-9a64-4a84-8351-0b4be2cb4afd"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7669), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("e7785bbf-bbd7-48c4-8971-a89b047ac300"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(7697), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("0e0dd476-c60a-4941-985f-75588047c9fc"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 404, DateTimeKind.Unspecified).AddTicks(6826), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("4b049df6-6a7f-45bb-a8a7-a20c796d397c"), new DateTimeOffset(new DateTime(2021, 2, 21, 19, 45, 54, 405, DateTimeKind.Unspecified).AddTicks(687), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessAreaId",
                table: "Services",
                column: "BusinessAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_BusinessAreas_BusinessAreaId",
                table: "Services",
                column: "BusinessAreaId",
                principalTable: "BusinessAreas",
                principalColumn: "BusinessAreaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Companies_CompanyId",
                table: "Services",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
