using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Models
{
    public class BookClassificationDTO
    {

        public List<string> lc_classifications { get; set; } = new List<string>();
        public List<string> dewey_decimal_class { get; set; } = new List<string>();

        public string DDC
        {
            get
            {
                if (dewey_decimal_class.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", dewey_decimal_class).Trim();
                }

            }
            set
            {
                dewey_decimal_class = new List<string>(value.Split(','));
            }
        }
        public string LCC
        {
            get
            {
                if (lc_classifications.Count == 0)
                {
                    return "-";
                }
                else
                {
                    return string.Join(" , ", lc_classifications).Trim();
                }

            }
            set
            {
                lc_classifications = new List<string>(value.Split(','));
            }
        }


    }
}
