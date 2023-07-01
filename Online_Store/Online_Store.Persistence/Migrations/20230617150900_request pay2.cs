using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class requestpay2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 38, 59, 700, DateTimeKind.Local).AddTicks(1584));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 38, 59, 700, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 38, 59, 700, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 38, 59, 700, DateTimeKind.Local).AddTicks(1691));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
