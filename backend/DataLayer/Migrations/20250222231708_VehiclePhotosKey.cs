using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class VehiclePhotosKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePhotos_Vehicles_VehicleId",
                table: "VehiclePhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePhotos_Vehicles_VehicleId",
                table: "VehiclePhotos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePhotos_Vehicles_VehicleId",
                table: "VehiclePhotos");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePhotos_Vehicles_VehicleId",
                table: "VehiclePhotos",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
