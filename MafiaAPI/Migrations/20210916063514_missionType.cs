using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaAPI.Migrations
{
    public partial class missionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Loot",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevel",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DexterityPercentage",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntelligencePercentage",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MissionTypeId",
                table: "Mission",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StrengthPercentage",
                table: "Mission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MissionType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinDifficulty = table.Column<int>(type: "int", nullable: false),
                    MaxDifficulty = table.Column<int>(type: "int", nullable: false),
                    MinLoot = table.Column<int>(type: "int", nullable: false),
                    MaxLoot = table.Column<int>(type: "int", nullable: false),
                    StrengthPercentage = table.Column<int>(type: "int", nullable: false),
                    DexterityPercentage = table.Column<int>(type: "int", nullable: false),
                    IntelligencePercentage = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionType", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 9, 16, 8, 35, 13, 414, DateTimeKind.Local).AddTicks(3812));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 9, 16, 8, 35, 13, 419, DateTimeKind.Local).AddTicks(9894));

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Loot",
                value: 5000);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Loot",
                value: 7000);

            migrationBuilder.InsertData(
                table: "MissionType",
                columns: new[] { "Id", "DexterityPercentage", "Duration", "IntelligencePercentage", "MaxDifficulty", "MaxLoot", "MinDifficulty", "MinLoot", "Name", "StrengthPercentage" },
                values: new object[,]
                {
                    { 1L, 20, 30.0, 20, 6, 6000, 4, 4000, "Bank robbery", 60 },
                    { 2L, 10, 60.0, 10, 10, 10000, 8, 8000, "Senator assassination", 80 },
                    { 3L, 0, 10.0, 100, 3, 1000, 1, 100, "Party", 0 },
                    { 4L, 30, 5.0, 40, 1, 100, 1, 100, "Buy a coffee", 30 },
                    { 5L, 20, 55.0, 60, 6, 6000, 4, 4000, "Money laundering", 20 },
                    { 6L, 80, 3600.0, 10, 6, 6000, 4, 4000, "Car theft", 10 },
                    { 7L, 10, 15.0, 80, 8, 8000, 6, 6000, "Arms trade", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mission_MissionTypeId",
                table: "Mission",
                column: "MissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mission_MissionType_MissionTypeId",
                table: "Mission",
                column: "MissionTypeId",
                principalTable: "MissionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mission_MissionType_MissionTypeId",
                table: "Mission");

            migrationBuilder.DropTable(
                name: "MissionType");

            migrationBuilder.DropIndex(
                name: "IX_Mission_MissionTypeId",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "DexterityPercentage",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "IntelligencePercentage",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "MissionTypeId",
                table: "Mission");

            migrationBuilder.DropColumn(
                name: "StrengthPercentage",
                table: "Mission");

            migrationBuilder.AlterColumn<int>(
                name: "Loot",
                table: "Mission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DifficultyLevel",
                table: "Mission",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "LastSeen",
                value: new DateTime(2021, 9, 11, 9, 22, 56, 626, DateTimeKind.Local).AddTicks(1023));

            migrationBuilder.UpdateData(
                table: "Boss",
                keyColumn: "Id",
                keyValue: 2L,
                column: "LastSeen",
                value: new DateTime(2021, 9, 11, 9, 22, 56, 630, DateTimeKind.Local).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Loot",
                value: 1000);

            migrationBuilder.UpdateData(
                table: "Mission",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Loot",
                value: 4000);
        }
    }
}
