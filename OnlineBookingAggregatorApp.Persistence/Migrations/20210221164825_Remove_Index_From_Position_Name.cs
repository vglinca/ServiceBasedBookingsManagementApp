using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Remove_Index_From_Position_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Positions_Name",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_Name",
                table: "Positions");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("25811fe8-09e9-448b-84aa-525e2f87b855"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(5172), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("9264b992-ae58-4929-8432-472ef651b608"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1148), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("273122fb-6b12-40dd-9958-26ee2e8345e0"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1175), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("aa2871af-9050-4b67-b243-52a774368584"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1506), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("539f5bdf-21e5-48a9-aa7f-5464fec5a438"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1534), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("4c4ce230-d42a-4ce0-8929-885c11a43c5c"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1562), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("8e251c35-ad9d-4314-8d35-53125edd7cdf"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("2dfed48d-ccc2-4349-9b46-1c4f33108e86"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("ffbb5436-8275-495b-8460-8a0cdb7ebe6a"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("b3eac3ce-2001-43f4-b4d9-afa18d545e2a"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2123), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("4dda3fcc-d1ac-47b4-ac54-4e1755e42a79"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2150), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("973de4f6-775c-4146-acac-a23fddf8137e"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2176), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L },
                    { new Guid("f2bd7aed-87d8-4bd9-a196-7a6fa1c7e300"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2469), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("d1386472-9129-4832-b6ea-4d2800f84b99"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2499), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("98f9b4c7-8fa7-4364-a0ed-059d6b60f733"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(2800), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("196b17e4-4366-43f3-8a21-1edeb6035b0b"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(3047), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("bb3142aa-f197-4cbd-84e8-07d4ad149834"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(894), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("6c22de85-95cb-4289-a96c-9261b2be26ae"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(641), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("7c73e726-5065-42ff-84cf-514626ae66ae"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(614), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("0d5ec643-7e81-4113-878e-0ed22e39f073"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("b1d7fc37-aa1c-4324-8849-cc92676bdf92"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(6663), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("243ef69f-54e2-4129-a7e9-e12e8a595bf4"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(8103), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("e21d5053-643e-49f4-8bcd-86ae918d4590"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(8135), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("c1274f69-8c1a-4a96-bae6-a76f458be4da"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(8498), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("300b75cf-4ae2-4c3f-befb-a4f22d79ab40"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(8976), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("ef07943d-9faa-4ed3-b658-87e02078ce0c"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9006), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("cf900e09-9dcb-40a2-9283-24eaa5b2ccf4"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9032), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("f57fc481-5212-4c1b-b7a5-c6fd4741e1ea"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(3286), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("69f7cb60-019e-4136-9d2f-9e8090baee44"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9299), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("1e1d3490-0f4b-4c1e-a903-8ee9dad9281c"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9606), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("3ad5f9d8-81cc-482f-8b8f-18d0cdc98298"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9638), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("0769a4d1-4bab-45c3-a343-b9ea9ad29049"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9664), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("c3b139e1-0d84-4d52-b0d0-e4b9084d41cb"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9919), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("57161a92-2a40-436e-b65c-e752334dc62f"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9946), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("fc14fdfa-d7d7-45f4-aaed-29943d060476"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(198), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("479628d9-df14-4830-8090-0c12c26866c2"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("7d686dbd-412c-4b07-8189-c02a973cdeb0"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 105, DateTimeKind.Unspecified).AddTicks(9330), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("e21b69d8-1b2c-49ac-93ed-9c27b73f4692"), new DateTimeOffset(new DateTime(2021, 2, 21, 16, 48, 24, 106, DateTimeKind.Unspecified).AddTicks(3313), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0769a4d1-4bab-45c3-a343-b9ea9ad29049"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d5ec643-7e81-4113-878e-0ed22e39f073"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("196b17e4-4366-43f3-8a21-1edeb6035b0b"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("1e1d3490-0f4b-4c1e-a903-8ee9dad9281c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("243ef69f-54e2-4129-a7e9-e12e8a595bf4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("25811fe8-09e9-448b-84aa-525e2f87b855"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("273122fb-6b12-40dd-9958-26ee2e8345e0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2dfed48d-ccc2-4349-9b46-1c4f33108e86"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("300b75cf-4ae2-4c3f-befb-a4f22d79ab40"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("3ad5f9d8-81cc-482f-8b8f-18d0cdc98298"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("479628d9-df14-4830-8090-0c12c26866c2"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4c4ce230-d42a-4ce0-8929-885c11a43c5c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4dda3fcc-d1ac-47b4-ac54-4e1755e42a79"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("539f5bdf-21e5-48a9-aa7f-5464fec5a438"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("57161a92-2a40-436e-b65c-e752334dc62f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("69f7cb60-019e-4136-9d2f-9e8090baee44"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6c22de85-95cb-4289-a96c-9261b2be26ae"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c73e726-5065-42ff-84cf-514626ae66ae"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7d686dbd-412c-4b07-8189-c02a973cdeb0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e251c35-ad9d-4314-8d35-53125edd7cdf"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("9264b992-ae58-4929-8432-472ef651b608"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("973de4f6-775c-4146-acac-a23fddf8137e"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("98f9b4c7-8fa7-4364-a0ed-059d6b60f733"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa2871af-9050-4b67-b243-52a774368584"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b1d7fc37-aa1c-4324-8849-cc92676bdf92"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3eac3ce-2001-43f4-b4d9-afa18d545e2a"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb3142aa-f197-4cbd-84e8-07d4ad149834"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1274f69-8c1a-4a96-bae6-a76f458be4da"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3b139e1-0d84-4d52-b0d0-e4b9084d41cb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf900e09-9dcb-40a2-9283-24eaa5b2ccf4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1386472-9129-4832-b6ea-4d2800f84b99"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e21b69d8-1b2c-49ac-93ed-9c27b73f4692"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e21d5053-643e-49f4-8bcd-86ae918d4590"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef07943d-9faa-4ed3-b658-87e02078ce0c"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2bd7aed-87d8-4bd9-a196-7a6fa1c7e300"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("f57fc481-5212-4c1b-b7a5-c6fd4741e1ea"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc14fdfa-d7d7-45f4-aaed-29943d060476"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffbb5436-8275-495b-8460-8a0cdb7ebe6a"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Positions_Name",
                table: "Positions",
                column: "Name");

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

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Name",
                table: "Positions",
                column: "Name",
                unique: true);
        }
    }
}
