using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inkwave.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "SubDescriptions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SubDescriptions");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Favourites");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Users",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Items",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "DeletedOn",
                table: "Categories",
                newName: "DeletedDate");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Users",
                newName: "DeletedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Items",
                newName: "DeletedOn");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Categories",
                newName: "DeletedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "SubDescriptions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SubDescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ItemCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ItemCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Favourites",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Favourites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
