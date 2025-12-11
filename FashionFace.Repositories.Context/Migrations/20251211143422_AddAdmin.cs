using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FashionFace.Repositories.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[]
                {
                    "Id",
                    "PhoneNumberConfirmed",
                    "TwoFactorEnabled",
                    "LockoutEnabled",
                    "UserName",
                    "NormalizedUserName",
                    "Email",
                    "NormalizedEmail",
                    "EmailConfirmed",
                    "PasswordHash",
                    "SecurityStamp",
                    "ConcurrencyStamp",
                    "AccessFailedCount"
                },
                values: new object[]
                {
                    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                    false,
                    false,
                    false,
                    "admin",
                    "ADMIN",
                    "admin@ff.ai",
                    "ADMIN@FF.AI",
                    true,
                    "AQAAAAIAAYagAAAAEHkoECCwkPGF2Vo+LK5oK8M5T+eXEvq9AZSjcatpvaetuCz201hL1HoStlA0g6oovQ==",
                    "U647ST5RBQF2T2AEZ7JBOOEXW5PCMYBP",
                    "f47ac10b-58cc-4372-a567-0e02b2c3d479",
                    0
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "UserName",
                keyValue: "admin"
            );
        }
    }
}