using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class CreateCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroup_Groups_GroupId",
                table: "PredmetGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroup_Predmets_PredmetId",
                table: "PredmetGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredmetGroup",
                table: "PredmetGroup");

            migrationBuilder.RenameTable(
                name: "PredmetGroup",
                newName: "PredmetGroups");

            migrationBuilder.RenameIndex(
                name: "IX_PredmetGroup_PredmetId",
                table: "PredmetGroups",
                newName: "IX_PredmetGroups_PredmetId");

            migrationBuilder.RenameIndex(
                name: "IX_PredmetGroup_GroupId",
                table: "PredmetGroups",
                newName: "IX_PredmetGroups_GroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 486, DateTimeKind.Utc).AddTicks(3666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 369, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 471, DateTimeKind.Utc).AddTicks(6493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 355, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(9369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(7993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PredmetProfessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PredmetGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredmetGroups",
                table: "PredmetGroups",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredmetProfessions_CategoryId",
                table: "PredmetProfessions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PredmetGroups_CategoryId",
                table: "PredmetGroups",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroups_Categories_CategoryId",
                table: "PredmetGroups",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroups_Groups_GroupId",
                table: "PredmetGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroups_Predmets_PredmetId",
                table: "PredmetGroups",
                column: "PredmetId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetProfessions_Categories_CategoryId",
                table: "PredmetProfessions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroups_Categories_CategoryId",
                table: "PredmetGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroups_Groups_GroupId",
                table: "PredmetGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroups_Predmets_PredmetId",
                table: "PredmetGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfessions_Categories_CategoryId",
                table: "PredmetProfessions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_PredmetProfessions_CategoryId",
                table: "PredmetProfessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PredmetGroups",
                table: "PredmetGroups");

            migrationBuilder.DropIndex(
                name: "IX_PredmetGroups_CategoryId",
                table: "PredmetGroups");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PredmetProfessions");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PredmetGroups");

            migrationBuilder.RenameTable(
                name: "PredmetGroups",
                newName: "PredmetGroup");

            migrationBuilder.RenameIndex(
                name: "IX_PredmetGroups_PredmetId",
                table: "PredmetGroup",
                newName: "IX_PredmetGroup_PredmetId");

            migrationBuilder.RenameIndex(
                name: "IX_PredmetGroups_GroupId",
                table: "PredmetGroup",
                newName: "IX_PredmetGroup_GroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 369, DateTimeKind.Utc).AddTicks(9189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 486, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 355, DateTimeKind.Utc).AddTicks(7804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 471, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(9023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(7775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(7993));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PredmetGroup",
                table: "PredmetGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroup_Groups_GroupId",
                table: "PredmetGroup",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroup_Predmets_PredmetId",
                table: "PredmetGroup",
                column: "PredmetId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
