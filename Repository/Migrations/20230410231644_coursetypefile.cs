using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class coursetypefile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseFileTypeId",
                table: "CourseFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CourseFileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFileType", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CourseFileType",
                columns: new[] { "Id", "CourseType" },
                values: new object[] { 1, "pr" });

            migrationBuilder.InsertData(
                table: "CourseFileType",
                columns: new[] { "Id", "CourseType" },
                values: new object[] { 2, "th" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseFiles_CourseFileTypeId",
                table: "CourseFiles",
                column: "CourseFileTypeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CourseFiles_CourseFileType_CourseFileTypeId",
            //    table: "CourseFiles",
            //    column: "CourseFileTypeId",
            //    principalTable: "CourseFileType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseFiles_CourseFileType_CourseFileTypeId",
                table: "CourseFiles");

            migrationBuilder.DropTable(
                name: "CourseFileType");

            migrationBuilder.DropIndex(
                name: "IX_CourseFiles_CourseFileTypeId",
                table: "CourseFiles");

            migrationBuilder.DropColumn(
                name: "CourseFileTypeId",
                table: "CourseFiles");
        }
    }
}
