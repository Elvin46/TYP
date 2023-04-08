using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class Error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 663, DateTimeKind.Utc).AddTicks(752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 812, DateTimeKind.Utc).AddTicks(7258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 657, DateTimeKind.Utc).AddTicks(2226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 808, DateTimeKind.Utc).AddTicks(2752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 676, DateTimeKind.Utc).AddTicks(3480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 820, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 676, DateTimeKind.Utc).AddTicks(2215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 820, DateTimeKind.Utc).AddTicks(2670));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 812, DateTimeKind.Utc).AddTicks(7258),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 663, DateTimeKind.Utc).AddTicks(752));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 808, DateTimeKind.Utc).AddTicks(2752),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 657, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 820, DateTimeKind.Utc).AddTicks(3284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 676, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 17, 57, 820, DateTimeKind.Utc).AddTicks(2670),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 3, 23, 30, 676, DateTimeKind.Utc).AddTicks(2215));
        }
    }
}
