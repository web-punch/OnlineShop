using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductModel_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4159e611-e41b-49fa-bfb4-759301fd6df6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("567b3850-9f0b-457b-96f9-0a32189a522a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6163fa83-61f6-4c07-a177-f0049e90a435"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8aee5b29-912b-401f-b77d-05c144fa8d03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("be995b15-821f-4e72-9156-42ea0f6e7a81"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cfa284bf-ca87-48e4-86b4-6eca8ce91118"));

            migrationBuilder.AlterColumn<string>(
                name: "ImagesPaths",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ImagesPaths",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "ImagesPaths", "Name" },
                values: new object[,]
                {
                    { new Guid("4159e611-e41b-49fa-bfb4-759301fd6df6"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", null, "Гвоздики" },
                    { new Guid("567b3850-9f0b-457b-96f9-0a32189a522a"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", null, "Ромашки" },
                    { new Guid("6163fa83-61f6-4c07-a177-f0049e90a435"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", null, "Хризантемы" },
                    { new Guid("8aee5b29-912b-401f-b77d-05c144fa8d03"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", null, "Розы" },
                    { new Guid("be995b15-821f-4e72-9156-42ea0f6e7a81"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", null, "Тюльпаны" },
                    { new Guid("cfa284bf-ca87-48e4-86b4-6eca8ce91118"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", null, "Пионы" }
                });
        }
    }
}
