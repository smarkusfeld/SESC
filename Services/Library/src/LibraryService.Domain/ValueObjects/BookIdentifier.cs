using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.ValueObjects
{
    /// <summary>
    /// The classification value object represents the identification properities of the book entity
    /// </summary>
    public class BookIdentifier : ValueObject
    {
        /// <summary>
        /// 10-Digit International Standard Book Number 
        /// </summary>
        public string ISBN_10 { get; private set; } = null!;
        /// <summary>
        /// 13-Digit International Standard Book Number 
        /// </summary>
        public string ISBN_13 { get; private set; } = null!;
        /// <summary>
        /// Library of Congress Control Number 
        /// </summary>
        public string LCCN { get; private set; } = null!;
        /// <summary>
        /// WorldCat Identifier
        /// </summary>
        public string OCLC { get; private set; } = null!;
        /// <summary>
        /// OpenLibrary Identifier
        /// </summary>
        public string OLID { get; private set; } = null!;
        public BookIdentifier() { }
        public BookIdentifier(string isbn10, string isbn13, string lccn, string oclc, string olid)
        {
            ISBN_10 = isbn10;
            ISBN_13 = isbn13;
            LCCN = lccn;
            OCLC = oclc;
            OLID = olid;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // return each element one at a time
            yield return ISBN_10;
            yield return ISBN_13;
            yield return LCCN;
            yield return OCLC;
            yield return OLID;
        }
    }
}
