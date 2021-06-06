using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_CustomeRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_Roles_RoleId",
                table: "PolicyRoles");

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("04ee0006-712d-4cf1-b57c-8d8ceab583b7"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("09cbc571-8f8d-4554-ad8e-9ad706d287c8"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a83f98b-d947-451b-8167-6ac2ef47cecc"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("147d566e-55a2-4c05-b3df-8bb87f9f9152"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("14b99acb-176d-4d85-9ea2-765fb48d3640"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2683d2c7-90c8-421d-843b-43ecb6cd1656"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("2bcb2b55-149c-4eee-a61e-5219ed64f4db"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("31ce432a-2527-4119-9bd4-5000d34bfffd"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("369f0617-b105-4152-9420-165bfd9729c9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("4116bb2f-928e-4c73-8771-1d2d22301cd9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("576aa95d-0af6-40da-8c93-18d4647431ae"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d2c16e7-4f45-485a-a88e-092e3fc9feba"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("681ef95c-bd4f-4874-90c5-eea5b216d7d5"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a5ad867-661f-46b7-89d4-a37081be0c53"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("7326bdae-4e36-4662-9ce8-3247cd18c9ae"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("75bdd9e6-c627-4f9c-a439-54eabcf50498"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("8bfb8780-94f8-4eee-a86a-2090e55ec490"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("95366bcf-80aa-4944-a9d4-14bcaa157d08"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a238f33e-b039-47f6-a5f6-aa7050462918"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a027f2-9144-441e-b4cf-0ba0544c90f0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("a416e58d-7f75-4e27-a7c5-19c2f7d266bb"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("be9bee09-8e0b-453d-96df-00b9bd896001"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf9dd31f-2790-4fc4-91ae-21dbfc894ad0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5b99129-cd66-4a39-bab7-5d4e078f3663"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7a09edc-8fc3-4e6f-8093-7190bcc338d9"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf3aefdd-3cc3-448e-9495-871d56219151"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d190356a-c161-4984-b823-c047e13ac188"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f517fb-1669-4051-8d58-0484aefdfd43"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d45c4f51-2203-44fe-8c12-0664242a491f"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("d68ebf9c-b252-4e8a-9bd6-17ba7234fca4"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("da9ebfea-7ef2-4af2-b4c8-70934e19f1a0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("dab100cf-98b0-4f4b-aab1-7b2b891a22ee"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("df40bb77-7a3d-41dc-b678-6bff85692503"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e240fbfc-e227-4c4c-bd5d-5e61624998a3"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e32d536c-652b-4a8e-8b0e-c4016091fbc0"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8a83d22-25b0-48f1-b238-e3157b7f39ff"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("facefb2b-5883-49a7-ae86-3e0477b4ca54"));

            migrationBuilder.DeleteData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe88cbd4-7816-4ce7-b093-5f78076373e6"));

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

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "PolicyRoles",
                newName: "SystemRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyRoles_RoleId",
                table: "PolicyRoles",
                newName: "IX_PolicyRoles_SystemRoleId");

            migrationBuilder.AddColumn<long>(
                name: "SystemRoleId",
                schema: "Auth",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    SystemRoleId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ParentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.SystemRoleId);
                });

            migrationBuilder.InsertData(
                table: "SystemRoles",
                columns: new[] { "SystemRoleId", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1L, "CompanyAdmin", 0L },
                    { 2L, "CompanyAdminDeputy", 0L },
                    { 3L, "Specialist", 0L }
                });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "SystemRoleId" },
                values: new object[,]
                {
                    { new Guid("50062fa0-bbc7-439e-9efc-29012bd67c06"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 721, DateTimeKind.Unspecified).AddTicks(8421), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("ffcf7dc3-19cb-48d3-b1d9-52db52f107d7"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4757), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("e4d3a064-67be-41d4-a5c2-63ade83d12e9"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5304), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("23e355ab-f4db-4526-b7f2-19f63ce0e80c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("5e717a2a-4275-4ada-9cc5-978056f709c0"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6233), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("c41abd0a-b863-4bc6-a198-d96f6581951c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6590), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("659fef52-2ccd-4955-ae54-cde6ed411bc2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7136), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("50774a68-1182-465e-b36b-05432cbe3c91"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7499), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("2604979c-04fc-43bf-a357-f4540c1e8377"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7797), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("8501cc91-865b-41ed-8c9c-65d409eeef63"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8095), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("01e40260-dd03-4d15-9372-a759fc9e2119"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8516), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("8ee98176-54d7-4228-bfcf-73968e884aaa"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9472), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L },
                    { new Guid("777bd12c-e7f5-4ea2-99c4-00ced7f6131c"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4423), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("347cf7c4-f4dd-459a-b0cb-3550f31d82e8"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5336), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("1610d975-7ed8-46ec-ae80-bfeda013bf1b"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6616), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("8d3b61cb-cc0e-4529-854f-260e5016a6fa"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7525), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("d3ce623d-125b-4f43-8826-63fbd1c1fc09"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4450), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("f13319d3-6bed-44cf-b29c-293cd52a28f5"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(1758), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("e4602b95-331a-4258-9375-880d677011b9"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(281), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("88307c68-1dea-4e5a-9f26-1d88af46f1ca"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9441), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("253f7351-696c-476d-91a5-0d3f4b3621ef"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(1725), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("bba9a24f-827d-411f-8ac0-8feb54edf4f5"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(3920), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("ac19acb6-a3bc-42ac-81d3-448581c50edb"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4393), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("d486f14d-c604-48a0-8095-a67e8f57290f"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(4725), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("d85d3d8a-be7a-4a7b-a451-b33e0a43dfe2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5270), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("2595ff9f-912e-4d94-bf83-5309509499cf"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(5771), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("7a600843-2ec9-4755-8fbe-265298f59051"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6199), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("14c73624-7f45-47cf-98a2-88bed8f54fb2"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7823), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("b3fc9684-4bc8-43da-85b8-b7c4eaee63d3"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6562), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("a156b3a9-923d-45ba-abb3-42ded88500e3"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7109), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("b768c330-5d05-4107-a746-1b78ab6b9542"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7472), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("53e2cd98-9f20-409f-8bdb-74c30c25bdc4"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(7769), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("fbd87b3f-5202-4ec8-8af8-56a14a64fab8"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8067), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("265b53a2-6b55-43a3-8e52-3eee801fbe09"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8485), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("579bb1ef-2140-42b8-a62c-238158e78fae"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8758), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("c8f386e6-8c23-4808-8bc5-911561007f68"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(9000), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("239249fa-0924-4829-ad8f-0080dacf9c4f"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(6863), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("57628abc-8b1e-431c-b832-7a0fdec7ee90"), new DateTimeOffset(new DateTime(2021, 2, 14, 19, 11, 55, 722, DateTimeKind.Unspecified).AddTicks(8121), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SystemRoleId",
                schema: "Auth",
                table: "Users",
                column: "SystemRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_SystemRoles_SystemRoleId",
                table: "PolicyRoles",
                column: "SystemRoleId",
                principalTable: "SystemRoles",
                principalColumn: "SystemRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SystemRoles_SystemRoleId",
                schema: "Auth",
                table: "Users",
                column: "SystemRoleId",
                principalTable: "SystemRoles",
                principalColumn: "SystemRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyRoles_SystemRoles_SystemRoleId",
                table: "PolicyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SystemRoles_SystemRoleId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropIndex(
                name: "IX_Users_SystemRoleId",
                schema: "Auth",
                table: "Users");

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

            migrationBuilder.DropColumn(
                name: "SystemRoleId",
                schema: "Auth",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SystemRoleId",
                table: "PolicyRoles",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_PolicyRoles_SystemRoleId",
                table: "PolicyRoles",
                newName: "IX_PolicyRoles_RoleId");

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1L, "ad93aebb-c404-4bf3-b3e6-b46c856c5aa5", "CompanyAdmin", null },
                    { 2L, "a489f96f-04aa-47eb-be18-8b3112cc3902", "CompanyAdminDeputy", null },
                    { 3L, "57d1e893-49e5-4df9-9f1d-6eeabc06ef72", "Specialist", null }
                });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "PolicyId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("fe88cbd4-7816-4ce7-b093-5f78076373e6"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(1248), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 1L },
                    { new Guid("8bfb8780-94f8-4eee-a86a-2090e55ec490"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5484), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 2L },
                    { new Guid("a416e58d-7f75-4e27-a7c5-19c2f7d266bb"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5798), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 2L },
                    { new Guid("a238f33e-b039-47f6-a5f6-aa7050462918"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6100), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 2L },
                    { new Guid("95366bcf-80aa-4944-a9d4-14bcaa157d08"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6372), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 2L },
                    { new Guid("147d566e-55a2-4c05-b3df-8bb87f9f9152"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6735), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 2L },
                    { new Guid("0a83f98b-d947-451b-8167-6ac2ef47cecc"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7281), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 2L },
                    { new Guid("d45c4f51-2203-44fe-8c12-0664242a491f"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7585), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 2L },
                    { new Guid("09cbc571-8f8d-4554-ad8e-9ad706d287c8"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7879), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 2L },
                    { new Guid("369f0617-b105-4152-9420-165bfd9729c9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8228), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 2L },
                    { new Guid("5d2c16e7-4f45-485a-a88e-092e3fc9feba"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 2L },
                    { new Guid("dab100cf-98b0-4f4b-aab1-7b2b891a22ee"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9378), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 2L },
                    { new Guid("14b99acb-176d-4d85-9ea2-765fb48d3640"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5088), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 3L },
                    { new Guid("facefb2b-5883-49a7-ae86-3e0477b4ca54"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5824), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 3L },
                    { new Guid("e240fbfc-e227-4c4c-bd5d-5e61624998a3"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6760), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 3L },
                    { new Guid("2683d2c7-90c8-421d-843b-43ecb6cd1656"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7611), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 3L },
                    { new Guid("be9bee09-8e0b-453d-96df-00b9bd896001"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5114), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 2L },
                    { new Guid("d3f517fb-1669-4051-8d58-0484aefdfd43"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4402), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 2L },
                    { new Guid("75bdd9e6-c627-4f9c-a439-54eabcf50498"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(3246), new TimeSpan(0, 0, 0, 0, 0)), 0L, 1L, 2L },
                    { new Guid("2bcb2b55-149c-4eee-a61e-5219ed64f4db"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9351), new TimeSpan(0, 0, 0, 0, 0)), 0L, 18L, 1L },
                    { new Guid("df40bb77-7a3d-41dc-b678-6bff85692503"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4371), new TimeSpan(0, 0, 0, 0, 0)), 0L, 2L, 1L },
                    { new Guid("681ef95c-bd4f-4874-90c5-eea5b216d7d5"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(4752), new TimeSpan(0, 0, 0, 0, 0)), 0L, 3L, 1L },
                    { new Guid("c5b99129-cd66-4a39-bab7-5d4e078f3663"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5059), new TimeSpan(0, 0, 0, 0, 0)), 0L, 4L, 1L },
                    { new Guid("4116bb2f-928e-4c73-8771-1d2d22301cd9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5374), new TimeSpan(0, 0, 0, 0, 0)), 0L, 5L, 1L },
                    { new Guid("d68ebf9c-b252-4e8a-9bd6-17ba7234fca4"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(5770), new TimeSpan(0, 0, 0, 0, 0)), 0L, 6L, 1L },
                    { new Guid("bf9dd31f-2790-4fc4-91ae-21dbfc894ad0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 0, 0, 0, 0)), 0L, 7L, 1L },
                    { new Guid("cf3aefdd-3cc3-448e-9495-871d56219151"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6344), new TimeSpan(0, 0, 0, 0, 0)), 0L, 8L, 1L },
                    { new Guid("a2a027f2-9144-441e-b4cf-0ba0544c90f0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7905), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 3L },
                    { new Guid("04ee0006-712d-4cf1-b57c-8d8ceab583b7"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(6706), new TimeSpan(0, 0, 0, 0, 0)), 0L, 9L, 1L },
                    { new Guid("31ce432a-2527-4119-9bd4-5000d34bfffd"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7253), new TimeSpan(0, 0, 0, 0, 0)), 0L, 11L, 1L },
                    { new Guid("6a5ad867-661f-46b7-89d4-a37081be0c53"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7557), new TimeSpan(0, 0, 0, 0, 0)), 0L, 12L, 1L },
                    { new Guid("d190356a-c161-4984-b823-c047e13ac188"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7852), new TimeSpan(0, 0, 0, 0, 0)), 0L, 13L, 1L },
                    { new Guid("576aa95d-0af6-40da-8c93-18d4647431ae"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 1L },
                    { new Guid("c7a09edc-8fc3-4e6f-8093-7190bcc338d9"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8549), new TimeSpan(0, 0, 0, 0, 0)), 0L, 15L, 1L },
                    { new Guid("7326bdae-4e36-4662-9ce8-3247cd18c9ae"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8819), new TimeSpan(0, 0, 0, 0, 0)), 0L, 16L, 1L },
                    { new Guid("e8a83d22-25b0-48f1-b238-e3157b7f39ff"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(9102), new TimeSpan(0, 0, 0, 0, 0)), 0L, 17L, 1L },
                    { new Guid("da9ebfea-7ef2-4af2-b4c8-70934e19f1a0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(7009), new TimeSpan(0, 0, 0, 0, 0)), 0L, 10L, 1L },
                    { new Guid("e32d536c-652b-4a8e-8b0e-c4016091fbc0"), new DateTimeOffset(new DateTime(2021, 2, 14, 14, 57, 2, 694, DateTimeKind.Unspecified).AddTicks(8254), new TimeSpan(0, 0, 0, 0, 0)), 0L, 14L, 3L }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyRoles_Roles_RoleId",
                table: "PolicyRoles",
                column: "RoleId",
                principalSchema: "Auth",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
