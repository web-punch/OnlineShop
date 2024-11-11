using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("03f3d31f-fbb9-4a9a-861b-a4a323d41d66"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65843b92-8993-4cf9-b019-17666da6712f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94751d36-8ae5-4beb-a607-4d59729c976b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5b8ddbb-e573-44ed-a185-80f49cfd218c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7563821-ba14-4df5-800f-1004dcc2a3cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e73a6bab-eee9-4bcc-afbb-ccc2ad3312ba"));

            migrationBuilder.AddColumn<string>(
                name: "ImagesPaths",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImagesPaths",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("03f3d31f-fbb9-4a9a-861b-a4a323d41d66"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", "Тюльпаны" },
                    { new Guid("65843b92-8993-4cf9-b019-17666da6712f"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", "Хризантемы" },
                    { new Guid("94751d36-8ae5-4beb-a607-4d59729c976b"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", "Розы" },
                    { new Guid("a5b8ddbb-e573-44ed-a185-80f49cfd218c"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", "Ромашки" },
                    { new Guid("b7563821-ba14-4df5-800f-1004dcc2a3cb"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", "Гвоздики" },
                    { new Guid("e73a6bab-eee9-4bcc-afbb-ccc2ad3312ba"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", "Пионы" }
                });
        }
    }
}
