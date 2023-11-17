using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inkwave.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateEntitit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Canceled_at",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ShippingAddressId",
                table: "Orders",
                newName: "PaymentMethodId");

            migrationBuilder.RenameColumn(
                name: "BillingAddressId",
                table: "Orders",
                newName: "AddressId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCashOnDelivery",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OrderLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsCashOnDelivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodId",
                table: "Orders",
                newName: "ShippingAddressId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Orders",
                newName: "BillingAddressId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Canceled_at",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
