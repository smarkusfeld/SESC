using LibraryService.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Domain.ValueObjects
{
    /// <summary>
    /// The rack value object represent the physical location of the book copy
    /// </summary>
    public class Rack : ValueObject 
    {
        public int StackNumber { get; private set; } = 0;
        public string LocationCode { get; private set; } = null!;
        public Rack() { }
        public Rack(int num, string location)
        {
            StackNumber = num;
            LocationCode = location;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StackNumber; 
            yield return LocationCode;
        }
    }
}
