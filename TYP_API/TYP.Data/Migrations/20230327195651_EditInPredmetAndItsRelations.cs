using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class EditInPredmetAndItsRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Predmets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 369, DateTimeKind.Utc).AddTicks(9189),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 108, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 355, DateTimeKind.Utc).AddTicks(7804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 95, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(9023),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(7775),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1002));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PredmetProfessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PredmetGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PredmetId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    GeneralHours = table.Column<int>(type: "int", nullable: false),
                    OutOfAuditoryHours = table.Column<int>(type: "int", nullable: false),
                    AuditoryHours = table.Column<int>(type: "int", nullable: false),
                    Lecturer = table.Column<int>(type: "int", nullable: false),
                    Seminar = table.Column<int>(type: "int", nullable: false),
                    Laboratory = table.Column<int>(type: "int", nullable: false),
                    IsPrerequisite = table.Column<bool>(type: "bit", nullable: false),
                    WeeklyLoad = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredmetGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredmetGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredmetGroup_Predmets_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredmetGroup_GroupId",
                table: "PredmetGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PredmetGroup_PredmetId",
                table: "PredmetGroup",
                column: "PredmetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredmetGroup");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PredmetProfessions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 108, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 369, DateTimeKind.Utc).AddTicks(9189));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 95, DateTimeKind.Utc).AddTicks(2468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 355, DateTimeKind.Utc).AddTicks(7804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(9023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 27, 23, 56, 50, 383, DateTimeKind.Utc).AddTicks(7775));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Predmets",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
