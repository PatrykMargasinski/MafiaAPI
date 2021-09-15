using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class intToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentForSale ");

            migrationBuilder.AlterColumn<long>(
                name: "Money",
                table: "Boss",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AgentForSale",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentForSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentForSale_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AgentForSale",
                columns: new[] { "Id", "AgentId", "Price" },
                values: new object[] { 1L, 4L, 5000L });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LastSeen", "Money" },
                values: new object[] { new DateTime(2021, 9, 11, 9, 22, 56, 626, DateTimeKind.Local).AddTicks(1023), 5000L });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LastSeen", "Money" },
                values: new object[] { new DateTime(2021, 9, 11, 9, 22, 56, 630, DateTimeKind.Local).AddTicks(2878), 5000L });

            migrationBuilder.CreateIndex(
                name: "IX_AgentForSale_AgentId",
                table: "AgentForSale",
                column: "AgentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentForSale");

            migrationBuilder.AlterColumn<int>(
                name: "Money",
                table: "Boss",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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

            migrationBuilder.InsertData(
                table: "AgentForSale ",
                columns: new[] { "Id", "AgentId", "Price" },
                values: new object[] { 1L, 4L, 5000L });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "LastSeen", "Money" },
                values: new object[] { new DateTime(2021, 9, 4, 10, 42, 53, 910, DateTimeKind.Local).AddTicks(6938), 5000 });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "LastSeen", "Money" },
                values: new object[] { new DateTime(2021, 9, 4, 10, 42, 53, 917, DateTimeKind.Local).AddTicks(1513), 5000 });

            migrationBuilder.CreateIndex(
                name: "IX_AgentForSale _AgentId",
                table: "AgentForSale ",
                column: "AgentId",
                unique: true);
        }
    }
}
