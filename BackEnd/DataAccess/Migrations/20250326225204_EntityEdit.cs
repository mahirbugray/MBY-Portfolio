using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EntityEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillCategories_Skills_SkillId",
                table: "SkillCategories");

            migrationBuilder.DropIndex(
                name: "IX_SkillCategories_SkillId",
                table: "SkillCategories");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "SkillCategories");

            migrationBuilder.DropColumn(
                name: "SkillId",
                table: "SkillCategories");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "SkillCategories",
                newName: "SkillCategoryName");

            migrationBuilder.AddColumn<int>(
                name: "SkillCategoryId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SkillCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateofIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificateImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardingOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills",
                column: "SkillCategoryId",
                principalTable: "SkillCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillCategories_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SkillCategoryId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SkillCategories");

            migrationBuilder.RenameColumn(
                name: "SkillCategoryName",
                table: "SkillCategories",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "SkillCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                table: "SkillCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategories_SkillId",
                table: "SkillCategories",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillCategories_Skills_SkillId",
                table: "SkillCategories",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
