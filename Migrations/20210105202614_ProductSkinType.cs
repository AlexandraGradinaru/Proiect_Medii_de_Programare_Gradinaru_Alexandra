using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Medii_de_Programare_Gradinaru_Alexandra.Migrations
{
    public partial class ProductSkinType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkinType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkinTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSkinType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(nullable: false),
                    SkinTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSkinType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSkinType_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSkinType_SkinType_SkinTypeID",
                        column: x => x.SkinTypeID,
                        principalTable: "SkinType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkinType_ProductID",
                table: "ProductSkinType",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkinType_SkinTypeID",
                table: "ProductSkinType",
                column: "SkinTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSkinType");

            migrationBuilder.DropTable(
                name: "SkinType");
        }
    }
}
