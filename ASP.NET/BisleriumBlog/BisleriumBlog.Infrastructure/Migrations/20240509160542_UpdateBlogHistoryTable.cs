using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BisleriumBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBlogHistoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogVoteHistory_AspNetUsers_UserId",
                table: "BlogVoteHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogVoteHistory",
                table: "BlogVoteHistory");

            migrationBuilder.RenameTable(
                name: "BlogVoteHistory",
                newName: "BlogHistory");

            migrationBuilder.RenameIndex(
                name: "IX_BlogVoteHistory_UserId",
                table: "BlogHistory",
                newName: "IX_BlogHistory_UserId");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogHistory",
                table: "BlogHistory",
                column: "BlogHistoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29b1f88e-0d47-444b-bb10-3c53dc261046", "AQAAAAIAAYagAAAAENqgCE67WfsvEmWG0NiM5BVdVF4h/s+IRAQ1zp8SsA4+oULuSMgkL9zXxTxO4GGiFA==", "e6310195-e17f-4858-babc-6db7aa039ccf" });

            migrationBuilder.CreateIndex(
                name: "IX_BlogHistory_BlogId",
                table: "BlogHistory",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogHistory_AspNetUsers_UserId",
                table: "BlogHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogHistory_Blogs_BlogId",
                table: "BlogHistory",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogHistory_AspNetUsers_UserId",
                table: "BlogHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogHistory_Blogs_BlogId",
                table: "BlogHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogHistory",
                table: "BlogHistory");

            migrationBuilder.DropIndex(
                name: "IX_BlogHistory_BlogId",
                table: "BlogHistory");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogHistory");

            migrationBuilder.RenameTable(
                name: "BlogHistory",
                newName: "BlogVoteHistory");

            migrationBuilder.RenameIndex(
                name: "IX_BlogHistory_UserId",
                table: "BlogVoteHistory",
                newName: "IX_BlogVoteHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogVoteHistory",
                table: "BlogVoteHistory",
                column: "BlogHistoryId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6a130ed-a2d1-496a-a332-6f99c565a0cc", "AQAAAAIAAYagAAAAEHpHRA07qGdFbnauYzPkOmEr44KY8TVbA3UOL03clq5/v4Xn8DxAolwnKxhdnXTBRA==", "1324492b-a26d-495e-99b6-c44c48908bc2" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogVoteHistory_AspNetUsers_UserId",
                table: "BlogVoteHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
