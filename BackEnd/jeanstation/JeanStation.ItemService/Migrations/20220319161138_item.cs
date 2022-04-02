using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JeanStation.ItemService.Migrations
{
    public partial class item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    ItemMaterial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemCategory = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemPrice = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    ItemColor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemBrandName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ItemSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ItemStock = table.Column<int>(type: "int", nullable: false),
                    ItemImage1 = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
