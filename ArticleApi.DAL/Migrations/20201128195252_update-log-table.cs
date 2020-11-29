using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleApi.DAL.Migrations
{
    public partial class updatelogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogIp",
                table: "Logs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogIp",
                table: "Logs");
        }
    }
}
