using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class AddIsNowColumnToPredmetGroupsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 780, DateTimeKind.Utc).AddTicks(6657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 243, DateTimeKind.Utc).AddTicks(7244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 760, DateTimeKind.Utc).AddTicks(5558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 228, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(6252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(4505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(284));

            migrationBuilder.AddColumn<bool>(
                name: "IsNow",
                table: "PredmetGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsNow",
                table: "PredmetGroups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 243, DateTimeKind.Utc).AddTicks(7244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 780, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 228, DateTimeKind.Utc).AddTicks(7955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 760, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(4505));
        }
    }
}
