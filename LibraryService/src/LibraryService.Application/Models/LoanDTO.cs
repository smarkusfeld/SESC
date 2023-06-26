using LibraryService.Domain.Common.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class LoanDTO
    {
        public int Id { get; private set; }
        public bool IsComplete { get; set; } = false;
        public DateTime DateBorrowed { get; private set; }
        public DateTime DueDate { get; private set; }
        public DateTime? DateReturned { get; set; } = null;
        public string BookISBN { get; private set; }
        public string BookTitle { get; private set; }
        public string AccountId { get; private set; }
        public int BookCopyId { get; private set; }
        public int BookCopyID { get; set; }

        public FineDTO? Fine { get; private set; }
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
    }
}
