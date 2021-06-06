using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class AddChangedPolicyRolesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyRoles",
                columns: table => new
                {
                    PolicyRoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolicyId = table.Column<long>(type: "bigint", nullable: false),
                    SystemRoleId = table.Column<long>(type: "bigint", nullable: false),
                    SystemCreatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRoles", x => x.PolicyRoleId);
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
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Users_UpdatedById",
                        column: x => x.UpdatedById,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_CreatedById",
                table: "PolicyRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_PolicyId_SystemRoleId",
                table: "PolicyRoles",
                columns: new[] { "PolicyId", "SystemRoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_SystemRoleId",
                table: "PolicyRoles",
                column: "SystemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_UpdatedById",
                table: "PolicyRoles",
                column: "UpdatedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyRoles");
        }
    }
}
