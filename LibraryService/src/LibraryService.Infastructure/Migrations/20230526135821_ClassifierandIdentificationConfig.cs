using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryService.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class ClassifierandIdentificationConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "identifier",
                type: "longtext",
                nullable: false);

            migrationBuilder.InsertData(
                table: "classification",
                columns: new[] { "ID", "Label", "Name" },
                values: new object[,]
                {
                    { 1000, "Dewey Decimal Class", "dewey_decimal_class" },
                    { 1001, " Library of Congress", "lc_classifications" },
                    { 1002, "Universal Decimal Classification", "udc" }
                });

            migrationBuilder.InsertData(
                table: "identifier",
                columns: new[] { "ID", "Label", "Name" },
                values: new object[,]
                {
                    { 1001, "Amazon", "amazon" },
                    { 1002, "Goolge", "google" },
                    { 1003, "Library Thing", "librarything" },
                    { 1004, "Goodreads", "goodreads" },
                    { 1005, "ISBN 10", "isbn_13" },
                    { 1006, "ISBN 13", "isbn_13" },
                    { 1007, "ISSN", "issn" },
                    { 1008, "LCCN", "lccn" },
                    { 1009, "OCLC/WorldCat", "oclc" },
                    { 1010, "British Library", "british_library" },
                    { 1011, "OpenLibrary", "openlibrary" },
                    { 1012, "british_national_bibliography", " British National Bibliography" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "classification",
                keyColumn: "ID",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "classification",
                keyColumn: "ID",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "classification",
                keyColumn: "ID",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "identifier",
                keyColumn: "ID",
                keyValue: 1012);

            migrationBuilder.DropColumn(
                name: "Label",
                table: "identifier");
        }
    }
}
