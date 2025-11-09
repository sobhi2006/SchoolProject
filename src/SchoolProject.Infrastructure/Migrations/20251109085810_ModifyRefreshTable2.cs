using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRefreshTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserRefreshTokens");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_UserRefreshTokens_UserId",
                table: "UserRefreshTokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserRefreshTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserRefreshTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshTokens_UserId1",
                table: "UserRefreshTokens",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRefreshTokens_AspNetUsers_UserId1",
                table: "UserRefreshTokens",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
