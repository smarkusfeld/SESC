using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.ValueObjects
{
    /// <summary>
    /// The book detail value object represents the descriptive aspect of the book entity
    /// </summary>
    public class  BookDetail : ValueObject
    {
        public string Edition { get; private set; }
        public string Weight { get; private set; }
        public int PageCount { get; private set; }
        public string Pagination { get; private set; }
        public string PublicationLocation { get; private set; }
        public string PublicationDate { get; private set; }
        public BookDetail() { }
        public BookDetail(string edition, string weight,int pages, string pagination, string publocation, string pubdate)
        {
            Edition = edition;
            Weight = weight;
            PageCount = pages;
            Pagination = pagination;
            PublicationLocation = publocation;
            PublicationDate = pubdate;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Edition;
            yield return Weight;
            yield return PageCount;
            yield return Pagination;
            yield return PublicationLocation;
            yield return PublicationDate;

        }
    }
}
