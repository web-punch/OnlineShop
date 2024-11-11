using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f4fc2bc-d353-45b2-a73a-7dbbbda0a863"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53918275-abf5-49f0-944e-437c6c4dca79"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6d185bf4-2af8-4dfb-8fa6-c711d5fe6493"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("78f016cc-5363-4d8a-9aa9-d226fcfdfd2b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eae853bf-a139-41f6-9ff4-786756698746"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef27a19a-6b24-48b6-94a0-6c71bed7e2ea"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("05eaa658-703f-45dc-be1d-b463aed81b23"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", "Хризантемы" },
                    { new Guid("0a1c03af-c62d-4685-ac4f-b5351a22cffa"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", "Пионы" },
                    { new Guid("45b2ad3f-ec09-406b-8504-6a4c8122e0b1"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", "Тюльпаны" },
                    { new Guid("e6772fb2-b0a3-4e47-8dbe-627704cbd264"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", "Ромашки" },
                    { new Guid("ec679bae-5dda-406c-a9ff-d4d44345e745"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", "Гвоздики" },
                    { new Guid("faa7ba4e-8c88-4073-ade7-afa84e7b0a9f"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", "Розы" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05eaa658-703f-45dc-be1d-b463aed81b23"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a1c03af-c62d-4685-ac4f-b5351a22cffa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("45b2ad3f-ec09-406b-8504-6a4c8122e0b1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e6772fb2-b0a3-4e47-8dbe-627704cbd264"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec679bae-5dda-406c-a9ff-d4d44345e745"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("faa7ba4e-8c88-4073-ade7-afa84e7b0a9f"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Carts");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Favorites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("2f4fc2bc-d353-45b2-a73a-7dbbbda0a863"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", "Ромашки" },
                    { new Guid("53918275-abf5-49f0-944e-437c6c4dca79"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", "Тюльпаны" },
                    { new Guid("6d185bf4-2af8-4dfb-8fa6-c711d5fe6493"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", "Пионы" },
                    { new Guid("78f016cc-5363-4d8a-9aa9-d226fcfdfd2b"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", "Хризантемы" },
                    { new Guid("eae853bf-a139-41f6-9ff4-786756698746"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", "Розы" },
                    { new Guid("ef27a19a-6b24-48b6-94a0-6c71bed7e2ea"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", "Гвоздики" }
                });
        }
    }
}
