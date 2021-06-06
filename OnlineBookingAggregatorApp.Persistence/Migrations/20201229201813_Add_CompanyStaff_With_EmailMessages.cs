using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnlineBookingAggregatorApp.Persistence.Migrations
{
    public partial class Add_CompanyStaff_With_EmailMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyUsers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTimeOffset>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyStaffServices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CompanyStaffId = table.Column<long>(nullable: false),
                    ServiceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStaffServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyStaffServices_CompanyUsers_CompanyStaffId",
                        column: x => x.CompanyStaffId,
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyStaffServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CompanyStaffId = table.Column<long>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Attachment = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMessages_CompanyUsers_CompanyStaffId",
                        column: x => x.CompanyStaffId,
                        principalTable: "CompanyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStaffServices_CompanyStaffId",
                table: "CompanyStaffServices",
                column: "CompanyStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyStaffServices_ServiceId",
                table: "CompanyStaffServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUsers_CompanyId",
                table: "CompanyUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_CompanyStaffId",
                table: "EmailMessages",
                column: "CompanyStaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyStaffServices");

            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropTable(
                name: "CompanyUsers");
        }
    }
}
