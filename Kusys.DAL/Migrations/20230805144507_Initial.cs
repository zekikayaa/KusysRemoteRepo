using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kusys.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, "CSI101", new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690), "Introduction to Computer Science" },
                    { 2, "CSI102", new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690), "Algorithms" },
                    { 3, "MAT101", new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690), "Calculus" },
                    { 4, "PHY101", new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6690), "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "CourseId", "CreatedDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Fehmi", "Demir" },
                    { 2, new DateTime(1994, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Atalay", "Dumenci" },
                    { 3, new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Gurbet", "Sevgi" },
                    { 4, new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Ozkan", "Celen" },
                    { 5, new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Yildiray", "Umut" },
                    { 6, new DateTime(1993, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 8, 5, 14, 45, 6, 904, DateTimeKind.Utc).AddTicks(6770), "Umut", "Eksilmez" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
