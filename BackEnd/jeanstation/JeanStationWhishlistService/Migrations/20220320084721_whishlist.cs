using Microsoft.EntityFrameworkCore.Migrations;

namespace JeanStationWhishlistService.Migrations
{
    public partial class whishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    WishlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemBrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemPrice = table.Column<int>(type: "int", nullable: false),
                    ItemImg1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImg3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.WishlistId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wishlists");
        }
    }
}
