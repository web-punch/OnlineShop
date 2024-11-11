using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Migration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01503178-2f5f-4712-aaf7-e7ee6fb62823"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bf3107f3-5028-4a1c-8706-7b1cb728bf26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d5460e28-5f18-4bb8-a55c-5a4a3b885c51"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef1833fa-c266-47a4-9d70-5c71b448f896"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f5ab854b-366f-49f0-bc97-5cb951be556e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f6ca1c5c-5cba-4f61-a0a1-e1330e60838b"));

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Products",
                newName: "ImagePath");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { new Guid("01503178-2f5f-4712-aaf7-e7ee6fb62823"), 150m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chamomiles.jpg", "Ромашки" },
                    { new Guid("bf3107f3-5028-4a1c-8706-7b1cb728bf26"), 400m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/roses.jpg", "Розы" },
                    { new Guid("d5460e28-5f18-4bb8-a55c-5a4a3b885c51"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/peonies.jpg", "Пионы" },
                    { new Guid("ef1833fa-c266-47a4-9d70-5c71b448f896"), 200m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/tulips.jpg", "Тюльпаны" },
                    { new Guid("f5ab854b-366f-49f0-bc97-5cb951be556e"), 250m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/carnations.jpg", "Гвоздики" },
                    { new Guid("f6ca1c5c-5cba-4f61-a0a1-e1330e60838b"), 300m, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean ex turpis, finibus vitae volutpat eu, gravida vitae felis. Etiam sed.", "/images/chrysanthemums.jpg", "Хризантемы" }
                });
        }
    }
}
