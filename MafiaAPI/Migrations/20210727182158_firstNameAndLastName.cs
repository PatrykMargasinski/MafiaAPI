using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MafiaAPI.Migrations
{
    public partial class firstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstName",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LastName",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastName", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 27, 20, 21, 56, 997, DateTimeKind.Local).AddTicks(556));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 7, 27, 20, 21, 57, 1, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.InsertData(
                table: "FirstName",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Gianna" },
                    { 2L, "Blanka" },
                    { 3L, "Lucia" },
                    { 4L, "Romeo" },
                    { 5L, "Capri" },
                    { 6L, "Armani" },
                    { 7L, "Giuseppe" },
                    { 8L, "Secondo" },
                    { 9L, "Allegra" },
                    { 10L, "Brandy" }
                });

            migrationBuilder.InsertData(
                table: "LastName",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10L, "Marino" },
                    { 9L, "Bruno" },
                    { 8L, "Greco" },
                    { 7L, "Moretti" },
                    { 2L, "Colombo" },
                    { 5L, "Rizzo" },
                    { 4L, "De Luca" },
                    { 3L, "Conti" },
                    { 1L, "Ferrari" },
                    { 6L, "Lombardi" }
                });

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 27, 20, 21, 57, 7, DateTimeKind.Local).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 7, 27, 20, 21, 57, 7, DateTimeKind.Local).AddTicks(7252));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstName");

            migrationBuilder.DropTable(
                name: "LastName");

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
