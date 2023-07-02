using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryService.Domain.Common;

namespace LibraryService.Domain.ValueObjects
{
    /// <summary>
    /// The classification value object represents the classification properities of the book entity
    /// </summary>
    public class BookClassification : ValueObject
    {
        /// <summary>
        /// Dewey Decimal Classiciation
        /// </summary>
        public string DDC { get; private set; } = null!;

        /// <summary>
        /// Library of Congress Classfication
        /// </summary>
        public string LCC { get; private set; } = null!;
        public BookClassification() { }
        public BookClassification(string ddc, string lcc) 
        {
            DDC = ddc;
            LCC = lcc;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // return each element one at a time
            yield return DDC;
            yield return LCC;
        }
    }
}
