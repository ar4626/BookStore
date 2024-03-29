using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository_Layer.Migrations
{
    public partial class cartTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartTable",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartTable", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_CartTable_BookTable_BookId",
                        column: x => x.BookId,
                        principalTable: "BookTable",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_BookId",
                table: "CartTable",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartTable_UserId",
                table: "CartTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartTable");
        }
    }
}
