using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddProductEditId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e8ebac6-fb3f-4ea2-9dbf-f1030bf520b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d00185ea-1d2c-4ecf-91b4-9b96bb239b09"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee5dd161-4cc0-4cfd-b29d-747ca36f87e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fffe889f-6819-4e92-8a25-9595997d1728"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6e8ebac6-fb3f-4ea2-9dbf-f1030bf520b5"), 1990m, "Пространственное аудио и функция динамического отслеживания движений головы", "/image/Prod/headphones.png", "Наушники" },
                    { new Guid("d00185ea-1d2c-4ecf-91b4-9b96bb239b09"), 5900m, "До 20 часов прослушивания аудио без подзарядки", "/image/Prod/watch.png", "Часы" },
                    { new Guid("ee5dd161-4cc0-4cfd-b29d-747ca36f87e7"), 2550m, "Активное шумоподавление и Прозрачный режим", "/image/Prod/laptop.png", "Ноутбук" },
                    { new Guid("fffe889f-6819-4e92-8a25-9595997d1728"), 1590m, "Никаких проводов. Никаких сложностей. Чистая магия.", "/image/Prod/audiobox.png", "Колонка" }
                });
        }
    }
}
