using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class add_dex_int_to_agent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Dexterity", "Intelligence" },
                values: new object[] { 10, 10 });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Dexterity", "Intelligence" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Dexterity", "Intelligence" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Dexterity",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Dexterity", "Intelligence" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 25, 8, 47, 38, 663, DateTimeKind.Local).AddTicks(7984));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 25, 8, 47, 38, 667, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 25, 8, 47, 38, 672, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 25, 8, 47, 38, 672, DateTimeKind.Local).AddTicks(7699));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dexterity",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                table: "Agent");

            migrationBuilder.AlterColumn<int>(
                name: "Strength",
                table: "Agent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 18, 12, 45, 39, 804, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 18, 12, 45, 39, 812, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 18, 12, 45, 39, 823, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 18, 12, 45, 39, 824, DateTimeKind.Local).AddTicks(740));
        }
    }
}
