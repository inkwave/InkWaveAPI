using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inkwave.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addItemCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_SubDescription_SubDescriptionId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDescription",
                table: "SubDescription");

            migrationBuilder.RenameTable(
                name: "SubDescription",
                newName: "SubDescriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDescriptions",
                table: "SubDescriptions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CategoryId",
                table: "ItemCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_ItemId",
                table: "ItemCategories",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SubDescriptions_SubDescriptionId",
                table: "Items",
                column: "SubDescriptionId",
                principalTable: "SubDescriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_SubDescriptions_SubDescriptionId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDescriptions",
                table: "SubDescriptions");

            migrationBuilder.RenameTable(
                name: "SubDescriptions",
                newName: "SubDescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDescription",
                table: "SubDescription",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_SubDescription_SubDescriptionId",
                table: "Items",
                column: "SubDescriptionId",
                principalTable: "SubDescription",
                principalColumn: "Id");
        }
    }
}
