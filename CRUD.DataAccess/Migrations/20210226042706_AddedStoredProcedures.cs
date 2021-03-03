using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.DataAccess.Migrations
{
    public partial class AddedStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE SelectCountryCustomer @Country nvarchar(20)
                AS 
                BEGIN
                SELECT * FROM Customer WHERE Country = @Country
                END
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE GetAllCustomer
                AS 
                BEGIN
                SELECT * FROM Customer
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE SelectCountryCustomer");
            migrationBuilder.Sql(@"DROP PROCEDURE GetAllCustomer");
        }
    }
}
