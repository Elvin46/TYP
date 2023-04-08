using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class CreateRelationBetweenPredmetAndDepartmentEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 762, DateTimeKind.Utc).AddTicks(1937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 104, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 738, DateTimeKind.Utc).AddTicks(9405),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 80, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(7770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 127, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Predmets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(6035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 126, DateTimeKind.Utc).AddTicks(9328));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 104, DateTimeKind.Utc).AddTicks(9494),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 762, DateTimeKind.Utc).AddTicks(1937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 80, DateTimeKind.Utc).AddTicks(6695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 738, DateTimeKind.Utc).AddTicks(9405));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 127, DateTimeKind.Utc).AddTicks(609),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(7770));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Predmets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 14, 10, 59, 10, 126, DateTimeKind.Utc).AddTicks(9328),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 14, 11, 13, 49, 782, DateTimeKind.Utc).AddTicks(6035));
        }
    }
}
