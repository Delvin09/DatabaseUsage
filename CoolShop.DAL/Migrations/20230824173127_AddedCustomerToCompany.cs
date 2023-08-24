using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoolShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCustomerToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Company_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
