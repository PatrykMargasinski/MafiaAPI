using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToBossId = table.Column<long>(type: "bigint", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Report__ToBossI__208CD6FC",
                        column: x => x.ToBossId,
                        principalTable: "Boss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 8, 6, 8, 29, 48, 154, DateTimeKind.Local).AddTicks(9898));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 8, 6, 8, 29, 48, 161, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CompletionTime",
                value: new DateTime(2021, 8, 6, 8, 29, 48, 171, DateTimeKind.Local).AddTicks(2007));

            migrationBuilder.UpdateData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CompletionTime",
                value: new DateTime(2021, 8, 6, 8, 29, 48, 171, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "Content", "ReceivedDate", "Seen", "Subject", "ToBossId" },
                values: new object[] { 1L, "TestReport", new DateTime(2021, 8, 6, 8, 29, 48, 172, DateTimeKind.Local).AddTicks(4791), false, "Test", 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Report_ToBossId",
                table: "Report",
                column: "ToBossId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Report");

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
    }
}
