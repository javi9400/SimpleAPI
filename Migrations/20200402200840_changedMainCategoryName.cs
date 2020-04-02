using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple.Api.Migrations
{
    public partial class changedMainCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintCategory",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "MainCategory",
                table: "Authors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "MainCategory",
                value: "Science Fiction");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "AuthorId", "Description", "Title" },
                values: new object[] { 1, 1, "Star wars books", "The return of the jedi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "MainCategory",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "MaintCategory",
                table: "Authors",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1,
                column: "MaintCategory",
                value: "Science Fiction");
        }
    }
}
