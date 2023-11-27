using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRequiredKeysFromVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Categories_CategoryID",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Vehicles",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CategoryID",
                table: "Vehicles",
                newName: "IX_Vehicles_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Categories_CategoryId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Vehicles",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                newName: "IX_Vehicles_CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Categories_CategoryID",
                table: "Vehicles",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
