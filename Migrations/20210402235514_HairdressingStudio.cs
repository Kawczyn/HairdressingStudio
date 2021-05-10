using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdressingStudio.Migrations
{
    public partial class HairdressingStudio : Migration
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
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
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                    ServiceId = table.Column<int>(type: "int", nullable: false)
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
                    { 39, new DateTime(2021, 4, 28, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 28, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, new DateTime(2021, 4, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 37, new DateTime(2021, 4, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, new DateTime(2021, 4, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, new DateTime(2021, 4, 24, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 32, new DateTime(2021, 4, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, new DateTime(2021, 4, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 40, new DateTime(2021, 4, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 31, new DateTime(2021, 4, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 22, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 30, new DateTime(2021, 4, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, new DateTime(2021, 4, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, new DateTime(2021, 4, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, new DateTime(2021, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, new DateTime(2021, 4, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 44, new DateTime(2021, 4, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, new DateTime(2021, 4, 21, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 46, new DateTime(2021, 5, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 47, new DateTime(2021, 5, 4, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 4, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 48, new DateTime(2021, 5, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 4, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, new DateTime(2021, 5, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 50, new DateTime(2021, 5, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, new DateTime(2021, 5, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 52, new DateTime(2021, 5, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, new DateTime(2021, 5, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 54, new DateTime(2021, 5, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 42, new DateTime(2021, 4, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 28, new DateTime(2021, 4, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, new DateTime(2021, 4, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, new DateTime(2021, 4, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 17, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, new DateTime(2021, 4, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 4, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2021, 4, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, new DateTime(2021, 4, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2021, 4, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, new DateTime(2021, 4, 3, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 3, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "StylistsWorkingHours",
                columns: new[] { "Id", "EndDate", "StartDate", "StylistId" },
                values: new object[,]
                {
                    { 7, new DateTime(2021, 4, 6, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, new DateTime(2021, 4, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 6, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, new DateTime(2021, 4, 7, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 10, new DateTime(2021, 4, 7, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, new DateTime(2021, 4, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, new DateTime(2021, 4, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, new DateTime(2021, 4, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 14, new DateTime(2021, 4, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 9, 13, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, new DateTime(2021, 4, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, new DateTime(2021, 4, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, new DateTime(2021, 4, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, new DateTime(2021, 4, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, new DateTime(2021, 4, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, new DateTime(2021, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, new DateTime(2021, 4, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, new DateTime(2021, 4, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, new DateTime(2021, 4, 16, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, new DateTime(2021, 4, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 55, new DateTime(2021, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, new DateTime(2021, 4, 20, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 56, new DateTime(2021, 5, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 1, 1, new DateTime(2021, 4, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 3, 1, new DateTime(2021, 4, 6, 15, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                schema: "Studio",
                table: "Visits",
                columns: new[] { "Id", "ClientId", "ServiceDate", "ServiceId", "StylistId" },
                values: new object[] { 2, 2, new DateTime(2021, 4, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

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
