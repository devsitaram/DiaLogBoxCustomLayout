using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewConnectionIdRowAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "ConnectionId", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cc6f68b-9bb5-48ef-9f74-0e5fe9ac6491", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEOPhijaHn1VwewGb4teGUKOgmwcfVkc+BXQfF8c8k8TUwtBJLB5SkA+8V3DHYG/Pgg==", "bc953d0a-4ca8-4272-8f34-879a40adf1f5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "606a9531-cf61-4d25-8369-9b43745dc85a", new DateTime(2024, 5, 6, 9, 0, 25, 681, DateTimeKind.Local).AddTicks(9879), "AQAAAAIAAYagAAAAENZjM0NLkBZ8eRhxvMdq/vSN9tak/hfOZ3XS8s4WlUWlMBmkHL+K3HBPlxIPro8EOA==", "3ce5dbfe-b967-49d5-b8e2-5d2b74b1985a" });
        }
    }
}
