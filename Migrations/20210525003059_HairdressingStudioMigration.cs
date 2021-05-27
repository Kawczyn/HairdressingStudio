using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdressingStudio.Migrations
{
    public partial class HairdressingStudioMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Studio");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairdressingServices",
                schema: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCombining = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ServiceTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairdressingServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stylists",
                schema: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stylists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StylistsWorkingHours",
                schema: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StylistId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylistsWorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HairdressingServicesStylists",
                schema: "Studio",
                columns: table => new
                {
                    HairdressingServicesId = table.Column<int>(type: "int", nullable: false),
                    StylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairdressingServicesStylists", x => new { x.HairdressingServicesId, x.StylistsId });
                    table.ForeignKey(
                        name: "FK_HairdressingServicesStylists_HairdressingServices_HairdressingServicesId",
                        column: x => x.HairdressingServicesId,
                        principalSchema: "Studio",
                        principalTable: "HairdressingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HairdressingServicesStylists_Stylists_StylistsId",
                        column: x => x.StylistsId,
                        principalSchema: "Studio",
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                schema: "Studio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StylistId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ServiceComment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_Clients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Studio",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_HairdressingServices_ServiceId",
                        column: x => x.ServiceId,
                        principalSchema: "Studio",
                        principalTable: "HairdressingServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Stylists_StylistId",
                        column: x => x.StylistId,
                        principalSchema: "Studio",
                        principalTable: "Stylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Clients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "poczekaj@o2.pl", "Edyta", "Poczekaj", 500500500 },
                    { 2, "bezdomny@o2.pl", "Jan", "Bezdomny", 606606606 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "HairdressingServices",
                columns: new[] { "Id", "Description", "IsActive", "Name", "Price", "ServiceTime" },
                values: new object[,]
                {
                    { 1, "Strzyżenie przy pomocy nożyczek i maszynki", true, "Strzyżenie włosów męskie - krótkie", 60m, 0.5m },
                    { 2, "Mycie, masaż głowy, strzyżenie oraz modelowanie", true, "Strzyżenie włosów i brody męskie - krótkie", 60m, 1m },
                    { 3, "Farbowanie przy użyciu najwyższej klasy produktów", true, "Farbowanie - średnie", 60m, 1m }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Stylists",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Magda", null },
                    { 2, "Karina", null }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[,]
                {
                    { 105, new DateTime(2021, 7, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 106, new DateTime(2021, 7, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 107, new DateTime(2021, 7, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 108, new DateTime(2021, 7, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 109, new DateTime(2021, 7, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 110, new DateTime(2021, 7, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 111, new DateTime(2021, 7, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 112, new DateTime(2021, 7, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 115, new DateTime(2021, 7, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 114, new DateTime(2021, 7, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 104, new DateTime(2021, 7, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 116, new DateTime(2021, 7, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 117, new DateTime(2021, 7, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 118, new DateTime(2021, 7, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 119, new DateTime(2021, 7, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 120, new DateTime(2021, 7, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 113, new DateTime(2021, 7, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 103, new DateTime(2021, 7, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 99, new DateTime(2021, 7, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 101, new DateTime(2021, 7, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 84, new DateTime(2021, 6, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 85, new DateTime(2021, 6, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 86, new DateTime(2021, 6, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 87, new DateTime(2021, 7, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 88, new DateTime(2021, 7, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 89, new DateTime(2021, 7, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 90, new DateTime(2021, 7, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 91, new DateTime(2021, 7, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 92, new DateTime(2021, 7, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 93, new DateTime(2021, 7, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, new DateTime(2021, 7, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 95, new DateTime(2021, 7, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 96, new DateTime(2021, 7, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 97, new DateTime(2021, 7, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 98, new DateTime(2021, 7, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[,]
                {
                    { 121, new DateTime(2021, 7, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 100, new DateTime(2021, 7, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 102, new DateTime(2021, 7, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 122, new DateTime(2021, 7, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 126, new DateTime(2021, 7, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 124, new DateTime(2021, 7, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 146, new DateTime(2021, 8, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 147, new DateTime(2021, 8, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 148, new DateTime(2021, 8, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 149, new DateTime(2021, 8, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 150, new DateTime(2021, 8, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 151, new DateTime(2021, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 152, new DateTime(2021, 8, 14, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 153, new DateTime(2021, 8, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 154, new DateTime(2021, 8, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 155, new DateTime(2021, 8, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 156, new DateTime(2021, 8, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 157, new DateTime(2021, 8, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 158, new DateTime(2021, 8, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 159, new DateTime(2021, 8, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 160, new DateTime(2021, 8, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 161, new DateTime(2021, 8, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 162, new DateTime(2021, 8, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 145, new DateTime(2021, 8, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 123, new DateTime(2021, 7, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 144, new DateTime(2021, 8, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 142, new DateTime(2021, 8, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 125, new DateTime(2021, 7, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 83, new DateTime(2021, 6, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 127, new DateTime(2021, 7, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 128, new DateTime(2021, 7, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 129, new DateTime(2021, 7, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 130, new DateTime(2021, 7, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 131, new DateTime(2021, 7, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 132, new DateTime(2021, 7, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 31, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 133, new DateTime(2021, 8, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 134, new DateTime(2021, 8, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 135, new DateTime(2021, 8, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 136, new DateTime(2021, 8, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 137, new DateTime(2021, 8, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 138, new DateTime(2021, 8, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 139, new DateTime(2021, 8, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[,]
                {
                    { 140, new DateTime(2021, 8, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 141, new DateTime(2021, 8, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 143, new DateTime(2021, 8, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 82, new DateTime(2021, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 79, new DateTime(2021, 6, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, new DateTime(2021, 6, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 22, new DateTime(2021, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, new DateTime(2021, 5, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 24, new DateTime(2021, 5, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, new DateTime(2021, 5, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 26, new DateTime(2021, 5, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, new DateTime(2021, 5, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 28, new DateTime(2021, 5, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, new DateTime(2021, 5, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, new DateTime(2021, 5, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 31, new DateTime(2021, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 32, new DateTime(2021, 5, 22, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, new DateTime(2021, 5, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, new DateTime(2021, 5, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 35, new DateTime(2021, 5, 26, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 26, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, new DateTime(2021, 5, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 37, new DateTime(2021, 5, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, new DateTime(2021, 5, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2021, 5, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2021, 5, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2021, 5, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2021, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2021, 5, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2021, 5, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2021, 5, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, new DateTime(2021, 5, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, new DateTime(2021, 5, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2021, 5, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2021, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2021, 5, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2021, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2021, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2021, 5, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, new DateTime(2021, 5, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, new DateTime(2021, 5, 12, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, new DateTime(2021, 5, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 5, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, new DateTime(2021, 5, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 39, new DateTime(2021, 5, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, new DateTime(2021, 5, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 41, new DateTime(2021, 5, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, new DateTime(2021, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 64, new DateTime(2021, 6, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, new DateTime(2021, 6, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 66, new DateTime(2021, 6, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, new DateTime(2021, 6, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 17, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 68, new DateTime(2021, 6, 17, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 17, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, new DateTime(2021, 6, 18, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 70, new DateTime(2021, 6, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, new DateTime(2021, 6, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 72, new DateTime(2021, 6, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, new DateTime(2021, 6, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 74, new DateTime(2021, 6, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 75, new DateTime(2021, 6, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, new DateTime(2021, 6, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 77, new DateTime(2021, 6, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, new DateTime(2021, 6, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 163, new DateTime(2021, 8, 24, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 24, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 62, new DateTime(2021, 6, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 81, new DateTime(2021, 6, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 26, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, new DateTime(2021, 6, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 59, new DateTime(2021, 6, 11, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 42, new DateTime(2021, 5, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 43, new DateTime(2021, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 44, new DateTime(2021, 6, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, new DateTime(2021, 6, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 46, new DateTime(2021, 6, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, new DateTime(2021, 6, 3, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 48, new DateTime(2021, 6, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, new DateTime(2021, 6, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 50, new DateTime(2021, 6, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, new DateTime(2021, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 52, new DateTime(2021, 6, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, new DateTime(2021, 6, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 54, new DateTime(2021, 6, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 55, new DateTime(2021, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 56, new DateTime(2021, 6, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 57, new DateTime(2021, 6, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[] { 58, new DateTime(2021, 6, 10, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[] { 60, new DateTime(2021, 6, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[] { 164, new DateTime(2021, 8, 24, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceComment", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 1, 2, null, new DateTime(2021, 4, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceComment", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 3, 2, null, new DateTime(2021, 4, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceComment", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 2, 1, null, new DateTime(2021, 4, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_HairdressingServicesStylists_StylistsId",
                schema: "Studio",
                table: "HairdressingServicesStylists",
                column: "StylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ClientId",
                schema: "Studio",
                table: "Visits",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_ServiceId",
                schema: "Studio",
                table: "Visits",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_StylistId",
                schema: "Studio",
                table: "Visits",
                column: "StylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HairdressingServicesStylists",
                schema: "Studio");

            migrationBuilder.DropTable(
                name: "StylistsWorkingHours",
                schema: "Studio");

            migrationBuilder.DropTable(
                name: "Visits",
                schema: "Studio");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Studio");

            migrationBuilder.DropTable(
                name: "HairdressingServices",
                schema: "Studio");

            migrationBuilder.DropTable(
                name: "Stylists",
                schema: "Studio");
        }
    }
}
