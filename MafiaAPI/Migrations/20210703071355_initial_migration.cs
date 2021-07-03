using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: true),
                    Loot = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BossId = table.Column<long>(type: "bigint", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: true),
                    Income = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Agent__BossId__4BAC3F29",
                        column: x => x.BossId,
                        principalTable: "Boss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToBossId = table.Column<long>(type: "bigint", nullable: true),
                    FromBossId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Message__FromBos__2180FB33",
                        column: x => x.FromBossId,
                        principalTable: "Boss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Message__ToBossI__208CD6FA",
                        column: x => x.ToBossId,
                        principalTable: "Boss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    BossId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Player__BossId__1DB06A4F",
                        column: x => x.BossId,
                        principalTable: "Boss",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformingMission",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionId = table.Column<long>(type: "bigint", nullable: true),
                    AgentId = table.Column<long>(type: "bigint", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformingMission", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Performin__Agent__5165187F",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Performin__Missi__5070F446",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Agent",
                columns: new[] { "Id", "BossId", "FirstName", "Income", "LastName", "Strength" },
                values: new object[] { 4L, null, "Eleonora", 30, "Lora", 8 });

            migrationBuilder.InsertData(
                table: "Boss",
                columns: new[] { "Id", "FirstName", "LastName", "LastSeen", "Money" },
                values: new object[,]
                {
                    { 1L, "Rico", "Patricio", new DateTime(2021, 7, 3, 9, 13, 55, 264, DateTimeKind.Local).AddTicks(8649), 5000 },
                    { 2L, "Margherita", "Rodrigo", new DateTime(2021, 7, 3, 9, 13, 55, 268, DateTimeKind.Local).AddTicks(3431), 5000 }
                });

            migrationBuilder.InsertData(
                table: "Mission",
                columns: new[] { "Id", "DifficultyLevel", "Loot", "Name" },
                values: new object[,]
                {
                    { 1L, 7, 5000, "Bank robbery" },
                    { 2L, 9, 10000, "Senator assassination" },
                    { 3L, 2, 100, "Party" },
                    { 4L, 1, 10, "Buy a coffee" },
                    { 5L, 5, 1000, "Money laundering" },
                    { 6L, 6, 2000, "Car theft" },
                    { 7L, 8, 4000, "Arms trade" }
                });

            migrationBuilder.InsertData(
                table: "Agent",
                columns: new[] { "Id", "BossId", "FirstName", "Income", "LastName", "Strength" },
                values: new object[,]
                {
                    { 1L, 1L, "Kujo", 100, "Jotaro", 10 },
                    { 2L, 1L, "Mickiewicz", 50, "Adam", 5 },
                    { 5L, 1L, "Robert", 200, "Makłowicz", 3 },
                    { 3L, 2L, "Natsu", 70, "Natalia", 7 }
                });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "Id", "BossId", "Nick", "Password" },
                values: new object[,]
                {
                    { 1L, 1L, "mafia", "a" },
                    { 2L, 2L, "tomek", "b" }
                });

            migrationBuilder.InsertData(
                table: "PerformingMission",
                columns: new[] { "Id", "AgentId", "CompletionTime", "MissionId" },
                values: new object[] { 1L, 1L, new DateTime(2021, 7, 3, 9, 13, 55, 272, DateTimeKind.Local).AddTicks(3443), 1L });

            migrationBuilder.InsertData(
                table: "PerformingMission",
                columns: new[] { "Id", "AgentId", "CompletionTime", "MissionId" },
                values: new object[] { 2L, 3L, new DateTime(2021, 7, 3, 9, 13, 55, 272, DateTimeKind.Local).AddTicks(3994), 2L });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_BossId",
                table: "Agent",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FromBossId",
                table: "Message",
                column: "FromBossId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ToBossId",
                table: "Message",
                column: "ToBossId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformingMission_AgentId",
                table: "PerformingMission",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformingMission_MissionId",
                table: "PerformingMission",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Player__07C93FB72CC07189",
                table: "Player",
                column: "BossId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "PerformingMission");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "Boss");
        }
    }
}
