using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classforce.Server.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Issues_AuthorId",
                table: "Issues",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_AspNetUsers_AuthorId",
                table: "Issues",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_AspNetUsers_AuthorId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AuthorId",
                table: "Issues");
        }
    }
}
