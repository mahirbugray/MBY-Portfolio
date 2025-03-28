using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ServiceEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillCategories_CategorySkills_CategorySkillId",
                table: "SkillCategories");

            migrationBuilder.DropTable(
                name: "CategorySkills");

            migrationBuilder.DropTable(
                name: "ProjectCategories");

            migrationBuilder.DropIndex(
                name: "IX_SkillCategories_CategorySkillId",
                table: "SkillCategories");

            migrationBuilder.DropColumn(
                name: "CategorySkillId",
                table: "SkillCategories");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "SkillCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "SkillCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "SkillCategories");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "SkillCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategorySkillId",
                table: "SkillCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategorySkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    SkillArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCategories_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_CategorySkillId",
                table: "SkillCategories",
                column: "CategorySkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCategories_ProjectId",
                table: "ProjectCategories",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillCategories_CategorySkills_CategorySkillId",
                table: "SkillCategories",
                column: "CategorySkillId",
                principalTable: "CategorySkills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
