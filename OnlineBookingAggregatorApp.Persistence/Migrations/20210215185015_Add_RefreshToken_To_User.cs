using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_RefreshToken_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("01e40260-dd03-4d15-9372-a759fc9e2119"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("14c73624-7f45-47cf-98a2-88bed8f54fb2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("1610d975-7ed8-46ec-ae80-bfeda013bf1b"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("239249fa-0924-4829-ad8f-0080dacf9c4f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("23e355ab-f4db-4526-b7f2-19f63ce0e80c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("253f7351-696c-476d-91a5-0d3f4b3621ef"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2595ff9f-912e-4d94-bf83-5309509499cf"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2604979c-04fc-43bf-a357-f4540c1e8377"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("265b53a2-6b55-43a3-8e52-3eee801fbe09"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("347cf7c4-f4dd-459a-b0cb-3550f31d82e8"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("50062fa0-bbc7-439e-9efc-29012bd67c06"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("50774a68-1182-465e-b36b-05432cbe3c91"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("53e2cd98-9f20-409f-8bdb-74c30c25bdc4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("57628abc-8b1e-431c-b832-7a0fdec7ee90"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("579bb1ef-2140-42b8-a62c-238158e78fae"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("5e717a2a-4275-4ada-9cc5-978056f709c0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("659fef52-2ccd-4955-ae54-cde6ed411bc2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("777bd12c-e7f5-4ea2-99c4-00ced7f6131c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a600843-2ec9-4755-8fbe-265298f59051"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("8501cc91-865b-41ed-8c9c-65d409eeef63"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("88307c68-1dea-4e5a-9f26-1d88af46f1ca"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d3b61cb-cc0e-4529-854f-260e5016a6fa"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ee98176-54d7-4228-bfcf-73968e884aaa"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a156b3a9-923d-45ba-abb3-42ded88500e3"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac19acb6-a3bc-42ac-81d3-448581c50edb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3fc9684-4bc8-43da-85b8-b7c4eaee63d3"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b768c330-5d05-4107-a746-1b78ab6b9542"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("bba9a24f-827d-411f-8ac0-8feb54edf4f5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c41abd0a-b863-4bc6-a198-d96f6581951c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c8f386e6-8c23-4808-8bc5-911561007f68"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3ce623d-125b-4f43-8826-63fbd1c1fc09"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d486f14d-c604-48a0-8095-a67e8f57290f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d85d3d8a-be7a-4a7b-a451-b33e0a43dfe2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e4602b95-331a-4258-9375-880d677011b9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e4d3a064-67be-41d4-a5c2-63ade83d12e9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f13319d3-6bed-44cf-b29c-293cd52a28f5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("fbd87b3f-5202-4ec8-8af8-56a14a64fab8"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffcf7dc3-19cb-48d3-b1d9-52db52f107d7"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "Auth",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("87adbb11-553a-4861-b173-39721307d0c5"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(3601), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("4d429585-05da-4d0c-8450-7c2754cf320d"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(75), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("ea2202f4-2b09-4c26-9bc0-3e21dda76d88"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(102), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("17bf8e6b-0524-4ccf-853e-ffb94e5cbc56"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(442), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("d739a49d-0a27-45c8-8762-1ea5b38ce313"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(469), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("b74f6dd6-f2b8-4228-a0a7-2298a5fa1c1c"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(496), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("87524c63-0936-43f6-a3aa-873fd2090584"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(748), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("05205b3a-6bf2-43fa-9fdf-291129e9ec98"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(774), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("b2572fe6-9441-4585-8b81-e9b9b67370b3"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(804), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("267b8ffd-7ce2-4227-b244-4e93208ae11d"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1067), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("61a45bb2-44fe-461f-8db9-694555a0e12f"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1094), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("bb98593d-719d-40bf-8ba8-fe0206efb601"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1120), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("932feb96-cd36-4a48-bf7a-a59519c7757c"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1469), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("d1c9842d-657e-494c-8b44-8d5c214db716"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1499), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("d57bfff5-f5b8-4913-b9eb-98d0763e0ff7"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(1757), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("f0a32824-7117-464b-bdf3-84d43f2514cc"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(2006), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("18fdfec1-c14b-410f-ac4f-9f9745272d58"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9819), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("a38f9bad-3ad5-436f-9435-5318aab59be6"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9561), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("34f29b3a-4caa-42a6-8163-b9857d479137"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9535), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("91d4b5fb-c8a5-4bc4-8b19-f7f90799386d"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9508), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("91b02670-0dd8-41e1-8471-0d847f0960c5"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(5229), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("ba908876-e3e5-42b8-ace3-f5cf6353b40e"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(6598), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("7af0b14e-eaa8-444b-b428-0d6bb772eada"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(6629), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("f7c99fea-ba70-4db0-b33c-33ca92bb913c"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7159), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("0e3deda5-1ee5-4cb5-b3cf-72ba3061bdcc"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7572), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("560f7ac9-51af-4e42-9140-f87a4e359b23"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7600), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("055f7727-98fe-421f-be0e-64c988185492"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7625), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("7716d6af-7f10-419f-8ac4-f1e52a834ba1"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(2252), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("d21c9bf1-edd1-4995-8a27-8b0fb988efc8"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7899), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("744b9243-437f-4431-8eef-0a48d0dfc865"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(8287), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("47523c8c-4fa5-436d-9d19-7a2fc85c8500"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(8320), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("6ad8ac24-0887-4988-8ea4-9ab5dd5b3296"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(8351), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("93d29a88-66ed-46ab-86b0-f55f78bb7f42"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(8677), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("0c73517c-56ef-4d44-9bfa-949374da0cfc"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(8704), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("6e518beb-592f-4418-b00c-ee84622edfbb"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9173), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("d81ca517-cf16-4995-b09f-ea9e7fc07656"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(9201), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("0ff6d243-044e-4247-99df-d4958eed88b6"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 105, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("05ab034a-bfb4-45e7-b53c-77784f5deb83"), new DateTimeOffset(new DateTime(2021, 2, 15, 18, 50, 14, 106, DateTimeKind.Unspecified).AddTicks(2279), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("05205b3a-6bf2-43fa-9fdf-291129e9ec98"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("055f7727-98fe-421f-be0e-64c988185492"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("05ab034a-bfb4-45e7-b53c-77784f5deb83"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c73517c-56ef-4d44-9bfa-949374da0cfc"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e3deda5-1ee5-4cb5-b3cf-72ba3061bdcc"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0ff6d243-044e-4247-99df-d4958eed88b6"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("17bf8e6b-0524-4ccf-853e-ffb94e5cbc56"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("18fdfec1-c14b-410f-ac4f-9f9745272d58"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("267b8ffd-7ce2-4227-b244-4e93208ae11d"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("34f29b3a-4caa-42a6-8163-b9857d479137"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("47523c8c-4fa5-436d-9d19-7a2fc85c8500"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d429585-05da-4d0c-8450-7c2754cf320d"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("560f7ac9-51af-4e42-9140-f87a4e359b23"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("61a45bb2-44fe-461f-8db9-694555a0e12f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6ad8ac24-0887-4988-8ea4-9ab5dd5b3296"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6e518beb-592f-4418-b00c-ee84622edfbb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("744b9243-437f-4431-8eef-0a48d0dfc865"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7716d6af-7f10-419f-8ac4-f1e52a834ba1"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7af0b14e-eaa8-444b-b428-0d6bb772eada"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("87524c63-0936-43f6-a3aa-873fd2090584"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("87adbb11-553a-4861-b173-39721307d0c5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("91b02670-0dd8-41e1-8471-0d847f0960c5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("91d4b5fb-c8a5-4bc4-8b19-f7f90799386d"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("932feb96-cd36-4a48-bf7a-a59519c7757c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("93d29a88-66ed-46ab-86b0-f55f78bb7f42"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a38f9bad-3ad5-436f-9435-5318aab59be6"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2572fe6-9441-4585-8b81-e9b9b67370b3"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b74f6dd6-f2b8-4228-a0a7-2298a5fa1c1c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ba908876-e3e5-42b8-ace3-f5cf6353b40e"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb98593d-719d-40bf-8ba8-fe0206efb601"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1c9842d-657e-494c-8b44-8d5c214db716"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d21c9bf1-edd1-4995-8a27-8b0fb988efc8"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d57bfff5-f5b8-4913-b9eb-98d0763e0ff7"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d739a49d-0a27-45c8-8762-1ea5b38ce313"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d81ca517-cf16-4995-b09f-ea9e7fc07656"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ea2202f4-2b09-4c26-9bc0-3e21dda76d88"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a32824-7117-464b-bdf3-84d43f2514cc"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f7c99fea-ba70-4db0-b33c-33ca92bb913c"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "Auth",
                table: "Users");

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("50062fa0-bbc7-439e-9efc-29012bd67c06"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 721, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("a156b3a9-923d-45ba-abb3-42ded88500e3"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7109), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("659fef52-2ccd-4955-ae54-cde6ed411bc2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("b768c330-5d05-4107-a746-1b78ab6b9542"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("50774a68-1182-465e-b36b-05432cbe3c91"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7499), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("8d3b61cb-cc0e-4529-854f-260e5016a6fa"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("53e2cd98-9f20-409f-8bdb-74c30c25bdc4"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("2604979c-04fc-43bf-a357-f4540c1e8377"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7797), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("14c73624-7f45-47cf-98a2-88bed8f54fb2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7823), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("fbd87b3f-5202-4ec8-8af8-56a14a64fab8"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("8501cc91-865b-41ed-8c9c-65d409eeef63"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("57628abc-8b1e-431c-b832-7a0fdec7ee90"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("265b53a2-6b55-43a3-8e52-3eee801fbe09"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("01e40260-dd03-4d15-9372-a759fc9e2119"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8516), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("579bb1ef-2140-42b8-a62c-238158e78fae"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("c8f386e6-8c23-4808-8bc5-911561007f68"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("239249fa-0924-4829-ad8f-0080dacf9c4f"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6863), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("1610d975-7ed8-46ec-ae80-bfeda013bf1b"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("c41abd0a-b863-4bc6-a198-d96f6581951c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6590), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("b3fc9684-4bc8-43da-85b8-b7c4eaee63d3"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("e4602b95-331a-4258-9375-880d677011b9"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(281), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("253f7351-696c-476d-91a5-0d3f4b3621ef"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("f13319d3-6bed-44cf-b29c-293cd52a28f5"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("bba9a24f-827d-411f-8ac0-8feb54edf4f5"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("ac19acb6-a3bc-42ac-81d3-448581c50edb"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("777bd12c-e7f5-4ea2-99c4-00ced7f6131c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("d3ce623d-125b-4f43-8826-63fbd1c1fc09"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("88307c68-1dea-4e5a-9f26-1d88af46f1ca"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9441), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("d486f14d-c604-48a0-8095-a67e8f57290f"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4725), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("d85d3d8a-be7a-4a7b-a451-b33e0a43dfe2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("e4d3a064-67be-41d4-a5c2-63ade83d12e9"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("347cf7c4-f4dd-459a-b0cb-3550f31d82e8"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5336), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("2595ff9f-912e-4d94-bf83-5309509499cf"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("23e355ab-f4db-4526-b7f2-19f63ce0e80c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("7a600843-2ec9-4755-8fbe-265298f59051"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6199), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("5e717a2a-4275-4ada-9cc5-978056f709c0"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("ffcf7dc3-19cb-48d3-b1d9-52db52f107d7"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("8ee98176-54d7-4228-bfcf-73968e884aaa"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9472), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L }
                });
        }
    }
}
