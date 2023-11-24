using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inkwave.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Printing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Prints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ConfirmedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BindingOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrintingColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrintingLayout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrintingSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverBgSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPositionX = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverPositionY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverRepeat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverZoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prints", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prints_UserId",
                table: "Prints",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prints");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");
        }
    }
}
