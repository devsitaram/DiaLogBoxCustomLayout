using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateBlogVoteReaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BlogVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpVote = table.Column<int>(type: "int", nullable: true),
                    DownVote = table.Column<int>(type: "int", nullable: true),
                    OldVote = table.Column<int>(type: "int", nullable: true),
                    BlogId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogVote_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "606a9531-cf61-4d25-8369-9b43745dc85a", new DateTime(2024, 5, 6, 9, 0, 25, 681, DateTimeKind.Local).AddTicks(9879), "AQAAAAIAAYagAAAAENZjM0NLkBZ8eRhxvMdq/vSN9tak/hfOZ3XS8s4WlUWlMBmkHL+K3HBPlxIPro8EOA==", "3ce5dbfe-b967-49d5-b8e2-5d2b74b1985a" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogVote_BlogId",
                table: "BlogVote",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogVote_UserId",
                table: "BlogVote",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogVote");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4176e008-0d21-4aae-a70b-346f83ea7886", new DateTime(2024, 5, 6, 3, 35, 40, 312, DateTimeKind.Local).AddTicks(5844), "AQAAAAIAAYagAAAAEP3IAQtAUO1LG9hTCP5xEYVdmICW9AnnlgyZSdX1zWvX3SpTdcPdgV9p8o7F4O7N5g==", "25e8c1d8-7f3f-4699-aa31-541d8176aecb" });
        }
    }
}
