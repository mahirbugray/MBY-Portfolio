using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ReEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjectUrl",
                table: "Projects",
                newName: "Technologies");

            migrationBuilder.RenameColumn(
                name: "ProjectText",
                table: "Projects",
                newName: "ProjectTitle");

            migrationBuilder.RenameColumn(
                name: "ProjectHeader",
                table: "Projects",
                newName: "ProjectImageUrl6");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectImageUrl2",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectImageUrl3",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectImageUrl4",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProjectImageUrl5",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectImageUrl2",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectImageUrl3",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectImageUrl4",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectImageUrl5",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "Technologies",
                table: "Projects",
                newName: "ProjectUrl");

            migrationBuilder.RenameColumn(
                name: "ProjectTitle",
                table: "Projects",
                newName: "ProjectText");

            migrationBuilder.RenameColumn(
                name: "ProjectImageUrl6",
                table: "Projects",
                newName: "ProjectHeader");
        }
    }
}
