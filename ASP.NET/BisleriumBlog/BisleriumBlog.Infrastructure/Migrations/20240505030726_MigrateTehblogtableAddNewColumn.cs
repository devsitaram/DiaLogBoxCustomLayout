using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigrateTehblogtableAddNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OldContent",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36f331fe-d35f-44f8-8f6b-7730eee36d8f", new DateTime(2024, 5, 5, 8, 52, 26, 67, DateTimeKind.Local).AddTicks(7128), "AQAAAAIAAYagAAAAEGl33L2CJFNmsaTvT4tXqu16whENDi8KdSs40/k0fPacnEu0lUc+EdTYfWJ3ZlelmQ==", "c1da3109-fef9-42a6-b914-545570931e08" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OldContent",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2783f2d-d6cb-4dee-a1f8-8a75368faaba", new DateTime(2024, 5, 5, 8, 41, 9, 480, DateTimeKind.Local).AddTicks(953), "AQAAAAIAAYagAAAAEL3YdwRMN3Mfez1OneTEIJdrXg/MtUgrWoa1oMft/PWtkyX2kSnORsLS1RBf2CQO6Q==", "23aa95f0-7127-4e86-8aa0-b890e49cd027" });
        }
    }
}
