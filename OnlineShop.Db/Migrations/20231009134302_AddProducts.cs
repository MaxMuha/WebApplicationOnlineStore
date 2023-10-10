using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("5fccf0db-7178-4102-9721-6194bf67824f"), 1990m, "Пространственное аудио и функция динамического отслеживания движений головы", "/image/Prod/headphones.png", "Наушники" },
                    { new Guid("94c4f253-9838-44a5-97bb-6bf08ffa8011"), 1590m, "Никаких проводов. Никаких сложностей. Чистая магия.", "/image/Prod/audiobox.png", "Колонка" },
                    { new Guid("e049685d-0511-44e0-8b8f-5f28c21d8034"), 5900m, "До 20 часов прослушивания аудио без подзарядки", "/image/Prod/watch.png", "Часы" },
                    { new Guid("e5cbe12b-3a08-43fd-a2d1-f71ea9ad0fc0"), 2550m, "Активное шумоподавление и Прозрачный режим", "/image/Prod/laptop.png", "Ноутбук" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5fccf0db-7178-4102-9721-6194bf67824f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("94c4f253-9838-44a5-97bb-6bf08ffa8011"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e049685d-0511-44e0-8b8f-5f28c21d8034"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5cbe12b-3a08-43fd-a2d1-f71ea9ad0fc0"));

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
    }
}
