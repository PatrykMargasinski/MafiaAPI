using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class mission_duration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<double>(
                name: "Duration",
                table: "Mission",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 7, 14, 10, 40, 695, DateTimeKind.Local).AddTicks(3694));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 7, 14, 10, 40, 699, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Duration",
                value: 30.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Duration",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Duration",
                value: 10.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Duration",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Duration",
                value: 55.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Duration",
                value: 3600.0);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Duration",
                value: 15.0);

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 7, 14, 10, 40, 703, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 7, 14, 10, 40, 704, DateTimeKind.Local).AddTicks(559));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Mission");

            migrationBuilder.AddColumn<long>(
                name: "BossId",
                table: "Message",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MessageId",
                table: "Message",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 3, 9, 13, 55, 264, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 3, 9, 13, 55, 268, DateTimeKind.Local).AddTicks(3431));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 3, 9, 13, 55, 272, DateTimeKind.Local).AddTicks(3443));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 3, 9, 13, 55, 272, DateTimeKind.Local).AddTicks(3994));
        }
    }
}
