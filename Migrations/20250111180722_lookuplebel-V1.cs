using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Area_v1.Migrations
{
    /// <inheritdoc />
    public partial class lookuplebelV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUpLebels",
                columns: table => new
                {
                    LookUpLebelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookUpLebelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpLebels", x => x.LookUpLebelId);
                });

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LebelId = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ProductCatagory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LookUpLebels");

            migrationBuilder.DropTable(
                name: "Lookups");
        }
    }
}
