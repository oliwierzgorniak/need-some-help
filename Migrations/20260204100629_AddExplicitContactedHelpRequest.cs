using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedSomeHelp.Migrations
{
    /// <inheritdoc />
    public partial class AddExplicitContactedHelpRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactedHelpRequests");

            migrationBuilder.CreateTable(
                name: "ContactedUserRequests",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactedUserRequests", x => new { x.UserId, x.RequestId });
                    table.ForeignKey(
                        name: "FK_ContactedUserRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactedUserRequests_HelpRequests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "HelpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactedUserRequests_RequestId",
                table: "ContactedUserRequests",
                column: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactedUserRequests");

            migrationBuilder.CreateTable(
                name: "ContactedHelpRequests",
                columns: table => new
                {
                    ContactedHelpRequestsId = table.Column<int>(type: "int", nullable: false),
                    ContactedByUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactedHelpRequests", x => new { x.ContactedHelpRequestsId, x.ContactedByUsersId });
                    table.ForeignKey(
                        name: "FK_ContactedHelpRequests_AspNetUsers_ContactedByUsersId",
                        column: x => x.ContactedByUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactedHelpRequests_HelpRequests_ContactedHelpRequestsId",
                        column: x => x.ContactedHelpRequestsId,
                        principalTable: "HelpRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactedHelpRequests_ContactedByUsersId",
                table: "ContactedHelpRequests",
                column: "ContactedByUsersId");
        }
    }
}
