using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 51, 42, 120, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 51, 42, 120, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 51, 42, 120, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 51, 42, 120, DateTimeKind.Local).AddTicks(4054));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 40, 55, 618, DateTimeKind.Local).AddTicks(2629));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 40, 55, 618, DateTimeKind.Local).AddTicks(2689));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 40, 55, 618, DateTimeKind.Local).AddTicks(2700));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 17, 19, 40, 55, 618, DateTimeKind.Local).AddTicks(2709));
        }
    }
}
