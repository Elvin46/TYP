using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class EditRelationBetweenDepartmentAndFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyDepartments_Departments_DepartmentId",
                table: "FacultyDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_FacultyDepartments_Faculties_FacultyId",
                table: "FacultyDepartments");

            migrationBuilder.DropIndex(
                name: "IX_FacultyDepartments_DepartmentId",
                table: "FacultyDepartments");

            migrationBuilder.DropIndex(
                name: "IX_FacultyDepartments_FacultyId",
                table: "FacultyDepartments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "FacultyDepartments");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "FacultyDepartments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 311, DateTimeKind.Utc).AddTicks(5593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 780, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 294, DateTimeKind.Utc).AddTicks(8736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 760, DateTimeKind.Utc).AddTicks(5558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(6548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(5614),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(4505));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Faculties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Faculties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DepartmentId1",
                table: "Faculties",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Departments_DepartmentId1",
                table: "Faculties",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Departments_DepartmentId1",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_DepartmentId1",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Departments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 780, DateTimeKind.Utc).AddTicks(6657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 311, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 760, DateTimeKind.Utc).AddTicks(5558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 294, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(6252),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 2, 14, 16, 4, 800, DateTimeKind.Utc).AddTicks(4505),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 2, 17, 5, 2, 324, DateTimeKind.Utc).AddTicks(5614));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "FacultyDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "FacultyDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDepartments_DepartmentId",
                table: "FacultyDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyDepartments_FacultyId",
                table: "FacultyDepartments",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyDepartments_Departments_DepartmentId",
                table: "FacultyDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyDepartments_Faculties_FacultyId",
                table: "FacultyDepartments",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
