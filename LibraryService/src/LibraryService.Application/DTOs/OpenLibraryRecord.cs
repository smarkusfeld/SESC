using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.DTOs
{
    /// <summary>
    /// Class contains all the data from the openlibrary request
    /// </summary>
    /// 
   
    public class OpenLibraryRecord
    {
        public string Url { get; set; }
        public string key { get; set; }
        public string title { get; set; }
        public List<Author> authors { get; set; }
        public int number_of_pages { get; set; }
        public string pagination { get; set; }
        public string weight { get; set; }
        public string by_statement { get; set; }
        public Identifiers identifiers { get; set; }
        public Classifications classifications { get; set; }
        public List<Publisher> publishers { get; set; }
        public List<PublishPlace> publish_places { get; set; }
        public string publish_date { get; set; }
        public List<Subject> subjects { get; set; }
        public string notes { get; set; }
        public List<TableOfContent> table_of_contents { get; set; }
        public List<Link> links { get; set; }
        public List<Ebook> ebooks { get; set; }
        public Cover cover { get; set; }
    }
    public class Author
    {
        public string url { get; set; }
        public string name { get; set; }
    }

    public class Classifications
    {
        public List<string> lc_classifications { get; set; }
        public List<string> dewey_decimal_class { get; set; }
    }

    public class Cover
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
    }

    public class Ebook
    {
        public string preview_url { get; set; }
        public string availability { get; set; }
        public Formats formats { get; set; }
        public string borrow_url { get; set; }
        public bool checkedout { get; set; }
    }

    public class Formats
    {
    }

    public class Identifiers
    {
        public List<string> amazon { get; set; }
        public List<string> google { get; set; }
        public List<string> librarything { get; set; }
        public List<string> goodreads { get; set; }
        public List<string> isbn_10 { get; set; }
        public List<string> isbn_13 { get; set; }
        public List<string> lccn { get; set; }
        public List<string> oclc { get; set; }
        public List<string> openlibrary { get; set; }
    }
    public class Link
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Publisher
    {
        public string name { get; set; }
    }

    public class PublishPlace
    {
        public string name { get; set; }
    }
    public class Subject
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class TableOfContent
    {
        public int level { get; set; }
        public string label { get; set; }
        public string title { get; set; }
        public string pagenum { get; set; }
    }


}
