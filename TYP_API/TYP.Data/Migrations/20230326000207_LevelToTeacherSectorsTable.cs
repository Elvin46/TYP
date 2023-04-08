using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class LevelToTeacherSectorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "TeacherSectors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 108, DateTimeKind.Utc).AddTicks(6559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 762, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 95, DateTimeKind.Utc).AddTicks(2468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 738, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "TeacherPredmets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PredmetProfessionId",
                table: "TeacherPredmets",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1798),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1002),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(6035));

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPredmets_GroupId",
                table: "TeacherPredmets",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPredmets_PredmetProfessionId",
                table: "TeacherPredmets",
                column: "PredmetProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPredmets_Groups_GroupId",
                table: "TeacherPredmets",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPredmets_PredmetProfessions_PredmetProfessionId",
                table: "TeacherPredmets",
                column: "PredmetProfessionId",
                principalTable: "PredmetProfessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_Groups_GroupId",
                table: "TeacherPredmets");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_PredmetProfessions_PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPredmets_GroupId",
                table: "TeacherPredmets");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPredmets_PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "TeacherSectors");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "TeacherPredmets");

            migrationBuilder.DropColumn(
                name: "PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 762, DateTimeKind.Utc).AddTicks(1937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 108, DateTimeKind.Utc).AddTicks(6559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 738, DateTimeKind.Utc).AddTicks(9405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 95, DateTimeKind.Utc).AddTicks(2468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(7770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1798));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(6035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 26, 4, 2, 7, 120, DateTimeKind.Utc).AddTicks(1002));
        }
    }
}
