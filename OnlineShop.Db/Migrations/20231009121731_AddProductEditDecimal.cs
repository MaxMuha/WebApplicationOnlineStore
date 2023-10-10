using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddProductEditDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ba15a7d-5006-4751-8d99-26e2848cb868"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e01ba2c-5a61-42fe-af6f-c1a9282f0303"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9ebbb7a0-3ca1-4930-b27d-2cba3915d415"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aa890c35-7d87-4c2f-8ce6-ce7706e312df"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "Products",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImgLink", "Name" },
                values: new object[,]
                {
                    { new Guid("0ba15a7d-5006-4751-8d99-26e2848cb868"), 2550m, "Активное шумоподавление и Прозрачный режим", "/image/Prod/laptop.png", "Ноутбук" },
                    { new Guid("4e01ba2c-5a61-42fe-af6f-c1a9282f0303"), 1990m, "Пространственное аудио и функция динамического отслеживания движений головы", "/image/Prod/headphones.png", "Наушники" },
                    { new Guid("9ebbb7a0-3ca1-4930-b27d-2cba3915d415"), 1590m, "Никаких проводов. Никаких сложностей. Чистая магия.", "/image/Prod/audiobox.png", "Колонка" },
                    { new Guid("aa890c35-7d87-4c2f-8ce6-ce7706e312df"), 5900m, "До 20 часов прослушивания аудио без подзарядки", "/image/Prod/watch.png", "Часы" }
                });
        }
    }
}
