using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Area_v1.Migrations
{
    /// <inheritdoc />
    public partial class shopV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopLebels",
                columns: table => new
                {
                    ShopLebelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LebelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLebels", x => x.ShopLebelId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopLebels");
        }
    }
}
