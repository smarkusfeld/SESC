using LibraryService.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.ValueObjects
{
    /// <summary>
    /// The fine value object represents the fine values associated with the loan entity
    /// </summary>
    public class Fine : ValueObject
    {
        public DateTime? FineDate { get; private set; } = null!;

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Amount { get; private set; } = new decimal(0);
        public string AccountId { get; private set; }
        public bool FineIssued { get; private set; } = false;
        public Fine() { }
        public Fine(DateTime date, decimal amount, string accountId)
        {
            FineDate = date;
            Amount = amount;
            FineIssued = true;
            AccountId = accountId;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            if (FineDate != null) { yield return FineDate; }
            yield return Amount;
            yield return FineIssued;

        }
        public void FineNotIssued()
        {
            FineIssued = false;
        }
    }
}
