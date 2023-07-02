using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryService.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false),
                    AccountNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Pin = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountId);
                    table.UniqueConstraint("AK_account_AccountNum", x => x.AccountNum);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: true),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true),
                    LastName = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(255)", nullable: false),
                    BookNum = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "longtext", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    Pagination = table.Column<string>(type: "longtext", nullable: false),
                    PublicationLocation = table.Column<string>(type: "longtext", nullable: false),
                    PublicationDate = table.Column<string>(type: "longtext", nullable: false),
                    Classification_DDC = table.Column<string>(type: "longtext", nullable: false),
                    Classification_LCC = table.Column<string>(type: "longtext", nullable: false),
                    Identifier_ISBN_10 = table.Column<string>(type: "longtext", nullable: false),
                    Identifier_ISBN_13 = table.Column<string>(type: "longtext", nullable: false),
                    Identifier_LCCN = table.Column<string>(type: "longtext", nullable: false),
                    Identifier_OCLC = table.Column<string>(type: "longtext", nullable: false),
                    Identifier_OLID = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.ISBN);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publisher", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bookauthor",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(255)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookauthor", x => new { x.ISBN, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_bookauthor_author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookauthor_book_ISBN",
                        column: x => x.ISBN,
                        principalTable: "book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bookcopy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CopyNum = table.Column<int>(type: "int", nullable: false),
                    Format = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "longtext", nullable: false),
                    IsReferenceOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BookISBN = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookcopy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bookcopy_book_BookISBN",
                        column: x => x.BookISBN,
                        principalTable: "book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bookpublisher",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(255)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    PublisherName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookpublisher", x => new { x.ISBN, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_bookpublisher_book_ISBN",
                        column: x => x.ISBN,
                        principalTable: "book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookpublisher_publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "booksubject",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "varchar(255)", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    SubjectName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booksubject", x => new { x.ISBN, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_booksubject_book_ISBN",
                        column: x => x.ISBN,
                        principalTable: "book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booksubject_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsComplete = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateBorrowed = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BookISBN = table.Column<string>(type: "longtext", nullable: false),
                    BookTitle = table.Column<string>(type: "longtext", nullable: false),
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    Fine_FineDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Fine_Amount = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Fine_AccountId = table.Column<string>(type: "longtext", nullable: true),
                    Fine_FineIssued = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_loan_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_loan_bookcopy_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "bookcopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rack",
                columns: table => new
                {
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    StackNumber = table.Column<int>(type: "int", nullable: false),
                    LocationCode = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rack", x => x.BookCopyId);
                    table.ForeignKey(
                        name: "FK_rack_bookcopy_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "bookcopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RequestDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NeededBy = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    BookISBN = table.Column<string>(type: "longtext", nullable: false),
                    BookTitle = table.Column<string>(type: "longtext", nullable: false),
                    AccountId = table.Column<string>(type: "varchar(255)", nullable: false),
                    BookCopyId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservation_account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservation_bookcopy_BookCopyId",
                        column: x => x.BookCopyId,
                        principalTable: "bookcopy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_bookauthor_AuthorId",
                table: "bookauthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_bookcopy_BookISBN",
                table: "bookcopy",
                column: "BookISBN");

            migrationBuilder.CreateIndex(
                name: "IX_bookpublisher_PublisherId",
                table: "bookpublisher",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_booksubject_SubjectId",
                table: "booksubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_loan_AccountId",
                table: "loan",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_loan_BookCopyId",
                table: "loan",
                column: "BookCopyId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_AccountId",
                table: "reservation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_BookCopyId",
                table: "reservation",
                column: "BookCopyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookauthor");

            migrationBuilder.DropTable(
                name: "bookpublisher");

            migrationBuilder.DropTable(
                name: "booksubject");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "rack");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "publisher");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "bookcopy");

            migrationBuilder.DropTable(
                name: "book");
        }
    }
}
