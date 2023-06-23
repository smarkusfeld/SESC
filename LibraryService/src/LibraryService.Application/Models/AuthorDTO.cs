using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryService.Application.Models
{
    public class AuthorDTO
    {
        public string Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }

        public string Name
        {
            get => string.Concat(FirstName, MiddleName, LastName);
            set => ParseName(value);
        }

        public void ParseName(string name)
        {
            string[] names = name.Split(' ');
            if (names.Length == 2)
            {
                FirstName = names[0];
                LastName = names[1];
                MiddleName = " ";
            }
            else if (name.Length > 2)
            {
                int last = name.Length - 1;
                FirstName = names[0];
                LastName = names[last];
                for (int i = 1; i < last; i++)
                {
                    MiddleName += name[i] + " ";
                }
            }
            else
            {
                LastName = names[0];
                FirstName = "";
                MiddleName = "";
            }
        }
       
       
    }
}
