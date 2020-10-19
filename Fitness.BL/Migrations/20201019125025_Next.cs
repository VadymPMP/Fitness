using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fitness.BL.Migrations
{
    public partial class Next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Eatings_EatingId",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "Eatings");

            migrationBuilder.DropIndex(
                name: "IX_Foods_EatingId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "EatingId",
                table: "Foods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EatingId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Eatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eatings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_EatingId",
                table: "Foods",
                column: "EatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Eatings_UserId",
                table: "Eatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Eatings_EatingId",
                table: "Foods",
                column: "EatingId",
                principalTable: "Eatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
