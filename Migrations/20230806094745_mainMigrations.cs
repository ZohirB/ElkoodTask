using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElkoodTask.Migrations
{
    /// <inheritdoc />
    public partial class mainMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Activity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BranchTypeId = table.Column<int>(type: "integer", nullable: false),
                    CompanyInfoId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchInfo_BranchTypes_BranchTypeId",
                        column: x => x.BranchTypeId,
                        principalTable: "BranchTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchInfo_CompanyInfo_CompanyInfoId",
                        column: x => x.CompanyInfoId,
                        principalTable: "CompanyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductInfo_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistributionOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrimaryBranchInfoId = table.Column<int>(type: "integer", nullable: false),
                    SecondaryBranchInfoId = table.Column<int>(type: "integer", nullable: false),
                    ProductInfoId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BranchInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributionOperations_BranchInfo_BranchInfoId",
                        column: x => x.BranchInfoId,
                        principalTable: "BranchInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DistributionOperations_BranchInfo_PrimaryBranchInfoId",
                        column: x => x.PrimaryBranchInfoId,
                        principalTable: "BranchInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistributionOperations_BranchInfo_SecondaryBranchInfoId",
                        column: x => x.SecondaryBranchInfoId,
                        principalTable: "BranchInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DistributionOperations_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchInfoId = table.Column<int>(type: "integer", nullable: false),
                    ProductInfoId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    RemainingQuantity = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionOperations_BranchInfo_BranchInfoId",
                        column: x => x.BranchInfoId,
                        principalTable: "BranchInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOperations_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BranchTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Primary" },
                    { 2, "Secondary" }
                });

            migrationBuilder.InsertData(
                table: "CompanyInfo",
                columns: new[] { "Id", "Activity", "EstablishmentDate", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Electric Vehicles", new DateTime(2003, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austin, Texas, USA", "Tesla" },
                    { 2, "Spacecraft Technology", new DateTime(2002, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hawthorne, California, USA", "SpaceX" },
                    { 3, "Technology Company", new DateTime(1976, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cupertino, California, USA", "Apple" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mobil" },
                    { 2, "Laptop" },
                    { 3, "Car" },
                    { 4, "Rocket" }
                });

            migrationBuilder.InsertData(
                table: "BranchInfo",
                columns: new[] { "Id", "BranchTypeId", "CompanyInfoId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Nevada State", "Gigafactory Nevada" },
                    { 2, 2, 1, "Texas, California", "Texas Store" },
                    { 3, 1, 2, "California State", "Hawthorne Headquarters" },
                    { 4, 2, 2, "USA", "NASA Store" },
                    { 5, 1, 3, "Washington State", "Washington" },
                    { 6, 1, 3, "New York State", "New York" },
                    { 7, 2, 3, "Shanghai, China", "Nanjing East store" }
                });

            migrationBuilder.InsertData(
                table: "ProductInfo",
                columns: new[] { "Id", "Name", "ProductTypeId" },
                values: new object[,]
                {
                    { 1, "iphone 15", 1 },
                    { 2, "Macbook Air", 2 },
                    { 3, "Falcon 9", 4 },
                    { 4, "Model S", 3 },
                    { 5, "iphone 16", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductionOperations",
                columns: new[] { "Id", "BranchInfoId", "Date", "ProductInfoId", "Quantity", "RemainingQuantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2012, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1000, 1000 },
                    { 2, 3, new DateTime(2010, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 40, 40 },
                    { 3, 5, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 50000, 50000 },
                    { 4, 6, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15000, 15000 },
                    { 5, 6, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 25000, 25000 },
                    { 6, 5, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10000, 10000 },
                    { 7, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 15000, 15000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchInfo_BranchTypeId",
                table: "BranchInfo",
                column: "BranchTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchInfo_CompanyInfoId",
                table: "BranchInfo",
                column: "CompanyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionOperations_BranchInfoId",
                table: "DistributionOperations",
                column: "BranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionOperations_PrimaryBranchInfoId",
                table: "DistributionOperations",
                column: "PrimaryBranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionOperations_ProductInfoId",
                table: "DistributionOperations",
                column: "ProductInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionOperations_SecondaryBranchInfoId",
                table: "DistributionOperations",
                column: "SecondaryBranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInfo_ProductTypeId",
                table: "ProductInfo",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOperations_BranchInfoId",
                table: "ProductionOperations",
                column: "BranchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOperations_ProductInfoId",
                table: "ProductionOperations",
                column: "ProductInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistributionOperations");

            migrationBuilder.DropTable(
                name: "ProductionOperations");

            migrationBuilder.DropTable(
                name: "BranchInfo");

            migrationBuilder.DropTable(
                name: "ProductInfo");

            migrationBuilder.DropTable(
                name: "BranchTypes");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

            migrationBuilder.DropTable(
                name: "ProductTypes");
        }
    }
}
