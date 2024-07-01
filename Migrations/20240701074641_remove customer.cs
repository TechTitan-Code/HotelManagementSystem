using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class removecustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4ac3fa11-e8ad-4ccb-8523-179d0e285eec", "7d8b2a52-5398-4adf-96a4-77cd8173aaf4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ac3fa11-e8ad-4ccb-8523-179d0e285eec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d8b2a52-5398-4adf-96a4-77cd8173aaf4");

            migrationBuilder.AddColumn<string>(
                name: "AgeRange",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ec623e4-a47d-4359-a95a-04dee091f432", null, "Admin", "ADMIN" },
                    { "adf9ce7b-1a9b-43c7-8b16-61ab0d3fd519", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AgeRange", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "0f8be855-3846-4310-9779-06cc4aeff60e", 0, null, "20-40", "56b0899c-3763-48a9-a2e9-5c7f0ccd8393", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, 1, false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJhFKnZnFuhfVr4ud+StSl0cG2aIosNECRcDzw/6EGlQLDkI0Ujeia6qz9RvbjEHtw==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0ec623e4-a47d-4359-a95a-04dee091f432", "0f8be855-3846-4310-9779-06cc4aeff60e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf9ce7b-1a9b-43c7-8b16-61ab0d3fd519");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0ec623e4-a47d-4359-a95a-04dee091f432", "0f8be855-3846-4310-9779-06cc4aeff60e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ec623e4-a47d-4359-a95a-04dee091f432");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f8be855-3846-4310-9779-06cc4aeff60e");

            migrationBuilder.DropColumn(
                name: "AgeRange",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ac3fa11-e8ad-4ccb-8523-179d0e285eec", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "7d8b2a52-5398-4adf-96a4-77cd8173aaf4", 0, null, "fba4dc9a-4363-4f1d-8e9b-0b10297c9c67", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, 1, false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEJmixR/EHz/ANr7Fiaao/EiIWnI3ZqRoZ7/NNeyceosGpv/qB4/BQRoFlH9q7e2PgA==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4ac3fa11-e8ad-4ccb-8523-179d0e285eec", "7d8b2a52-5398-4adf-96a4-77cd8173aaf4" });
        }
    }
}
