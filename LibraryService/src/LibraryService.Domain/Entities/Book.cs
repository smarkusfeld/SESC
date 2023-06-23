using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Interfaces;
using LibraryService.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Book Aggregate Entity
    /// </summary>
    [Table("book")]
    public class Book : BaseAuditableEntity, IAggregateRoot
    {
        public override object Key  => ISBN;

        public Book(string isbn, string title, BookDetail detail, BookClassification classification, BookIdentifier identifier) 
        {
                ISBN = isbn;
                Title = title;
                Detail = detail;
                Classification = classification;
                Identifier = identifier;
        }

        [Key]
        public string ISBN { get; private set; }
        public int BookNum { get; set; }
        public string Title { get;set; }
        public int Year { get; set; }
        public BookDetail Detail { get;  private set; }
        public BookClassification Classification { get; private set; } 
        public BookIdentifier Identifier { get; private set; }

        //backing fields for collections
        //private readonly List<BookSubject> _subjects = new();
        //private readonly List<BookPublisher> _publishers = new();
        //private readonly List<BookAuthor> _authors = new();
        //private readonly List<BookCopy> _copies = new();
        //public ICollection<BookSubject> BookSubjects => _subjects;        
        // public ICollection<BookPublisher> BookPublishers => _publishers;        
        //public ICollection<BookAuthor> BookAuthors => _authors;        
        //public ICollection<BookCopy> BookCopies => _copies;

        //navigation properties
        public ICollection<BookCopy> BookCopies { get; private set; } = new List<BookCopy>();
        public ICollection<BookSubject> BookSubjects { get; private set; } = new List<BookSubject>();
        public ICollection<BookPublisher> BookPublishers { get; private set; } = new List<BookPublisher>();
        public ICollection<BookAuthor> BookAuthors { get; private set; } = new List<BookAuthor>();

        //not mapped properties and methods
        public int TotalCount => BookCopies.Count();
        public int AvailableCopies => BookCopies.Where(x => x.IsAvailable == true).Count();

        /// <summary>
        /// Method to create new bookauthor record and attach to the book entity
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="name"></param>
        public void AddBookAuthor(int authorId, string name)
        {
            int number = BookAuthors.Count + 1;
            BookAuthors.Add(new BookAuthor(number,ISBN, authorId, name));
        }
        /// <summary>
        /// Method to create new bookpublisher record and attach to the book entity
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="name"></param>
        public void AddBookPublisher(int publisherId, string name)
        {
            int number = BookPublishers.Count + 1;
            BookPublishers.Add(new BookPublisher(number, ISBN, publisherId, name));
        }
        /// <summary>
        /// Method to create new booksubject record and attach to the book entity
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="name"></param>
        public void AddBookSubject(int subjectId, string name)
        {
            BookSubjects.Add(new BookSubject(ISBN, subjectId, name));
        }
        /// <summary>
        /// Method to remove bookauthor record and attach to the book entity
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="name"></param>
        public void RemoveBookAuthor(int id)
        {
            var bookAuthors = BookAuthors.Where(x => x.AuthorId == id);
            foreach (BookAuthor bookAuthor in bookAuthors)
            {
                bookAuthor.Book = null; 
                //bookAuthor.ISBN = null;
                //BookAuthors.Remove(bookAuthor); 
            }
            
        }
        /// <summary>
        /// Method to  remove bookpublisher record and attach to the book entity
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="name"></param>
        public void RemoveBookPublisher(int id)
        {
            var bookPubs = BookPublishers.Where(x => x.PublisherId == id);
            foreach (BookPublisher bookPub in bookPubs)
            {
                bookPub.Book = null; 
            }
        }
        /// <summary>
        /// Method to remove booksubject record and attach to the book entity
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="name"></param>
        public void RemoveBookSubject(int id)
        {
            var bookSubjects = BookSubjects.Where(x => x.SubjectId == id);
            foreach(BookSubject bookSubject in bookSubjects)
            {
                bookSubject.Book = null;
            }
        }
        /// <summary>
        /// Method to Update Book Detail
        /// </summary>
        /// <param name="newDetail"></param>
        public void UpdateDetail(BookDetail newDetail)
        {
            if (newDetail == Detail)
            {
                return;
            }
            else
            {
                //add validation
                Detail = newDetail;
            }
        }
        /// <summary>
        /// Method to Update Book Classification
        /// </summary>
        /// <param name="newClassification"></param>
        public void UpdateClassification(BookClassification newClassification)
        {
            if (newClassification == Classification)
            {
                return;
            }
            else
            {
                //add validation
                Classification = newClassification;
            }
        }
        /// <summary>
        /// Method to Update Book Identifier
        /// </summary>
        /// <param name="newIdentifier"></param>
        public void UpdateIdentifier(BookIdentifier newIdentifier)
        {
            if (newIdentifier == Identifier)
            {
                return;
            }
            else
            {
                //add validation
                Identifier = newIdentifier;
            }
        }
        /// <summary>
        /// Method to add new book copy quickly
        /// </summary>
        public void AddBookCopy()
        {
            int number = TotalCount + 1;
            BookCopy copy = new BookCopy(ISBN, number);
            BookCopies.Add(copy);
        }
        /// <summary>
        /// Method to add new book copy add with addtional details
        /// </summary>
        public void AddBookCopy(bool refOnly, BookFormat format, Rack rack)
        {

            int number = TotalCount + 1;
            BookCopy copy = new BookCopy(ISBN, number);
            copy.Format = format;
            copy.Rack = rack;

            copy.IsReferenceOnly = refOnly;
            BookCopies.Add(copy);
        }

        /// <summary>
        /// Method to update book author order
        /// </summary>
        public void SetAuthorOrder(int number)
        {
            ///todo 
        }

    }

}
