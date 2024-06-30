using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Amenities_AmenityId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_AmenityId",
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

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "Rooms");

            migrationBuilder.AddColumn<Guid>(
                name: "RoomId",
                table: "Amenities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SelectAmenity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmenityNameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectAmenity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectAmenity_Amenities_AmenityNameId",
                        column: x => x.AmenityNameId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectAmenity_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectAmenity_AmenityNameId",
                table: "SelectAmenity",
                column: "AmenityNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectAmenity_RoomId",
                table: "SelectAmenity",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amenities_Rooms_RoomId",
                table: "Amenities");

            migrationBuilder.DropTable(
                name: "SelectAmenity");

            migrationBuilder.DropIndex(
                name: "IX_Amenities_RoomId",
                table: "Amenities");

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

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Amenities");

            migrationBuilder.AddColumn<Guid>(
                name: "AmenityId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AmenityId",
                table: "Rooms",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Amenities_AmenityId",
                table: "Rooms",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
