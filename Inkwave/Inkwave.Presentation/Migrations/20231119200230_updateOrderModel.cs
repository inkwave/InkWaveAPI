using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inkwave.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CanceledDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProblemDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReturnedDescription",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledDescription",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProblemDescription",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReturnedDescription",
                table: "Orders");
        }
    }
}
