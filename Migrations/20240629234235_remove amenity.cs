using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class removeamenity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Amenities_AmenitiesId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dff78acd-e5df-4200-b511-d50cbedd4333", "3d74411d-2982-4db9-a469-cc5c706a3cdb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dff78acd-e5df-4200-b511-d50cbedd4333");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d74411d-2982-4db9-a469-cc5c706a3cdb");

            migrationBuilder.RenameColumn(
                name: "AmenitiesId",
                table: "Rooms",
                newName: "AmenityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_AmenitiesId",
                table: "Rooms",
                newName: "IX_Rooms_AmenityId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb0ea989-3765-4609-a67a-ac1f50e81e2a", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "50f66729-61d6-4057-bada-dbcdcce90fab", 0, null, "09846967-72da-4c57-8674-2e4fccbb1edf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, 1, false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEGp22bek7TuHZ/Lcf/4+ZMJa8ME3og7Ku12NJiRzxRyAKE3QZ8nNx6sK+qM3hcgVcA==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fb0ea989-3765-4609-a67a-ac1f50e81e2a", "50f66729-61d6-4057-bada-dbcdcce90fab" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Amenities_AmenityId",
                table: "Rooms",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Amenities_AmenityId",
                table: "Rooms");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fb0ea989-3765-4609-a67a-ac1f50e81e2a", "50f66729-61d6-4057-bada-dbcdcce90fab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb0ea989-3765-4609-a67a-ac1f50e81e2a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50f66729-61d6-4057-bada-dbcdcce90fab");

            migrationBuilder.RenameColumn(
                name: "AmenityId",
                table: "Rooms",
                newName: "AmenitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_AmenityId",
                table: "Rooms",
                newName: "IX_Rooms_AmenitiesId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dff78acd-e5df-4200-b511-d50cbedd4333", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedTime", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedTime", "UserName", "UserRole" },
                values: new object[] { "3d74411d-2982-4db9-a469-cc5c706a3cdb", 0, null, "aec1605e-4dfb-4acf-a3b0-4b5722023fbb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@gmail.com", true, 1, false, null, "Ahmad Korede", "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEGq2lN9bTTJtUdCPNMUE50Zmi+NvySuzKmVUzROtLJBVWovG/RZ6S17p23QjZjM4Xg==", null, false, "", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dff78acd-e5df-4200-b511-d50cbedd4333", "3d74411d-2982-4db9-a469-cc5c706a3cdb" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Amenities_AmenitiesId",
                table: "Rooms",
                column: "AmenitiesId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
