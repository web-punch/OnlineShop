using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductModel_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("175ee3b4-5064-4a1e-a272-0b0d741c7829"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("756795c8-d812-4e3f-be04-c274b8c44da5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86a0f74c-8b5b-4c1c-94b0-218d3728a4b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8df0a7ef-ac9c-42a5-8203-42cecd57a2f2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("98b4dfd6-95d5-4793-b0b8-f42862fd3a4a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1e3fee7-2cd7-4fe2-b83e-8a8ad501dfca"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ActiveIndexImagePath",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ActiveIndexImagePath", "Cost", "Description", "ImagesPaths", "Name" },
                values: new object[,]
                {
                    { new Guid("17579376-79a4-44f6-a7e6-c8318055dfd2"), 0, 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/peonies.jpg\"]", "Пионы" },
                    { new Guid("2a45a15f-40a7-4575-a068-c6078bbd0895"), 0, 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/tulips.jpg\"]", "Тюльпаны" },
                    { new Guid("59a54717-9a71-4242-96ad-5d77b7635006"), 0, 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/chamomiles.jpg\"]", "Ромашки" },
                    { new Guid("9a85d68b-e789-4c15-9c3c-2acccb74e807"), 0, 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/roses.jpg\"]", "Розы" },
                    { new Guid("9f5c21f1-ce6d-4951-86b2-75d0faa91154"), 0, 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/chrysanthemums.jpg\"]", "Хризантемы" },
                    { new Guid("f436396c-d2e1-4ca7-b9d0-840adfef2281"), 0, 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "[\"/images/carnations.jpg\"]", "Гвоздики" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17579376-79a4-44f6-a7e6-c8318055dfd2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a45a15f-40a7-4575-a068-c6078bbd0895"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59a54717-9a71-4242-96ad-5d77b7635006"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a85d68b-e789-4c15-9c3c-2acccb74e807"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f5c21f1-ce6d-4951-86b2-75d0faa91154"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f436396c-d2e1-4ca7-b9d0-840adfef2281"));

            migrationBuilder.DropColumn(
                name: "ActiveIndexImagePath",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "ImagesPaths", "Name" },
                values: new object[,]
                {
                    { new Guid("175ee3b4-5064-4a1e-a272-0b0d741c7829"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", "[]", "Гвоздики" },
                    { new Guid("756795c8-d812-4e3f-be04-c274b8c44da5"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", "[]", "Тюльпаны" },
                    { new Guid("86a0f74c-8b5b-4c1c-94b0-218d3728a4b7"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", "[]", "Розы" },
                    { new Guid("8df0a7ef-ac9c-42a5-8203-42cecd57a2f2"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", "[]", "Ромашки" },
                    { new Guid("98b4dfd6-95d5-4793-b0b8-f42862fd3a4a"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", "[]", "Хризантемы" },
                    { new Guid("d1e3fee7-2cd7-4fe2-b83e-8a8ad501dfca"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", "[]", "Пионы" }
                });
        }
    }
}
