using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialNewCommentVoteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentVote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpVote = table.Column<int>(type: "int", nullable: true),
                    DownVote = table.Column<int>(type: "int", nullable: true),
                    OldVote = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_CommentVote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentVote_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentVote_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22ba68b5-3f21-42a8-a3ae-3ca99e13abb9", new DateTime(2024, 5, 5, 23, 23, 26, 547, DateTimeKind.Local).AddTicks(9765), "AQAAAAIAAYagAAAAECsHanoauUtSiDeY5CZhzf86l7P/4DioOgh+SMIlSok0V7leaj6X5t+kxcyqTgx8pg==", "9034c24b-7a2e-40a3-b0f0-ffed3829fb31" });

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_BlogId",
                table: "CommentVote",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVote_UserId",
                table: "CommentVote",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentVote");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "CreatedTime", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e3deb9-3757-47c0-ae94-6f4e2e71c86c", new DateTime(2024, 5, 5, 23, 13, 45, 366, DateTimeKind.Local).AddTicks(3520), "AQAAAAIAAYagAAAAEOpdgnQdT91bTP5EkpXnMGoqtdeT5nftht43QxlayHoRtZzEgPxEL5WBVADZBEWrZg==", "e34d5cf8-a3a0-46a3-b105-d837f6f93d49" });
        }
    }
}
