using Microsoft.EntityFrameworkCore.Migrations;

namespace TerminologyDemo.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectManagement_UserAccount_UserId",
                table: "ProjectManagement");

            migrationBuilder.DropIndex(
                name: "IX_ProjectManagement_UserId",
                table: "ProjectManagement");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectManagement");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProjectUpload",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUpload_UserId",
                table: "ProjectUpload",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUpload_UserAccount_UserId",
                table: "ProjectUpload",
                column: "UserId",
                principalTable: "UserAccount",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUpload_UserAccount_UserId",
                table: "ProjectUpload");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUpload_UserId",
                table: "ProjectUpload");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProjectUpload");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProjectManagement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectManagement_UserId",
                table: "ProjectManagement",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectManagement_UserAccount_UserId",
                table: "ProjectManagement",
                column: "UserId",
                principalTable: "UserAccount",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
