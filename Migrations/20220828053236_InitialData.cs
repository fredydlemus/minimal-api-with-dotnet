using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_entityFramework.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Description", "Name", "Peso" },
                values: new object[,]
                {
                    { new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9602"), null, "Personal activities", 50 },
                    { new Guid("5b2e793a-1027-40a6-83b7-54a2a92f96d7"), null, "Pending activities", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TaskkId", "CategoryId", "CreatedDate", "Description", "TaskPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9610"), new Guid("5b2e793a-1027-40a6-83b7-54a2a92f96d7"), new DateTime(2022, 8, 27, 23, 32, 36, 97, DateTimeKind.Local).AddTicks(8990), null, 1, "DO payments" },
                    { new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9611"), new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9602"), new DateTime(2022, 8, 27, 23, 32, 36, 97, DateTimeKind.Local).AddTicks(9010), null, 0, "end movie" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskkId",
                keyValue: new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9610"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskkId",
                keyValue: new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9611"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("5b2e793a-1027-40a6-83b7-54a2a92f9602"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("5b2e793a-1027-40a6-83b7-54a2a92f96d7"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
