using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedSomeHelp.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestIdToMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RequestId",
                table: "Messages",
                column: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_HelpRequests_RequestId",
                table: "Messages",
                column: "RequestId",
                principalTable: "HelpRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_HelpRequests_RequestId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RequestId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Messages");
        }
    }
}
