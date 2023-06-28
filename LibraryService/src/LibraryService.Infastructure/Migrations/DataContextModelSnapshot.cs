﻿// <auto-generated />
using System;
using LibraryService.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryService.Infastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibraryService.Domain.Entities.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccountNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AccountId");

                    b.HasAlternateKey("AccountNum");

                    b.ToTable("account");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("BookNum")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<string>("Pagination")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PublicationDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PublicationLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ISBN");

                    b.ToTable("book");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookAuthor", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ISBN", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("bookauthor");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BookISBN")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CopyNum")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Format")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsReferenceOnly")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BookISBN");

                    b.ToTable("bookcopy");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookPublisher", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ISBN", "PublisherId");

                    b.HasIndex("PublisherId");

                    b.ToTable("bookpublisher");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookSubject", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ISBN", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("booksubject");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<string>("BookISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateBorrowed")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateReturned")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookCopyId");

                    b.ToTable("loan");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("publisher");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("BookCopyId")
                        .HasColumnType("int");

                    b.Property<string>("BookISBN")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BookTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("NeededBy")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookCopyId");

                    b.ToTable("reservation");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("subject");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Book", b =>
                {
                    b.OwnsOne("LibraryService.Domain.ValueObjects.BookClassification", "Classification", b1 =>
                        {
                            b1.Property<string>("BookISBN")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("DDC")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("LCC")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookISBN");

                            b1.ToTable("book");

                            b1.WithOwner()
                                .HasForeignKey("BookISBN");
                        });

                    b.OwnsOne("LibraryService.Domain.ValueObjects.BookIdentifier", "Identifier", b1 =>
                        {
                            b1.Property<string>("BookISBN")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("ISBN_10")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("ISBN_13")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("LCCN")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("OCLC")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("OLID")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("BookISBN");

                            b1.ToTable("book");

                            b1.WithOwner()
                                .HasForeignKey("BookISBN");
                        });

                    b.Navigation("Classification")
                        .IsRequired();

                    b.Navigation("Identifier")
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookAuthor", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryService.Domain.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookCopy", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LibraryService.Domain.ValueObjects.Rack", "Rack", b1 =>
                        {
                            b1.Property<int>("BookCopyId")
                                .HasColumnType("int");

                            b1.Property<string>("LocationCode")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("StackNumber")
                                .HasColumnType("int");

                            b1.HasKey("BookCopyId");

                            b1.ToTable("rack", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BookCopyId");
                        });

                    b.Navigation("Book");

                    b.Navigation("Rack")
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookPublisher", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Book", "Book")
                        .WithMany("BookPublishers")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryService.Domain.Entities.Publisher", "Publisher")
                        .WithMany("BookPublishers")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookSubject", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Book", "Book")
                        .WithMany("BookSubjects")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryService.Domain.Entities.Subject", "Subject")
                        .WithMany("BookSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Loan", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Account", "Account")
                        .WithMany("Loans")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryService.Domain.Entities.BookCopy", "BookCopy")
                        .WithMany("Loans")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LibraryService.Domain.ValueObjects.Fine", "Fine", b1 =>
                        {
                            b1.Property<int>("LoanId")
                                .HasColumnType("int");

                            b1.Property<string>("AccountId")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(6, 2)");

                            b1.Property<DateTime?>("FineDate")
                                .HasColumnType("datetime(6)");

                            b1.Property<bool>("FineIssued")
                                .HasColumnType("tinyint(1)");

                            b1.HasKey("LoanId");

                            b1.ToTable("loan");

                            b1.WithOwner()
                                .HasForeignKey("LoanId");
                        });

                    b.Navigation("Account");

                    b.Navigation("BookCopy");

                    b.Navigation("Fine");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("LibraryService.Domain.Entities.Account", "Account")
                        .WithMany("Reservations")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryService.Domain.Entities.BookCopy", "BookCopy")
                        .WithMany("Reservations")
                        .HasForeignKey("BookCopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("BookCopy");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Account", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookCopies");

                    b.Navigation("BookPublishers");

                    b.Navigation("BookSubjects");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.BookCopy", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Publisher", b =>
                {
                    b.Navigation("BookPublishers");
                });

            modelBuilder.Entity("LibraryService.Domain.Entities.Subject", b =>
                {
                    b.Navigation("BookSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
