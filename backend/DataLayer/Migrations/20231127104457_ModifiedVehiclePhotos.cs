using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedVehiclePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "VehiclePhotos");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "VehiclePhotos");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "VehiclePhotos",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Bytes",
                table: "VehiclePhotos",
                newName: "ImageData");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "VehiclePhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "VehiclePhotos");

            migrationBuilder.RenameColumn(
                name: "ImageData",
                table: "VehiclePhotos",
                newName: "Bytes");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "VehiclePhotos",
                newName: "FileExtension");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "VehiclePhotos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "VehiclePhotos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
