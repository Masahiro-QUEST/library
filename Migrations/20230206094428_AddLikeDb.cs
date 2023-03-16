using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddLikeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "updated_by", "updated_date" },
                values: new object[] { "Yamada", new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "updated_by", "updated_date" },
                values: new object[] { "Yamada", new DateTime(2022, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "updated_by", "updated_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "updated_by", "updated_date" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
