using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "Shopping List Product");

            migrationBuilder.CreateTable(
                name: "ProductNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Note Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Note Content"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "ProductIdentifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNotes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Product Note");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNotes_ProductId",
                table: "ProductNotes",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNotes");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
