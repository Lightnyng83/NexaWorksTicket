using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexaWorksTicket.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityProductVersionOsId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginModel");

            migrationBuilder.CreateTable(
                name: "Os",
                columns: table => new
                {
                    OsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Os", x => x.OsId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsVersion",
                columns: table => new
                {
                    VersionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsVersion", x => x.VersionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductVersionOs",
                columns: table => new
                {
                    IdProductVersionOs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdVersion = table.Column<int>(type: "int", nullable: false),
                    IdOs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVersionOs_1", x => x.IdProductVersionOs);
                    table.ForeignKey(
                        name: "FK_ProductVersionOs_Os",
                        column: x => x.IdOs,
                        principalTable: "Os",
                        principalColumn: "OsId");
                    table.ForeignKey(
                        name: "FK_ProductVersionOs_Products",
                        column: x => x.IdProduct,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductVersionOs_ProductsVersion",
                        column: x => x.IdVersion,
                        principalTable: "ProductsVersion",
                        principalColumn: "VersionId");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVersionOsId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    FixingDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FixingStatus = table.Column<int>(type: "int", nullable: false),
                    Problem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolutionReport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_ProductVersionOs",
                        column: x => x.ProductVersionOsId,
                        principalTable: "ProductVersionOs",
                        principalColumn: "IdProductVersionOs");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVersionOs_IdOs",
                table: "ProductVersionOs",
                column: "IdOs");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVersionOs_IdProduct",
                table: "ProductVersionOs",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVersionOs_IdVersion",
                table: "ProductVersionOs",
                column: "IdVersion");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProductVersionOsId",
                table: "Ticket",
                column: "ProductVersionOsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ProductVersionOs");

            migrationBuilder.DropTable(
                name: "Os");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsVersion");

            migrationBuilder.CreateTable(
                name: "LoginModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginModel", x => x.Id);
                });
        }
    }
}
