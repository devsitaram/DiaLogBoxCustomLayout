using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTheForeignKeyInCommentVoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentVote_Blogs_BlogId",
                table: "CommentVote");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "CommentVote",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentVote_BlogId",
                table: "CommentVote",
                newName: "IX_CommentVote_CommentId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43361cac-dee2-4a01-8359-43336989ad78", new DateTime(2024, 5, 6, 0, 36, 18, 48, DateTimeKind.Local).AddTicks(6121), "AQAAAAIAAYagAAAAEF8EfZA6K5+vGtEuzym3Z6g/JEFdpbftpOMkzeWXc04DpvIuTtIpwqEjULh3srZRlw==", "0f995936-c4f1-453e-83d7-1374b8495d41" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentVote_Comment_CommentId",
                table: "CommentVote",
                column: "CommentId",
                principalTable: "Comment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentVote_Comment_CommentId",
                table: "CommentVote");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CommentVote",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentVote_CommentId",
                table: "CommentVote",
                newName: "IX_CommentVote_BlogId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eabd0987-4877-44e8-aa5e-c092f507d779", new DateTime(2024, 5, 6, 0, 16, 50, 413, DateTimeKind.Local).AddTicks(4211), "AQAAAAIAAYagAAAAECeW0HVtWAd62tbK3g0Y4fLhNlRXYnJo0fas+Rg3ArXowm/qPRSjwRXmTuegcUlz8Q==", "b0d1a2fe-1e93-4112-bdd3-cadba7e19b47" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommentVote_Blogs_BlogId",
                table: "CommentVote",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }
    }
}
