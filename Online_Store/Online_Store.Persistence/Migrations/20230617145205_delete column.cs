using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 22, 4, 977, DateTimeKind.Local).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 22, 4, 977, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 22, 4, 977, DateTimeKind.Local).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 22, 4, 977, DateTimeKind.Local).AddTicks(1478));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 13, 14, 10, 43, 353, DateTimeKind.Local).AddTicks(5480));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 13, 14, 10, 43, 353, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 13, 14, 10, 43, 353, DateTimeKind.Local).AddTicks(5566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 13, 14, 10, 43, 353, DateTimeKind.Local).AddTicks(5577));
        }
    }
}
