using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MafiaAPI.Migrations
{
    public partial class agentsForSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "PerformingMission",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Report",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.CreateTable(
                name: "AgentForSale ",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentForSale ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentForSale _Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jotaro", "Kujo" });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Adam", "Mickiewicz" });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Natalia", "Natsu" });

            migrationBuilder.InsertData(
                table: "AgentForSale ",
                columns: new[] { "Id", "AgentId", "Price" },
                values: new object[] { 1L, 4L, 5000L });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstName", "LastName", "LastSeen" },
                values: new object[] { "Patricio", "Rico", new DateTime(2021, 9, 4, 10, 42, 53, 910, DateTimeKind.Local).AddTicks(6938) });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "FirstName", "LastName", "LastSeen" },
                values: new object[] { "Rodrigo", "Margherita", new DateTime(2021, 9, 4, 10, 42, 53, 917, DateTimeKind.Local).AddTicks(1513) });

            migrationBuilder.CreateIndex(
                name: "IX_AgentForSale _AgentId",
                table: "AgentForSale ",
                column: "AgentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentForSale ");

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kujo", "Jotaro" });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mickiewicz", "Adam" });

            migrationBuilder.UpdateData(
                table: "Agent",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Natsu", "Natalia" });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "FirstName", "LastName", "LastSeen" },
                values: new object[] { "Rico", "Patricio", new DateTime(2021, 8, 6, 8, 29, 48, 154, DateTimeKind.Local).AddTicks(9898) });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "FirstName", "LastName", "LastSeen" },
                values: new object[] { "Margherita", "Rodrigo", new DateTime(2021, 8, 6, 8, 29, 48, 161, DateTimeKind.Local).AddTicks(4698) });

            migrationBuilder.InsertData(
                table: "PerformingMission",
                columns: new[] { "Id", "AgentId", "CompletionTime", "MissionId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 8, 6, 8, 29, 48, 171, DateTimeKind.Local).AddTicks(2007), 1L },
                    { 2L, 3L, new DateTime(2021, 8, 6, 8, 29, 48, 171, DateTimeKind.Local).AddTicks(5088), 2L }
                });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "Content", "ReceivedDate", "Seen", "Subject", "ToBossId" },
                values: new object[] { 1L, "TestReport", new DateTime(2021, 8, 6, 8, 29, 48, 172, DateTimeKind.Local).AddTicks(4791), false, "Test", 1L });
        }
    }
}
