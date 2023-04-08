using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class CreateSessionsTableAndItsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 132, DateTimeKind.Utc).AddTicks(9511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 731, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 117, DateTimeKind.Utc).AddTicks(8612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 705, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(6469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(5634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "PredmetProfessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "PredmetGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderBy",
                table: "PredmetGroups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredmetProfessions_SessionId",
                table: "PredmetProfessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PredmetGroups_SessionId",
                table: "PredmetGroups",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroups_Sessions_SessionId",
                table: "PredmetGroups",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetProfessions_Sessions_SessionId",
                table: "PredmetProfessions",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroups_Sessions_SessionId",
                table: "PredmetGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PredmetProfessions_Sessions_SessionId",
                table: "PredmetProfessions");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_PredmetProfessions_SessionId",
                table: "PredmetProfessions");

            migrationBuilder.DropIndex(
                name: "IX_PredmetGroups_SessionId",
                table: "PredmetGroups");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PredmetProfessions");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "PredmetGroups");

            migrationBuilder.DropColumn(
                name: "orderBy",
                table: "PredmetGroups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 731, DateTimeKind.Utc).AddTicks(1004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 132, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 705, DateTimeKind.Utc).AddTicks(2444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 117, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(7342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(5469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(5634));
        }
    }
}
