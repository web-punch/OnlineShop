using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
