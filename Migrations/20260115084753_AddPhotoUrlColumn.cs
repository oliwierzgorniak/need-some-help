using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeedSomeHelp.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoUrlColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "HelpRequests",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "HelpRequests");
        }
    }
}
