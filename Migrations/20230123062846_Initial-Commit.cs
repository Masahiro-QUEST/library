using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    author = table.Column<string>(type: "TEXT", nullable: true),
                    updateddate = table.Column<DateTime>(name: "updated_date", type: "TEXT", nullable: false),
                    updatedby = table.Column<string>(name: "updated_by", type: "TEXT", nullable: true),
                    tag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "author", "tag", "title", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1001, "越川慎司", "IT", "AI分析でわかった トップ5％社員", "Yamada", new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "小川 雄太郎 ", "IT", "つくりながら学ぶ！PyTorchによる発展ディープラーニング", "Yamada", new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
