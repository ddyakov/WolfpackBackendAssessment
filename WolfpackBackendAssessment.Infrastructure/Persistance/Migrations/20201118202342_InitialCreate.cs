using Microsoft.EntityFrameworkCore.Migrations;

namespace WolfpackBackendAssessment.Infrastructure.Persistance.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wolves",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Gender_Value = table.Column<int>(nullable: true),
                    Location_Latitude = table.Column<string>(nullable: true),
                    Location_Longitude = table.Column<string>(nullable: true),
                    PackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wolves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wolves_Packs_PackId",
                        column: x => x.PackId,
                        principalTable: "Packs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wolves_PackId",
                table: "Wolves",
                column: "PackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wolves");

            migrationBuilder.DropTable(
                name: "Packs");
        }
    }
}
