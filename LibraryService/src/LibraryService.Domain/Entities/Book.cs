using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.Common.Interfaces;
using LibraryService.Domain.ValueObjects;
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
    public class Book : BaseAuditableEntity, IAggregateRoot
    {
        public Book(string isbn, string title, int year)
        {
           ISBN = isbn;
           Title = title;
            Year = year;
        }
        public override object Key  => ISBN;
        public string ISBN { get; private set; }
        public int BookNum { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public BookDetail? Detail { get;  private set; }
        public BookClassification? Classification { get; private set; } 
        public BookIdentifier? Identifier { get; private set; }

        //backing fields for collections
        private readonly List<BookSubject> _subjects = new();
        private readonly List<BookPublisher> _publishers = new();
        private readonly List<BookAuthor> _authors = new();
        private readonly List<BookCopy> _copies = new();
        public ICollection<BookSubject> BookSubjects => _subjects;        
        public ICollection<BookPublisher> BookPublishers => _publishers;        
        public ICollection<BookAuthor> BookAuthors => _authors;        
        public ICollection<BookCopy> BookCopies => _copies;
        public int TotalCount => _copies.Count();
        public int AvailableCopies => _copies.Where(x => x.IsAvailable == true).Count();
        /// <summary>
        /// Method to create new bookauthor record and attach to the book entity
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="name"></param>
        public void AddBookAuthor(int authorId, string name)
        {
            int number = _authors.Count + 1;            
            _authors.Add(new BookAuthor(number,ISBN, authorId, name));
        }
        /// <summary>
        /// Method to create new bookpublisher record and attach to the book entity
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="name"></param>
        public void AddBookPublisher(int publisherId, string name)
        {
            int number = _publishers.Count + 1;
            _publishers.Add(new BookPublisher(number, ISBN, publisherId, name));
        }
        /// <summary>
        /// Method to create new booksubject record and attach to the book entity
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="name"></param>
        public void AddBookSubject(int subjectId, string name)
        {
            _subjects.Add(new BookSubject(ISBN, subjectId, name));
        }
        /// <summary>
        /// Method to remove bookauthor record and attach to the book entity
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="name"></param>
        public void RemoveBookAuthor(int id)
        {
            _authors.RemoveAll(x => x.AuthorId == id);
        }
        /// <summary>
        /// Method to  remove bookpublisher record and attach to the book entity
        /// </summary>
        /// <param name="publisherId"></param>
        /// <param name="name"></param>
        public void RemoveBookPublisher(int id)
        {
            _publishers.RemoveAll(x => x.PublisherId == id);
        }
        /// <summary>
        /// Method to remove booksubject record and attach to the book entity
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="name"></param>
        public void RemoveBookSubject(int id)
        {
            _subjects.RemoveAll(x => x.SubjectId == id);
        }
        /// <summary>
        /// Method to add book detail
        /// </summary>
        /// <param name="detail"></param>
        public void AddDetail(BookDetail detail)
        {
            //add validation
            Detail = detail;
        }
        /// <summary>
        /// Method to add book classification
        /// </summary>
        /// <param name="classification"></param>
        public void AddClassification(BookClassification classification)
        {
            //add validation
            Classification = classification;
        }
        /// <summary>
        /// Method to add book identifier
        /// </summary>
        /// <param name="identifier"></param>
        public void AddDClassification(BookIdentifier identifier)
        {
            //add validation
            Identifier = identifier;
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
        public void BookCopy()
        {
            int number = TotalCount + 1;
            BookCopy copy = new BookCopy(ISBN, number);
            _copies.Add(copy);
        }
        /// <summary>
        /// Method to add new book copy add with addtional details
        /// </summary>
        public void BookCopy(bool refOnly, BookFormat format, Rack rack)
        {

            int number = TotalCount + 1;
            BookCopy copy = new BookCopy(ISBN, number);
            copy.Format = format;
            copy.Rack = rack;
            copy.IsReferenceOnly = refOnly;
            _copies.Add(copy);
        }

    }

}
