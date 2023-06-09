using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.DataModels;
using LibraryService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.Entities
{
    public class Loan : BaseAuditableEntity
    {
        public Loan(int id, DateTime dueDate, string bookISBN, string bookTitle, string accountId, int bookCopyId)
        {
            Id = id;
            DateBorrowed = DateTime.Now;
            DueDate = dueDate;
            BookISBN = bookISBN;
            BookTitle = bookTitle;
            AccountId = accountId;
            BookCopyId = bookCopyId;
            
        }

        public override object Key => Id;
        public int Id { get; private set; }
        public bool IsComplete { get;set; } = false;
        public DateTime DateBorrowed { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? DateReturned { get; set; } = null;
        public string BookISBN { get; private set; }
        public string BookTitle { get; private set; }
        public string AccountId { get; private set; }
        public int BookCopyId { get; private set; }
        public Fine? Fine { get; private set; }
        public AccountModel Account { get; set; } = null!;
        public BookCopyModel BookCopy { get; set; } = null!;

        public LoanStatus Status
        {
            get
            {
                if (!IsComplete)
                {
                    DateTime now = DateTime.Now.Date;
                    DateTime due = DueDate.Date;
                    int result = DateTime.Compare(due, now);

                    if (result > 0)
                    {
                        return LoanStatus.Active;
                    }
                    else if (result == 0)
                    {
                        return LoanStatus.Due;
                    }
                    else if (result < 0)
                    {
                        return LoanStatus.Overdue;
                    }
                }
                return LoanStatus.Completed;
            }            
        }
        
        public void AddFine(DateTime date, Decimal amount)
        {
            //fix up and add validatiors
            Fine = new Fine(date, amount, AccountId);
        }

    }
}
