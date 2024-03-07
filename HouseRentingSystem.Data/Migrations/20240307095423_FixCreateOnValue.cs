using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class FixCreateOnValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("4443b45f-b89d-4d8d-8b56-385307311790"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("a33ef557-8d04-4938-80bc-4a9c42492af7"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("e6a3a381-7899-4fda-9058-bd67ebe9f668"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 2, 12, 41, 31, 61, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9d9d034b-afa6-44a7-8066-326942835aac", "AQAAAAEAACcQAAAAECq25JNTMV+05MjWhz7UKlEI2rkyEFntSQjx9Q4g9YRO+m1myiveogja0NOKhcn4PA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d894a3d7-5790-4a5a-8220-6d4543560428", "AQAAAAEAACcQAAAAEJPZwcBkbg93SajJsrM6N65H6ybz/HeZ/wLYpVWOGjS+5rK/0x3HKShjFcsTiTpXow==" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("1813d4c9-4c02-4031-a9b5-a8707a0f1d44"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("41f0ae34-f7d9-47d6-a574-6415f0b43240"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("92a22ae9-d21c-4c2f-b93c-7d179b5bf261"), "North London, UK (near the border)", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg", 2100.00m, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), "Big House Marina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("1813d4c9-4c02-4031-a9b5-a8707a0f1d44"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("41f0ae34-f7d9-47d6-a574-6415f0b43240"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("92a22ae9-d21c-4c2f-b93c-7d179b5bf261"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 2, 12, 41, 31, 61, DateTimeKind.Utc).AddTicks(2300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d9bc00e-ad88-4ac9-b79c-fbe6b0121f3a", "AQAAAAEAACcQAAAAEB4YeSlE64TQVvB6j9AxXszP34qNcdb5sTrxfAOZ5xnmHHrK7TGPl9xaNVBWdZ32HQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "841aec0c-d0e1-4845-b54e-40622ab18a67", "AQAAAAEAACcQAAAAEMftQlpfA9si9JmPebfznE2uaggJnES/iOVpNntycFoNC39FqjYBCKAKkPvZ2iPymA==" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreateOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("4443b45f-b89d-4d8d-8b56-385307311790"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("a33ef557-8d04-4938-80bc-4a9c42492af7"), "North London, UK (near the border)", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg", 2100.00m, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), "Big House Marina" },
                    { new Guid("e6a3a381-7899-4fda-9058-bd67ebe9f668"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" }
                });
        }
    }
}
