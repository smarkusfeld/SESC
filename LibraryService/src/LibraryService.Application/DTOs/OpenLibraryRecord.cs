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
        public string? Url { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int Number_of_pages { get; set; }
        public string Pagination { get; set; }
        public string Weight { get; set; }
        public string By_statement { get; set; }
        public Identifiers Identifiers { get; set; }
        public Classifications Classifications { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<PublishPlace> Publish_places { get; set; }
        public string Publish_date { get; set; }
        public List<Subject> Subjects { get; set; }
        public string Notes { get; set; }
        public List<TableOfContent> Table_of_contents { get; set; }
        public List<Link> Links { get; set; }
        public List<Ebook> Ebooks { get; set; }
        public Cover Cover { get; set; }
    }
    public class Author
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public class Classifications
    {
        public List<string> Lc_classifications { get; set; }
        public List<string> Dewey_decimal_class { get; set; }
    }

    public class Cover
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
    }

    public class Ebook
    {
        public string Preview_url { get; set; }
        public string Availability { get; set; }
        public Formats Formats { get; set; }
        public string Borrow_url { get; set; }
        public bool Checkedout { get; set; }
    }

    public class Formats
    {
    }

    public class Identifiers
    {
        public List<string> Amazon { get; set; }
        public List<string> Google { get; set; }
        public List<string> Librarything { get; set; }
        public List<string> Boodreads { get; set; }
        public List<string> Isbn_10 { get; set; }
        public List<string> Isbn_13 { get; set; }
        public List<string> Lccn { get; set; }
        public List<string> Oclc { get; set; }
        public List<string> Openlibrary { get; set; }
    }
    public class Link
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class Publisher
    {
        public string Name { get; set; }
    }

    public class PublishPlace
    {
        public string Name { get; set; }
    }
    public class Subject
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class TableOfContent
    {
        public int Level { get; set; }
        public string Label { get; set; }
        public string Title { get; set; }
        public string Pagenum { get; set; }
    }


}
