using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleApi.DAL.Migrations
{
    public partial class removecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Commenters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Writers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Commenters",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }
    }
}
