using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentService.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Abbr = table.Column<string>(type: "varchar(5)", nullable: true),
                    QualificationLevel = table.Column<int>(type: "int", nullable: false),
                    QualificationType = table.Column<string>(type: "longtext", nullable: false),
                    DegreeCategory = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(50)", nullable: false),
                    TranscriptId = table.Column<int>(type: "int", nullable: false),
                    ContactDetail_StudentEmail = table.Column<string>(type: "varchar(255)", nullable: false),
                    ContactDetail_AlternateEmail = table.Column<string>(type: "varchar(255)", nullable: false),
                    ContactDetail_PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactDetail_TermAddress_LineOne = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactDetail_TermAddress_LineTwo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContactDetail_TermAddress_LineThree = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContactDetail_TermAddress_Town_City = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactDetail_TermAddress_County_Region = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactDetail_TermAddress_PostCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactDetail_TermAddress_Country = table.Column<string>(type: "varchar(30)", nullable: false),
                    ContactDetail_PermanentAddress_LineOne = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactDetail_PermanentAddress_LineTwo = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContactDetail_PermanentAddress_LineThree = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContactDetail_PermanentAddress_Town_City = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactDetail_PermanentAddress_County_Region = table.Column<string>(type: "varchar(50)", nullable: true),
                    ContactDetail_PermanentAddress_PostCode = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactDetail_PermanentAddress_Country = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.UniqueConstraint("AK_Students_AccountNumber", x => x.AccountNumber);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    CourseCode = table.Column<string>(type: "varchar(255)", nullable: false),
                    CourseType = table.Column<string>(type: "longtext", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    AwardId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.UniqueConstraint("AK_Courses_CourseCode_IsActive", x => new { x.CourseCode, x.IsActive });
                    table.ForeignKey(
                        name: "FK_Courses_Awards_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContainedAwards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AwardId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainedAwards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContainedAwards_Awards_AwardId1",
                        column: x => x.AwardId1,
                        principalTable: "Awards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainedAwards_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    QualificationLevel = table.Column<int>(type: "int", nullable: false),
                    TuitionFee = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RegistrationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRegistrations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseRegistrations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(50)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcripts_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Transcripts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EnrolDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CourseLevelId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "varchar(255)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrolments_CourseOfferings_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrolments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseLevelName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ProgressDecision = table.Column<string>(type: "longtext", nullable: false),
                    ProgressDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProgressNotes = table.Column<string>(type: "varchar(450)", nullable: true),
                    TranscriptId = table.Column<int>(type: "int", nullable: false),
                    CourseLevelId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResults_CourseOfferings_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseOfferings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseResults_Transcripts_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "Transcripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Abbr", "DegreeCategory", "Name", "QualificationLevel", "QualificationType" },
                values: new object[,]
                {
                    { 91, "HNCSc", "Foundation", "Certificate of Higher Education in Science", 5, "Certificate" },
                    { 92, "HNCSc", "Foundation", "Higher National Certificate in Science", 4, "Certificate" },
                    { 93, "awardSc", "Foundation", "Level 4 Award in Science", 4, "Award" },
                    { 94, "Lvl4Sc", "Foundation", "Level 4 Certificate in Science", 4, "Certificate" },
                    { 95, "CertHEdSc", "Undergraduate", "Certificate of Higher Education in Science", 5, "Certificate" },
                    { 96, "FdA", "Undergraduate", "Foundation Degree In Education", 5, "Degree" },
                    { 97, "FdSc", "Undergraduate", "Foundation Degree In Science", 5, "Degree" },
                    { 98, "BSc", "Undergraduate", "Bachelor of Science", 6, "Degree" },
                    { 99, "BSc", "Undergraduate", "Bachelor of Science", 6, "Degree" },
                    { 101, "BA", "Undergraduate", "Bachelor of Arts", 6, "Degree" },
                    { 102, "BEng", "Undergraduate", "Bachelor of Engineering", 6, "Degree" },
                    { 103, "BEd", "Undergraduate", "Bachelor of Education", 6, "Degree" },
                    { 104, "LLB", "Undergraduate", "Bachelor of Law", 6, "Degree" },
                    { 105, "MB", "Undergraduate", "Bachelor of Medicine", 6, "Degree" },
                    { 106, "ChB", "Undergraduate", "Bachelor of Surgery", 6, "Degree" },
                    { 107, "MSc", "Undergraduate", "Master of Philosophy", 7, "Degree" },
                    { 108, "MSc", "Undergraduate", "Master of Science", 7, "Degree" },
                    { 109, "MA", "Undergraduate", "Master of Arts", 7, "Degree" },
                    { 110, "MEng", "Undergraduate", "Master of Engineering", 7, "Degree" },
                    { 111, "MEd", "Undergraduate", "Master of Education", 7, "Degree" },
                    { 112, "LLM", "Undergraduate", "Master of Law", 7, "Degree" }
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Arts", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Build Environment, Engineering, and Computing", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Business", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Health", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of SocialSciences", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Education", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Law", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "School of Sports", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accounting and Finance", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art and Design", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Architecture and Landscape Design", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Biomedical Sciences", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Business and Management", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Civil Engineering", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Computing and Engineering", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Creative Technologies", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Criminology, Psychology, and Sociology", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dietetics and Nutrition", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Economics and Analytics", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Education and Teaching", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "English Language Study", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engish, History, and Media", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Events Management", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Film", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Geography, Planning, and Housing", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Law", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing, PR, and Journalism", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music and Sound", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nursing, Healthcare, and Health Promotion", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Performing Arts", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Politics and International Relations", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psychological Therapies and Mental Health", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rehabilitation Therapies", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Safety and Environmental Health", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Social and Communication Studies", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Speech and Language Sciences", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surveying, Construction, and Project Management", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tourism and Hospitality Management", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AwardId", "CourseCode", "CourseType", "CreatedBy", "CreatedDate", "Duration", "IsActive", "Name", "SchoolId", "SubjectId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, 100, "L27", "FullTime", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, "Computer Science", 2, 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "CourseOfferings",
                columns: new[] { "Id", "CourseId", "CreatedBy", "CreatedDate", "Credits", "Name", "QualificationLevel", "TuitionFee", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, "Computer Science Level 4", 4, 9250m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, "Computer Science Level 5", 5, 9250m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, "Computer Science Level 6", 6, 9250m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainedAwards_AwardId1",
                table: "ContainedAwards",
                column: "AwardId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContainedAwards_CourseId",
                table: "ContainedAwards",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_CourseId",
                table: "CourseOfferings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_CourseId",
                table: "CourseRegistrations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistrations_StudentId",
                table: "CourseRegistrations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_CourseLevelId",
                table: "CourseResults",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResults_TranscriptId",
                table: "CourseResults",
                column: "TranscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AwardId",
                table: "Courses",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SubjectId",
                table: "Courses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_CourseLevelId",
                table: "Enrolments",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_StudentId",
                table: "Enrolments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_CourseId",
                table: "Transcripts",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentId",
                table: "Transcripts",
                column: "StudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContainedAwards");

            migrationBuilder.DropTable(
                name: "CourseRegistrations");

            migrationBuilder.DropTable(
                name: "CourseResults");

            migrationBuilder.DropTable(
                name: "Enrolments");

            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
