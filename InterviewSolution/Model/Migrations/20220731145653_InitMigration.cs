using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InterviewSolution.Model.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CitySender = table.Column<string>(type: "text", nullable: false),
                    AddressSender = table.Column<string>(type: "text", nullable: false),
                    CityRecipient = table.Column<string>(type: "text", nullable: false),
                    AddressRecipient = table.Column<string>(type: "text", nullable: false),
                    CargoWeight = table.Column<float>(type: "real", nullable: false),
                    ReceiptDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "Id", "AddressRecipient", "AddressSender", "CargoWeight", "CityRecipient", "CitySender", "ReceiptDateTime" },
                values: new object[,]
                {
                    { 1, "st. Lenina", "st. Velkanskaya", 2.05f, "Moscow", "Orenburg", new DateTime(2022, 6, 21, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "st. Woosh", "st. Ocean Gateway", 25.15f, "Los-Santos", "Berlin", new DateTime(2016, 6, 29, 16, 43, 0, 0, DateTimeKind.Utc) },
                    { 3, "Wall street", "Avenue Victor Hugo", 300f, "New-York", "Paris", new DateTime(2020, 3, 15, 14, 33, 52, 0, DateTimeKind.Utc) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
