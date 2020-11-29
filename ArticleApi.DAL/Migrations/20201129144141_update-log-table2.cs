using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleApi.DAL.Migrations
{
    public partial class updatelogtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogLayer",
                table: "Logs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Logs",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogLayer",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Logs");
        }
    }
}
