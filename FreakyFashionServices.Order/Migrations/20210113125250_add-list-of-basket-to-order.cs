using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyFashionServices.Order.Migrations
{
    public partial class addlistofbaskettoorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Basket",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basket",
                table: "Order");
        }
    }
}
