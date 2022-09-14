using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodlamaioDevs.Persistence.Migrations
{
    public partial class AddOperationClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim");

            migrationBuilder.RenameTable(
                name: "OperationClaim",
                newName: "OperationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "user" });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_OperationClaims_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOperationClaim_OperationClaims_OperationClaimId",
                table: "UserOperationClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "OperationClaim");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaim",
                table: "OperationClaim",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOperationClaim_OperationClaim_OperationClaimId",
                table: "UserOperationClaim",
                column: "OperationClaimId",
                principalTable: "OperationClaim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
