using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("15b01522-2f67-46e9-aac8-91a7a22378e3"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("2e7940c1-bb72-4025-bfdc-6de84fa9c3be"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("abb11b85-a2cd-40ca-b840-eff85b936463"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fa0a1275-9b45-44f4-a9e6-10fd82bd19d7", "AQAAAAEAACcQAAAAEL9ndsRAj3h+K7PnylLJwjlUv6hLHZX5DE7ED6oajvLw9A0YmU9EEKB7GQB51xirYg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cbd240e8-d578-4976-9bf2-8f8de7676954", "AQAAAAEAACcQAAAAEBajkrOg+exJceyyXtnxWndDm76REhHvSfAimlKRla1MIuwYcCQ0K3bM8wMQ4aS1Lw==" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("2c6a3d96-de5b-4a84-8f54-61f44604f3b7"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" },
                    { new Guid("7eec576d-97cd-46e9-83b9-93c681944c26"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("f2152081-8a9e-42fb-8ac8-60df7486f366"), "North London, UK (near the border)", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg", 2100.00m, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), "Big House Marina" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("2c6a3d96-de5b-4a84-8f54-61f44604f3b7"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("7eec576d-97cd-46e9-83b9-93c681944c26"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("f2152081-8a9e-42fb-8ac8-60df7486f366"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1752a0f9-6ad2-4efb-8310-1e039dd91cb8", "AQAAAAEAACcQAAAAEKY53M8FIg0kodKkFxDqVWP9UO5uYMkvRbCDuiwfF/fSs7bn3/PYCCD37xTz3dx9tQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01c17eb6-1159-4d71-9345-25d25c31d858", "AQAAAAEAACcQAAAAEITbMrAeW79Gxm2uq+RPQ4ZuJEPk0+gGJ9QOsHU5sn6kkimQCBQWU4muI1QLdbmXEA==" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[,]
                {
                    { new Guid("15b01522-2f67-46e9-aac8-91a7a22378e3"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" },
                    { new Guid("2e7940c1-bb72-4025-bfdc-6de84fa9c3be"), "North London, UK (near the border)", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.bhg.com/thmb/H9VV9JNnKl-H1faFXnPlQfNprYw=/1799x0/filters:no_upscale():strip_icc()/white-modern-house-curved-patio-archway-c0a4a3b3-aa51b24d14d0464ea15d36e05aa85ac9.jpg", 2100.00m, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), "Big House Marina" },
                    { new Guid("abb11b85-a2cd-40ca-b840-eff85b936463"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("9ef6f4e8-891e-49d3-8bad-69ff127c9951"), 3, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" }
                });
        }
    }
}
