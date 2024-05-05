using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableWhereRemoveTheReactColumnAndOldVoteIsStringToInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReact",
                table: "CommentVote");

            migrationBuilder.AlterColumn<int>(
                name: "OldVote",
                table: "CommentVote",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4176e008-0d21-4aae-a70b-346f83ea7886", new DateTime(2024, 5, 6, 3, 35, 40, 312, DateTimeKind.Local).AddTicks(5844), "AQAAAAIAAYagAAAAEP3IAQtAUO1LG9hTCP5xEYVdmICW9AnnlgyZSdX1zWvX3SpTdcPdgV9p8o7F4O7N5g==", "25e8c1d8-7f3f-4699-aa31-541d8176aecb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OldVote",
                table: "CommentVote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                values: new object[] { "43361cac-dee2-4a01-8359-43336989ad78", new DateTime(2024, 5, 6, 0, 36, 18, 48, DateTimeKind.Local).AddTicks(6121), "AQAAAAIAAYagAAAAEF8EfZA6K5+vGtEuzym3Z6g/JEFdpbftpOMkzeWXc04DpvIuTtIpwqEjULh3srZRlw==", "0f995936-c4f1-453e-83d7-1374b8495d41" });
        }
    }
}
