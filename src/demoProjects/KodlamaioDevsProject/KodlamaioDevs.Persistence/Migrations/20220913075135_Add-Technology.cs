using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodlamaioDevs.Persistence.Migrations
{
    public partial class AddTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technology_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technology",
                table: "Technology");

            migrationBuilder.RenameTable(
                name: "Technology",
                newName: "Technologies");

            migrationBuilder.RenameIndex(
                name: "IX_Technology_ProgrammingLanguageId",
                table: "Technologies",
                newName: "IX_Technologies_ProgrammingLanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId" },
                values: new object[] { 1, "Web framework", "Django", 1 });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "Description", "Name", "ProgrammingLanguageId" },
                values: new object[] { 2, ".NEEEEEET", ".Net", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technologies",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologies_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technologies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Technologies",
                table: "Technologies");

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Technologies",
                newName: "Technology");

            migrationBuilder.RenameIndex(
                name: "IX_Technologies_ProgrammingLanguageId",
                table: "Technology",
                newName: "IX_Technology_ProgrammingLanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Technology",
                table: "Technology",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Technology_ProgrammingLanguages_ProgrammingLanguageId",
                table: "Technology",
                column: "ProgrammingLanguageId",
                principalTable: "ProgrammingLanguages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
