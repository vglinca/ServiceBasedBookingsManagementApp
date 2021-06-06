using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class MakeIdOfTypeLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyRoles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Services",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ServiceEmployees",
                newName: "ServiceEmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Positions",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CompanyBusinessAreas",
                newName: "CompanyBusinessAreaId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Companies",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");

            migrationBuilder.AlterColumn<long>(
                name: "ClientCategoryId",
                table: "Clients",
                type: "bigint",
                nullable: false,
                defaultValue: 1L,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Services_CreatedById",
                table: "Services",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Services_UpdatedById",
                table: "Services",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEmployees_CreatedById",
                table: "ServiceEmployees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEmployees_UpdatedById",
                table: "ServiceEmployees",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_CreatedById",
                table: "Positions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_UpdatedById",
                table: "Positions",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBusinessAreas_CreatedById",
                table: "CompanyBusinessAreas",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyBusinessAreas_UpdatedById",
                table: "CompanyBusinessAreas",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UpdatedById",
                table: "Companies",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UpdatedById",
                table: "Clients",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CreatedById",
                table: "Bookings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UpdatedById",
                table: "Bookings",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services",
                column: "CreatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services",
                column: "UpdatedById",
                principalSchema: "Auth",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_CreatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UpdatedById",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UpdatedById",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UpdatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UpdatedById",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_CreatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyBusinessAreas_Users_UpdatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_CreatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Users_UpdatedById",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_CreatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceEmployees_Users_UpdatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_CreatedById",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_UpdatedById",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_CreatedById",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_UpdatedById",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_ServiceEmployees_CreatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ServiceEmployees_UpdatedById",
                table: "ServiceEmployees");

            migrationBuilder.DropIndex(
                name: "IX_Positions_CreatedById",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_UpdatedById",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBusinessAreas_CreatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropIndex(
                name: "IX_CompanyBusinessAreas_UpdatedById",
                table: "CompanyBusinessAreas");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_UpdatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UpdatedById",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CreatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UpdatedById",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CreatedById",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UpdatedById",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Services",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ServiceEmployeeId",
                table: "ServiceEmployees",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "Positions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyBusinessAreaId",
                table: "CompanyBusinessAreas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.AlterColumn<long>(
                name: "ClientCategoryId",
                table: "Clients",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValue: 1L);

            migrationBuilder.CreateTable(
                name: "PolicyRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    SystemRoleId = table.Column<long>(type: "bigint", nullable: false),
                    SystemCreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
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
                        name: "FK_PolicyRoles_SystemRoles_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "SystemRoles",
                        principalColumn: "SystemRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "CreatedById", "PolicyId", "SystemRoleId", "SystemCreatedDate", "UpdatedById", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a274db46-dcab-4d31-a334-14ad7bf7f78f"), 0L, 1L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 633, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 633, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("a8a074f2-2965-4ba0-9373-126ec458e0c2"), 0L, 11L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6862), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6864), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("3e61a397-f39f-4edb-b0d8-2efc6873d6aa"), 0L, 11L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6897), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6897), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("0b861366-9a39-49d6-8a15-6cdb400a839f"), 0L, 12L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7188), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7189), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("b6bd6ead-d497-411b-b82b-29d26a6431f4"), 0L, 12L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7221), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7222), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("0ece082c-867a-440c-9236-e2a9e69e6988"), 0L, 12L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7251), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7252), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("1ecc718d-cf3b-4d03-ba5f-92769813e1f8"), 0L, 13L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7506), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7507), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("9a16828d-21c0-4419-93ff-1db04fb40f04"), 0L, 13L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7539), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7539), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("2e463e87-7ffd-4575-a520-4ac151f12564"), 0L, 13L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7569), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7570), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("cd3ed425-13c1-4f04-820f-703b8eb3bd6c"), 0L, 14L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7826), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("25c7737d-5340-4825-b354-a81289aed597"), 0L, 14L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7858), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7859), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("61df2cec-0ac8-4e1a-a121-626a655d0b5a"), 0L, 14L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7888), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(7889), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("f3b9a082-cda7-4bb8-b7a3-775139e2ae6f"), 0L, 15L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8234), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("17bd411d-0d9a-42ff-94f5-c03709275649"), 0L, 15L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8271), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8272), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("851cfe84-ff79-4e3e-8a55-eff1335518a9"), 0L, 16L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8525), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("cbfea811-bc5a-455e-8244-7628849ad96b"), 0L, 17L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8777), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(8778), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("a0d92c04-cc3b-4cbb-9277-caae891bf25f"), 0L, 10L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6559), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6560), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("e495bb6a-8fb2-4159-a8f4-16201e186e7f"), 0L, 9L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6306), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("982bfab1-a2bc-467e-ae03-e8f561c38dc4"), 0L, 9L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6276), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("0bcb53e0-c7df-450c-930c-23f372b221e5"), 0L, 9L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6243), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(6244), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("a808cfc8-fd25-4c4d-bb82-13e44fe6c8d7"), 0L, 1L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(2383), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(2387), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("111f5881-5698-4c1e-bd67-37563788fe7e"), 0L, 2L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(3883), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(3885), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("99d2abde-6e73-4afc-80a2-589df446aae9"), 0L, 2L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(3927), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(3927), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("be14b26a-4e23-44fc-a094-d3f662247782"), 0L, 3L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4298), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4300), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("a0f0a89f-9a69-485f-9077-1ad3f9c5b3de"), 0L, 4L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4609), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4611), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("cda36e58-ecb9-4380-a208-61ad2d7b2a7f"), 0L, 4L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4643), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("a65f82c3-522f-48ee-8c51-3ab673acba62"), 0L, 4L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4673), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4674), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("e5d1fcba-631b-4039-9df1-29d1bbd575ac"), 0L, 18L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(9025), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("d9f38f61-61b4-406e-a24c-e94f2904dca9"), 0L, 5L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4938), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4939), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("bc0bc877-6376-4f65-a823-3f1961e39dc7"), 0L, 6L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5303), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5305), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("42048fba-2f3b-45ad-b61b-6cc615818103"), 0L, 6L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5338), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("3c863133-67b4-412c-a25c-9dbb874398d8"), 0L, 6L, 3L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5367), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5368), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("c43ece28-e776-4ac7-8e23-379bcd3ef63d"), 0L, 7L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5630), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5631), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("b2b17bf0-1929-49ca-8feb-7f8be0c0a384"), 0L, 7L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5663), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("76960198-acb1-417c-9d4f-fc249c9cd466"), 0L, 8L, 1L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5918), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5919), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("33480bae-d1df-468c-9233-0569244ceef8"), 0L, 8L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(5951), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("73ead79b-8968-42cd-aa75-5a5617bf0ff1"), 0L, 5L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4974), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(4975), new TimeSpan(0, 2, 0, 0, 0)) },
                    { new Guid("103a6fec-c683-436f-ba39-a6c2c44f7d0b"), 0L, 18L, 2L, new DateTimeOffset(new DateTime(2021, 2, 24, 20, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(9058), new TimeSpan(0, 0, 0, 0, 0)), 0L, new DateTimeOffset(new DateTime(2021, 2, 24, 22, 37, 54, 638, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 2, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_PolicyId",
                table: "PolicyRoles",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_SystemRoleId",
                table: "PolicyRoles",
                column: "SystemRoleId");
        }
    }
}
