using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddProductEditIdGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42ecb8a6-e766-4eac-ad42-a5d292b07d3e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a480a3d7-e460-4e31-a431-e5c06571774b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b053fc8b-9f4b-4e27-9610-4564ddef3f31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd0e2bc3-7682-43fb-8527-257832056fe9"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImgLink", "Name" },
                values: new object[,]
                {
                    { new Guid("0acf910a-0432-4798-937b-32dbbf5f8bd2"), 2550m, "Активное шумоподавление и Прозрачный режим", "/image/Prod/laptop.png", "Ноутбук" },
                    { new Guid("382ccf9d-e694-46ee-a498-e53c35115ffb"), 5900m, "До 20 часов прослушивания аудио без подзарядки", "/image/Prod/watch.png", "Часы" },
                    { new Guid("773c2712-f8fe-4e97-b7f0-e8b79f0bbbbb"), 1590m, "Никаких проводов. Никаких сложностей. Чистая магия.", "/image/Prod/audiobox.png", "Колонка" },
                    { new Guid("99f439e2-65e0-4042-98d5-89352223f076"), 1990m, "Пространственное аудио и функция динамического отслеживания движений головы", "/image/Prod/headphones.png", "Наушники" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0acf910a-0432-4798-937b-32dbbf5f8bd2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("382ccf9d-e694-46ee-a498-e53c35115ffb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("773c2712-f8fe-4e97-b7f0-e8b79f0bbbbb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99f439e2-65e0-4042-98d5-89352223f076"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImgLink", "Name" },
                values: new object[,]
                {
                    { new Guid("42ecb8a6-e766-4eac-ad42-a5d292b07d3e"), 1590m, "Никаких проводов. Никаких сложностей. Чистая магия.", "/image/Prod/audiobox.png", "Колонка" },
                    { new Guid("a480a3d7-e460-4e31-a431-e5c06571774b"), 1990m, "Пространственное аудио и функция динамического отслеживания движений головы", "/image/Prod/headphones.png", "Наушники" },
                    { new Guid("b053fc8b-9f4b-4e27-9610-4564ddef3f31"), 2550m, "Активное шумоподавление и Прозрачный режим", "/image/Prod/laptop.png", "Ноутбук" },
                    { new Guid("dd0e2bc3-7682-43fb-8527-257832056fe9"), 5900m, "До 20 часов прослушивания аудио без подзарядки", "/image/Prod/watch.png", "Часы" }
                });
        }
    }
}
