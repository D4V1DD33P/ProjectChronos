using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StyleOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OptionNumber = table.Column<string>(nullable: true),
                    OptionName = table.Column<string>(nullable: true),
                    OptionColor = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    StyleId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StyleOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StyleOptions_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StyleOptions_StyleId",
                table: "StyleOptions",
                column: "StyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StyleOptions");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}
