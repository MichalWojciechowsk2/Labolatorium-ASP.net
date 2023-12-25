using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "62856f9f-d609-44ef-bcd4-9794512d2f4b");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "aab44565-0cff-475b-a95d-1bd6f8384347");

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62856f9f-d609-44ef-bcd4-9794512d2f4b", "aab44565-0cff-475b-a95d-1bd6f8384347" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "449e17be-8426-42d1-a2ed-d6d173d0f21f", "449e17be-8426-42d1-a2ed-d6d173d0f21f", "admin", "ADMIN" },
                    { "5269290e-0a30-42e6-bbe6-314a1a795ace", "5269290e-0a30-42e6-bbe6-314a1a795ace", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "79eea5c7-7901-462d-acaf-b65aeaa2952b", 0, "e6047b41-d410-4187-8feb-9d5ded7955e4", "jan@wsei.edu.pl", true, false, null, null, "JAN", "AQAAAAIAAYagAAAAEOlZmJqt0n+y2X1k4NxCPxDU4I/IgGCSG9ZuyBA7gVSwHd/hL39wey2IIjx8fUPaNQ==", null, false, "d5b8797c-00f6-425d-9696-6445e0df37b2", false, "jan" },
                    { "e98bf167-f86c-458a-80f2-d7aaa19338dc", 0, "dc0aa053-efd7-4586-8af9-07b76f1cb220", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEPA+NhsPZuj8PohRmhY0DOWhCcEtPdDMqowEialS64N/eMiNOp2jfvCGhk7X9YpCIA==", null, false, "db75722f-bf3d-4f58-ae5f-5501177caa50", false, "adam" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5269290e-0a30-42e6-bbe6-314a1a795ace", "79eea5c7-7901-462d-acaf-b65aeaa2952b" },
                    { "449e17be-8426-42d1-a2ed-d6d173d0f21f", "e98bf167-f86c-458a-80f2-d7aaa19338dc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "449e17be-8426-42d1-a2ed-d6d173d0f21f");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5269290e-0a30-42e6-bbe6-314a1a795ace");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "79eea5c7-7901-462d-acaf-b65aeaa2952b");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "e98bf167-f86c-458a-80f2-d7aaa19338dc");

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5269290e-0a30-42e6-bbe6-314a1a795ace", "79eea5c7-7901-462d-acaf-b65aeaa2952b" });

            migrationBuilder.DeleteData(
                table: "IdentityUserRole<string>",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "449e17be-8426-42d1-a2ed-d6d173d0f21f", "e98bf167-f86c-458a-80f2-d7aaa19338dc" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "62856f9f-d609-44ef-bcd4-9794512d2f4b", "62856f9f-d609-44ef-bcd4-9794512d2f4b", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "aab44565-0cff-475b-a95d-1bd6f8384347", 0, "e7f508a1-2f66-48ce-9135-29949334b67b", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAECmsfqIRc+qi7DnE2BWaVfywLZc/HP4DjBSEJk2Cxg44a2anqo1DgKZdobm1Ss8LgQ==", null, false, "75750e2f-c2d8-4991-9c5e-52c87fdda0d5", false, "adam" });

            migrationBuilder.InsertData(
                table: "IdentityUserRole<string>",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "62856f9f-d609-44ef-bcd4-9794512d2f4b", "aab44565-0cff-475b-a95d-1bd6f8384347" });
        }
    }
}
