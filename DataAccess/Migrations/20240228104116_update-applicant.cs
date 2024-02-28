using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateapplicant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlackList_ApplicantId",
                table: "BlackList");

            migrationBuilder.CreateIndex(
                name: "IX_BlackList_ApplicantId",
                table: "BlackList",
                column: "ApplicantId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlackList_ApplicantId",
                table: "BlackList");

            migrationBuilder.CreateIndex(
                name: "IX_BlackList_ApplicantId",
                table: "BlackList",
                column: "ApplicantId");
        }
    }
}
