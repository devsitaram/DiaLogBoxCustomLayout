using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReactColumnAddInCommentVoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReact",
                table: "CommentVote",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eabd0987-4877-44e8-aa5e-c092f507d779", new DateTime(2024, 5, 6, 0, 16, 50, 413, DateTimeKind.Local).AddTicks(4211), "AQAAAAIAAYagAAAAECeW0HVtWAd62tbK3g0Y4fLhNlRXYnJo0fas+Rg3ArXowm/qPRSjwRXmTuegcUlz8Q==", "b0d1a2fe-1e93-4112-bdd3-cadba7e19b47" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReact",
                table: "CommentVote");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22ba68b5-3f21-42a8-a3ae-3ca99e13abb9", new DateTime(2024, 5, 5, 23, 23, 26, 547, DateTimeKind.Local).AddTicks(9765), "AQAAAAIAAYagAAAAECsHanoauUtSiDeY5CZhzf86l7P/4DioOgh+SMIlSok0V7leaj6X5t+kxcyqTgx8pg==", "9034c24b-7a2e-40a3-b0f0-ffed3829fb31" });
        }
    }
}
