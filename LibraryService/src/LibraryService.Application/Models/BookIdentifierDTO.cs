using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class BookIdentifierDTO
    {
        public List<string> isbn_10 { get; set; } = new List<string>();
        public List<string> isbn_13 { get; set; } = new List<string>();
        public List<string> lccn { get; set; } = new List<string>();
        public List<string> oclc { get; set; } = new List<string>();
        public List<string> openlibrary { get; set; } = new List<string>();

        public string PrimaryIdentifier 
        {

            get
            {
                if (ISBN_13 != "-")
                {
                    return ISBN_13;
                }
                return ISBN_10;
            }
        }

        public string ISBN_10
        {
            get
            {
                if (isbn_10.Count == 0)
                {
                    return "-";
                }
                else 
                {
                    return string.Join(" , ", isbn_10).Trim();
                }
                
            }
            set
            {
                isbn_10 = new List<string>(value.Split(','));
            }
        }

        public string ISBN_13
        {
            get
            {
                if (isbn_13.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", isbn_13).Trim();
                }

            }
            set
            {
                isbn_13 = new List<string>(value.Split(','));
            }
        }
        public string LCCN
        {
            get
            {
                if (lccn.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", lccn).Trim();
                }

            }
            set
            {
                lccn = new List<string>(value.Split(','));
            }
        }
        public string OCLC
        {
            get
            {
                if (oclc.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", oclc).Trim();
                }

            }
            set
            {
                oclc = new List<string>(value.Split(','));
            }
        }
        public string OLID
        {
            get
            {
                if (openlibrary.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", openlibrary).Trim();
                }

            }
            set
            {
                openlibrary = new List<string>(value.Split(','));
            }
        }
        
    }
}
