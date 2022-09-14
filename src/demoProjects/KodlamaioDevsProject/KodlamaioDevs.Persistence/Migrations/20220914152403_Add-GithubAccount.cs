using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodlamaioDevs.Persistence.Migrations
{
    public partial class AddGithubAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GithubAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GithubAccounts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GithubAccounts",
                columns: new[] { "Id", "GithubLink", "UserId" },
                values: new object[] { 1, "https://github.com/Emopusta", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GithubAccounts");
        }
    }
}
