using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class messageImprovement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReceivedDate",
                table: "Message",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 17, 11, 6, 15, 15, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 17, 11, 6, 15, 20, DateTimeKind.Local).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 17, 11, 6, 15, 31, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 17, 11, 6, 15, 31, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "tlnK6HiwFF4+b4DRVaVdRlIPtzduirsf8W3+nbXlLWlf9c/J");

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "d2JZt0Jz9UzgW1l544W2WnOaX14u/pfGUDYTQzv5AEWk3W7D");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "Message");

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 12, 17, 32, 30, 950, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 12, 17, 32, 30, 954, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 12, 17, 32, 30, 959, DateTimeKind.Local).AddTicks(1174));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 12, 17, 32, 30, 959, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Password",
                value: "a");

            migrationBuilder.UpdateData(
                table: "Player",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Password",
                value: "b");
        }
    }
}
