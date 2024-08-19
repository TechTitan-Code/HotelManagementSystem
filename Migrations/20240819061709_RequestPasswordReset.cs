using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RequestPasswordReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf6a9043-d510-48ff-a63b-374ab1dc3965");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "672f53aa-2f02-4e98-be74-aee1657798e4", "fde3a93f-32d8-4a03-9d04-dd0db1efa14f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "672f53aa-2f02-4e98-be74-aee1657798e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fde3a93f-32d8-4a03-9d04-dd0db1efa14f");

            migrationBuilder.CreateTable(
                name: "RequestPasswordResets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResetCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPasswordResets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26a2e35b-5e2e-41e7-afe2-050bc2166a20", null, "Admin", "ADMIN" },
                    { "cb448f04-4f8d-4f7d-bb2b-b869161b125a", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AgeRange", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "a6cef9b3-e93a-4890-8888-18ecbb29d952", 0, null, "20-40", "28a1b78a-722c-4815-8b51-c5e9d3312c9a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, "Ahmad", 1, "oseni", false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEK9k4NvkNX4efoq5oG9stA3nBR12ct8auwI1LRgGfaR4lwlVjXTLyenby5oQAhbJqQ==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "26a2e35b-5e2e-41e7-afe2-050bc2166a20", "a6cef9b3-e93a-4890-8888-18ecbb29d952" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestPasswordResets");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb448f04-4f8d-4f7d-bb2b-b869161b125a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "26a2e35b-5e2e-41e7-afe2-050bc2166a20", "a6cef9b3-e93a-4890-8888-18ecbb29d952" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26a2e35b-5e2e-41e7-afe2-050bc2166a20");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a6cef9b3-e93a-4890-8888-18ecbb29d952");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "672f53aa-2f02-4e98-be74-aee1657798e4", null, "Admin", "ADMIN" },
                    { "bf6a9043-d510-48ff-a63b-374ab1dc3965", null, "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "AgeRange", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "fde3a93f-32d8-4a03-9d04-dd0db1efa14f", 0, null, "20-40", "495cc9e2-a3d8-4e39-9aa1-5b8cd62aeea6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, "Ahmad", 1, "oseni", false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEKY6IGorvskhw8Cfp0n+f7MUQfimwd3iUkvrxVfvc/v5K4zByf7dv7mw6msaaKOYjA==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "672f53aa-2f02-4e98-be74-aee1657798e4", "fde3a93f-32d8-4a03-9d04-dd0db1efa14f" });
        }
    }
}
