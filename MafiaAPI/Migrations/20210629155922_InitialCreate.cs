using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boss",
                columns: table => new
                {
                    BossId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Money = table.Column<int>(type: "int", nullable: false),
                    LastSeen = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boss", x => x.BossId);
                });

            migrationBuilder.CreateTable(
                name: "FirstNames",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "LastNames",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: true),
                    Loot = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.MissionId);
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BossId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: true),
                    Income = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK__Agent__BossId__4BAC3F29",
                        column: x => x.BossId,
                        principalTable: "Boss",
                        principalColumn: "BossId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BossId = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK__Message__BossId__66603565",
                        column: x => x.BossId,
                        principalTable: "Boss",
                        principalColumn: "BossId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nick = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    BossId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK__Player__BossId__1DB06A4F",
                        column: x => x.BossId,
                        principalTable: "Boss",
                        principalColumn: "BossId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PerformingMission",
                columns: table => new
                {
                    PerformingMissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionId = table.Column<int>(type: "int", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    CompletionTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformingMission", x => x.PerformingMissionId);
                    table.ForeignKey(
                        name: "FK__Performin__Agent__5165187F",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Performin__Missi__5070F446",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "MissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_BossId",
                table: "Agent",
                column: "BossId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_BossId",
                table: "Message",
                column: "BossId");

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
                name: "FirstNames");

            migrationBuilder.DropTable(
                name: "LastNames");

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
