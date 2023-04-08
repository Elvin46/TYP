using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class CreateAutenticationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 848, DateTimeKind.Utc).AddTicks(3665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 311, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 837, DateTimeKind.Utc).AddTicks(8422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 294, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 867, DateTimeKind.Utc).AddTicks(9682),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 867, DateTimeKind.Utc).AddTicks(7518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 311, DateTimeKind.Utc).AddTicks(5593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 848, DateTimeKind.Utc).AddTicks(3665));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 294, DateTimeKind.Utc).AddTicks(8736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 837, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(6548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 867, DateTimeKind.Utc).AddTicks(9682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 2, 7, 3, 867, DateTimeKind.Utc).AddTicks(7518));
        }
    }
}
