using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DataAccess.Migrations
{
    public partial class AddedRolesToIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f690c63-229b-4d77-bad0-d84112e31693", "1f856f46-3251-423d-901d-6a8f34029315", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa24fd72-c5ee-4d04-a7cf-9230862f45e8", "70f636d3-d404-477b-af60-66186f45d164", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f690c63-229b-4d77-bad0-d84112e31693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa24fd72-c5ee-4d04-a7cf-9230862f45e8");
        }
    }
}
