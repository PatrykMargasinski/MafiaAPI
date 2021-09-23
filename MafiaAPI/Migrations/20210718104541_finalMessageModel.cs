using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MafiaAPI.Migrations
{
    public partial class finalMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Message",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Message");

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
        }
    }
}
