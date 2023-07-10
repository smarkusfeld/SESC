using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentService.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevisedContainedAward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContainedAwards_Awards_AwardId1",
                table: "ContainedAwards");

            migrationBuilder.RenameColumn(
                name: "AwardId1",
                table: "ContainedAwards",
                newName: "AwardId");

            migrationBuilder.RenameIndex(
                name: "IX_ContainedAwards_AwardId1",
                table: "ContainedAwards",
                newName: "IX_ContainedAwards_AwardId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainedAwards_Awards_AwardId",
                table: "ContainedAwards",
                column: "AwardId",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContainedAwards_Awards_AwardId",
                table: "ContainedAwards");

            migrationBuilder.RenameColumn(
                name: "AwardId",
                table: "ContainedAwards",
                newName: "AwardId1");

            migrationBuilder.RenameIndex(
                name: "IX_ContainedAwards_AwardId",
                table: "ContainedAwards",
                newName: "IX_ContainedAwards_AwardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainedAwards_Awards_AwardId1",
                table: "ContainedAwards",
                column: "AwardId1",
                principalTable: "Awards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
