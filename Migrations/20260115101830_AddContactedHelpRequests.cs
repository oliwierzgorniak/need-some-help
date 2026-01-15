using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedSomeHelp.Migrations
{
    /// <inheritdoc />
    public partial class AddContactedHelpRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactedHelpRequests",
                columns: table => new
                {
                    ContactedHelpRequestsId = table.Column<int>(type: "int", nullable: false),
                    ContactedByUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactedHelpRequests", x => x.ContactedHelpRequestsId);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactedHelpRequests");
        }
    }
}
