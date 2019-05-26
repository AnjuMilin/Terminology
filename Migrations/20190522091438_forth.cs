using Microsoft.EntityFrameworkCore.Migrations;

namespace TerminologyDemo.Migrations
{
    public partial class forth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConformPassword",
                table: "UserAccount",
                nullable: true,
                oldClrType: typeof(string));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ConformPassword",
                table: "UserAccount",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
