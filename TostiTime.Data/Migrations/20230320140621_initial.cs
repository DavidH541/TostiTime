using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TostiTime.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Irons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Irons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Irons_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IronId = table.Column<int>(type: "int", nullable: false),
                    SlotName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slots_Irons_IronId",
                        column: x => x.IronId,
                        principalTable: "Irons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    OccupiedSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OccupiedUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.SlotId, x.PersonId, x.OccupiedSince });
                    table.ForeignKey(
                        name: "FK_Reservations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "Address", "City", "CityCode", "Country", "PostalCode" },
                values: new object[,]
                {
                    { 1, "K.P. van der Mandelelaan 60", "Rotterdam", "010", "The Netherlands", "3062 MB" },
                    { 2, "Joop Geesinkweg 801", "Amsterdam", "020", "The Netherlands", "1114 AB" },
                    { 3, "Oude Middenweg 17", "The Hague", "070", "The Netherlands", "2491 AC" },
                    { 4, "Burgemeester Verderlaan 15b", "Utrecht", "030", "The Netherlands", "3544 AD" },
                    { 5, "Flight Forum 86", "Eindhoven", "040", "The Netherlands", "5657 DC" },
                    { 6, "J.C. Wilslaan 29", "Apeldoorn", "055", "The Netherlands", "7313 HK" },
                    { 7, "Vladimira Popovića 40", "Belgrade", "011", "Serbia", "11000" }
                });

            migrationBuilder.InsertData(
                table: "Irons",
                columns: new[] { "Id", "Name", "OfficeId" },
                values: new object[,]
                {
                    { 1, "Grijs", 1 },
                    { 2, "Zwart", 1 },
                    { 3, "Klein", 5 },
                    { 4, "Groot", 5 },
                    { 5, "", 2 },
                    { 6, "", 3 },
                    { 7, "", 4 },
                    { 8, "", 6 },
                    { 9, "", 7 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "OfficeId" },
                values: new object[,]
                {
                    { 1, "David", 1 },
                    { 2, "Alexander", 1 },
                    { 3, "Casper", 1 },
                    { 4, "Marnix", 1 },
                    { 5, "Jesse", 2 },
                    { 6, "Judith", 3 },
                    { 7, "Youri", 4 },
                    { 8, "Gijs", 5 },
                    { 9, "Jimmy", 6 },
                    { 10, "Goran", 7 }
                });

            migrationBuilder.InsertData(
                table: "Slots",
                columns: new[] { "Id", "IronId", "SlotName" },
                values: new object[,]
                {
                    { 1, 1, "" },
                    { 2, 1, "" },
                    { 3, 1, "" },
                    { 4, 1, "" },
                    { 5, 2, "" },
                    { 6, 2, "" },
                    { 7, 2, "" },
                    { 8, 2, "" },
                    { 9, 3, "" },
                    { 10, 3, "" },
                    { 11, 3, "" },
                    { 12, 3, "" },
                    { 13, 4, "" },
                    { 14, 4, "" },
                    { 15, 4, "" },
                    { 16, 4, "" },
                    { 17, 4, "" },
                    { 18, 4, "" },
                    { 19, 5, "" },
                    { 20, 5, "" },
                    { 21, 6, "" },
                    { 22, 6, "" },
                    { 23, 7, "" },
                    { 24, 7, "" },
                    { 25, 7, "" },
                    { 26, 7, "" },
                    { 27, 8, "" },
                    { 28, 8, "" },
                    { 29, 9, "" },
                    { 30, 9, "" },
                    { 31, 9, "" },
                    { 32, 9, "" },
                    { 33, 9, "" },
                    { 34, 9, "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Irons_OfficeId",
                table: "Irons",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_OfficeId",
                table: "Persons",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PersonId",
                table: "Reservations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_IronId",
                table: "Slots",
                column: "IronId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Irons");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
