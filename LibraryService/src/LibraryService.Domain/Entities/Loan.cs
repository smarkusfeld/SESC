using LibraryService.Domain.Common;
using LibraryService.Domain.Common.Enums;
using LibraryService.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace LibraryService.Domain.Entities
{
    /// <summary>
    /// Loan Entity
    /// </summary>
    [Table("loan")]
    public class Loan : BaseAuditableEntity
    {       
        public Loan() { }
        public Loan(DateTime dueDate, string bookISBN, string bookTitle, string accountId, int bookCopyId)
        {            
            DateBorrowed = DateTime.Now;
            DueDate = dueDate;
            BookISBN = bookISBN;
            BookTitle = bookTitle;
            AccountId = accountId;
            BookCopyId = bookCopyId;


        }

        public override object Key => Id;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public Account Account { get; set; } = null!;
        public BookCopy BookCopy { get; set; } = null!;

        private LoanStatus _status; 
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
                        _status = LoanStatus.Active;
                    }
                    else if (result == 0)
                    {
                        _status = LoanStatus.Due;
                    }
                    else if (result < 0)
                    {
                        _status = LoanStatus.Overdue;
                    }
                }
                else
                { _status = LoanStatus.Completed; }
                return _status;
            }
            private set { _status = value; }
            
        }        
        public void AddFine(DateTime date, Decimal amount)
        {
            //fix up and add validatiors
            Fine = new Fine(date, amount, AccountId);
        }

    }
}
