using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePhotosTab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "VehiclePhotos");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "VehiclePhotos",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "VehiclePhotos",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "VehiclePhotos",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
