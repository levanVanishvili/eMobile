using Microsoft.EntityFrameworkCore.Migrations;

namespace eMobile.Migrations
{
    public partial class AddProductToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Dimensions = table.Column<string>(nullable: false),
                    Weight = table.Column<string>(nullable: false),
                    DisplaySize = table.Column<string>(nullable: false),
                    Resolution = table.Column<string>(nullable: false),
                    CPU = table.Column<string>(nullable: false),
                    RomMemory = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    FileUrl = table.Column<string>(nullable: true),
                    OpSystemId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_OperatingSystems_OpSystemId",
                        column: x => x.OpSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OpSystemId",
                table: "Products",
                column: "OpSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
