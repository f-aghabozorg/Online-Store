using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addrolewarehousekeeper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 5, 14, 49, 17, 660, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 5, 14, 49, 17, 660, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 5, 14, 49, 17, 660, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "InsertTime", "IsRemoved", "Name", "RemoveTime", "UpdateTime" },
                values: new object[] { 4L, new DateTime(2023, 6, 5, 14, 49, 17, 660, DateTimeKind.Local).AddTicks(9421), false, "warehouse_keeper", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 21, 8, 36, 276, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 21, 8, 36, 276, DateTimeKind.Local).AddTicks(7078));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2023, 6, 3, 21, 8, 36, 276, DateTimeKind.Local).AddTicks(7106));
        }
    }
}
