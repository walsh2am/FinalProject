using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "HobbyId", "Category", "HoursPerWeek", "Name", "SkillLevel" },
                values: new object[] { 6, "Entertainment", 4, "Guitar", "Intermediate" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "MovieId", "Genre", "Rating", "ReleaseYear", "Title" },
                values: new object[] { 6, "Sci-fi", 5.0, 1977, "Star Wars Episode IV" });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "TeamMemberId", "Birthdate", "CollegeProgram", "FullName", "YearInProgram" },
                values: new object[] { 2, new DateTime(2001, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Software Application Development", "Andrew Walsh", "Freshman" });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "VideoGamesId", "Genre", "HoursPlayed", "Name", "isBestGame" },
                values: new object[] { 7, "Sandbox", 200, "Minecraft", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hobby",
                keyColumn: "HobbyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "MovieId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "TeamMemberId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "VideoGamesId",
                keyValue: 7);
        }
    }
}
