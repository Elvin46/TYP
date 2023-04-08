using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class AddOrderByColumnToPredmetProfessionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 731, DateTimeKind.Utc).AddTicks(1004),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 486, DateTimeKind.Utc).AddTicks(3666));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 705, DateTimeKind.Utc).AddTicks(2444),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 471, DateTimeKind.Utc).AddTicks(6493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(7342),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(5469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(7993));

            migrationBuilder.AddColumn<int>(
                name: "orderBy",
                table: "PredmetProfessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderBy",
                table: "PredmetProfessions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 486, DateTimeKind.Utc).AddTicks(3666),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 731, DateTimeKind.Utc).AddTicks(1004));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 471, DateTimeKind.Utc).AddTicks(6493),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 705, DateTimeKind.Utc).AddTicks(2444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(9369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(7342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 28, 1, 45, 36, 502, DateTimeKind.Utc).AddTicks(7993),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 28, 20, 14, 51, 752, DateTimeKind.Utc).AddTicks(5469));
        }
    }
}
