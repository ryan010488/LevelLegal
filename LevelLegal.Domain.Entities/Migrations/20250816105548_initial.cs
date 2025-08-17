using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LevelLegal.Domain.Entities.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evidences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MatterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evidences_Matters_MatterId",
                        column: x => x.MatterId,
                        principalTable: "Matters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Matters",
                columns: new[] { "Id", "ClientName", "Name" },
                values: new object[,]
                {
                    { 100, null, "Up vs Down" },
                    { 101, null, "In vs Out" },
                    { 102, null, "EF Core vs Dapper" },
                    { 103, null, "Dark Mode vs Light Mode" }
                });

            migrationBuilder.InsertData(
                table: "Evidences",
                columns: new[] { "Id", "Description", "MatterId", "SerialNumber" },
                values: new object[,]
                {
                    { 1, "Dell XPS Laptop", 100, "DG56GSR" },
                    { 2, "San Disk Flash Drive", 100, "43255323GS445344" },
                    { 3, "ASUS Zenbook 14 Laptop", 100, "GBSFFDW8434-3323" },
                    { 4, "Kingston 256GB Flash Drive", 101, "KD43243KT67655" },
                    { 5, "iPhone 15", 102, "GT453223FSTR52" },
                    { 6, "Samsung NVMe M2 Internal Drive", 102, "SE5324GYTF65556" },
                    { 7, "Samsung Fold Cell Phone", 102, "FSYGD645DFSWWSFFDTSAA" },
                    { 8, "Lacie External 1TB Drive", 103, "AD34222432-321321" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evidences_MatterId",
                table: "Evidences",
                column: "MatterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evidences");

            migrationBuilder.DropTable(
                name: "Matters");
        }
    }
}
