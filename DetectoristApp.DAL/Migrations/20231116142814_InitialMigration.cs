using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DetectoristApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Coils",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Diameter = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coils", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Metaldetectors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Model = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    IsWaterproof = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CoilId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metaldetectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metaldetectors_Coils_CoilId",
                        column: x => x.CoilId,
                        principalTable: "Coils",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detectorists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetaldetectorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detectorists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detectorists_Metaldetectors_MetaldetectorId",
                        column: x => x.MetaldetectorId,
                        principalTable: "Metaldetectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Coils",
                columns: new[] { "Id", "Brand", "Diameter", "Model" },
                values: new object[,]
                {
                    { 1, "Nel", 6.5, "Tornado" },
                    { 2, "Minelab", 11.0, "EQX 15 Double-D" },
                    { 3, "Deus", 9.0, "9'' FMF" }
                });

            migrationBuilder.InsertData(
                table: "Metaldetectors",
                columns: new[] { "Id", "Brand", "CoilId", "IsWaterproof", "Model", "Weight" },
                values: new object[,]
                {
                    { 1, "Garrett", 1, false, "Ace 250", 1.7 },
                    { 2, "Minelab", 2, true, "Equinox 800", 1.5 },
                    { 3, "Deus", 3, false, "2", 1.1 }
                });

            migrationBuilder.InsertData(
                table: "Detectorists",
                columns: new[] { "Id", "Age", "MetaldetectorId", "Sex", "Username" },
                values: new object[,]
                {
                    { 1, 25, 1, "Male", "Kola1" },
                    { 2, 30, 2, "Female", "Kola2" },
                    { 3, 40, 3, "Male", "Halk" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detectorists_MetaldetectorId",
                table: "Detectorists",
                column: "MetaldetectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Detectorists_Username",
                table: "Detectorists",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metaldetectors_CoilId",
                table: "Metaldetectors",
                column: "CoilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detectorists");

            migrationBuilder.DropTable(
                name: "Metaldetectors");

            migrationBuilder.DropTable(
                name: "Coils");
        }
    }
}
