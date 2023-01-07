using Microsoft.EntityFrameworkCore.Migrations;

namespace UPSchool_Observer_Design_Pattern.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Discounts",
                newName: "Rate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Discounts",
                newName: "Amount");
        }
    }
}
