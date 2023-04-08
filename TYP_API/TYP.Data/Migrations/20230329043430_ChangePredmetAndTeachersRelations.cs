using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TYP.Data.Migrations
{
    public partial class ChangePredmetAndTeachersRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_Groups_GroupId",
                table: "TeacherPredmets");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_PredmetProfessions_PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_Predmets_PredmetId",
                table: "TeacherPredmets");

            migrationBuilder.DropIndex(
                name: "IX_TeacherPredmets_PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.DropColumn(
                name: "PredmetProfessionId",
                table: "TeacherPredmets");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "TeacherPredmets",
                newName: "PredmetGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPredmets_GroupId",
                table: "TeacherPredmets",
                newName: "IX_TeacherPredmets_PredmetGroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 243, DateTimeKind.Utc).AddTicks(7244),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 132, DateTimeKind.Utc).AddTicks(9511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 228, DateTimeKind.Utc).AddTicks(7955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 117, DateTimeKind.Utc).AddTicks(8612));

            migrationBuilder.AlterColumn<int>(
                name: "PredmetId",
                table: "TeacherPredmets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(972),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(5634));

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "PredmetGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PredmetGroups_TeacherId",
                table: "PredmetGroups",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_PredmetGroups_Teachers_TeacherId",
                table: "PredmetGroups",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPredmets_PredmetGroups_PredmetGroupId",
                table: "TeacherPredmets",
                column: "PredmetGroupId",
                principalTable: "PredmetGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPredmets_Predmets_PredmetId",
                table: "TeacherPredmets",
                column: "PredmetId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PredmetGroups_Teachers_TeacherId",
                table: "PredmetGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_PredmetGroups_PredmetGroupId",
                table: "TeacherPredmets");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherPredmets_Predmets_PredmetId",
                table: "TeacherPredmets");

            migrationBuilder.DropIndex(
                name: "IX_PredmetGroups_TeacherId",
                table: "PredmetGroups");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "PredmetGroups");

            migrationBuilder.RenameColumn(
                name: "PredmetGroupId",
                table: "TeacherPredmets",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_TeacherPredmets_PredmetGroupId",
                table: "TeacherPredmets",
                newName: "IX_TeacherPredmets_GroupId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 132, DateTimeKind.Utc).AddTicks(9511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 243, DateTimeKind.Utc).AddTicks(7244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Teachers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 117, DateTimeKind.Utc).AddTicks(8612),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 228, DateTimeKind.Utc).AddTicks(7955));

            migrationBuilder.AlterColumn<int>(
                name: "PredmetId",
                table: "TeacherPredmets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(6469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(972));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Predmets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 29, 0, 56, 55, 145, DateTimeKind.Utc).AddTicks(5634),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 29, 8, 34, 30, 254, DateTimeKind.Utc).AddTicks(284));

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

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherPredmets_Predmets_PredmetId",
                table: "TeacherPredmets",
                column: "PredmetId",
                principalTable: "Predmets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
