using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class levelandcourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "LevelName" },
                values: new object[] { 1, "First Level" });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "LevelName" },
                values: new object[] { 2, "Second Level" });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "LevelName" },
                values: new object[] { 3, "Third Level" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelId",
                table: "Courses",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
