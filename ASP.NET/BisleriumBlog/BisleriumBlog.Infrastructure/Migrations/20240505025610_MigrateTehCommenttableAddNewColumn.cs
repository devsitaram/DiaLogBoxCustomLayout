using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateTehCommenttableAddNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldComments",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2783f2d-d6cb-4dee-a1f8-8a75368faaba", new DateTime(2024, 5, 5, 8, 41, 9, 480, DateTimeKind.Local).AddTicks(953), "AQAAAAIAAYagAAAAEL3YdwRMN3Mfez1OneTEIJdrXg/MtUgrWoa1oMft/PWtkyX2kSnORsLS1RBf2CQO6Q==", "23aa95f0-7127-4e86-8aa0-b890e49cd027" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldComments",
                table: "Comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d521601c-6fd5-4088-8dc4-fc8c7fb885e0", new DateTime(2024, 5, 5, 7, 30, 29, 121, DateTimeKind.Local).AddTicks(8723), "AQAAAAIAAYagAAAAEBO/F3a1U2vfNL8ACZmTDqXm8W1AZifCYFCSdhZFaXchgMz0VsBzT8pHgVRjD6poJQ==", "fc545165-a4ea-4500-bb54-0e1b15309ab7" });
        }
    }
}
