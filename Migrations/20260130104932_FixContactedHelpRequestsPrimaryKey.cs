using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedSomeHelp.Migrations
{
    /// <inheritdoc />
    public partial class FixContactedHelpRequestsPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactedHelpRequests",
                table: "ContactedHelpRequests");

            migrationBuilder.AlterColumn<string>(
                name: "ContactedByUsersId",
                table: "ContactedHelpRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactedHelpRequests",
                table: "ContactedHelpRequests",
                columns: new[] { "ContactedHelpRequestsId", "ContactedByUsersId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactedHelpRequests",
                table: "ContactedHelpRequests");

            migrationBuilder.AlterColumn<string>(
                name: "ContactedByUsersId",
                table: "ContactedHelpRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactedHelpRequests",
                table: "ContactedHelpRequests",
                column: "ContactedHelpRequestsId");
        }
    }
}
