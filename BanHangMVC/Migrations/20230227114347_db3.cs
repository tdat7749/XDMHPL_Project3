using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BanHangMVC.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Vegetables_VegetableID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_VegetableID",
                table: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_VegetableID",
                table: "OrderDetails",
                column: "VegetableID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Vegetables_VegetableID",
                table: "OrderDetails",
                column: "VegetableID",
                principalTable: "Vegetables",
                principalColumn: "VegetableID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
