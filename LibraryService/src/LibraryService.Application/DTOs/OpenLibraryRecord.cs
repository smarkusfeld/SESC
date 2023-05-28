using LibraryService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryService.Application.DTOs
{
    /// <summary>
    /// Class contains all the data from the openlibrary request
    /// </summary>
    /// 

    public class OpenLibraryRecord
    {

        public string Title { get; set; }

        [JsonPropertyName("Authors")]
        public List<AuthorDTO> Authors { get; set; }
        public int Number_of_pages { get; set; }
        public string Pagination { get; set; }
        public string Weight { get; set; }

        [JsonPropertyName("Identifiers")]
        public OpenLibraryIdentifier Identifiers { get; set; }
        //public Dictionary<string, List<string>> Identifiers { get; set; }

        [JsonPropertyName("Classifications")]
        public OpenLibraryClassification Classifications { get; set; }
        //public Dictionary<string, List<string>> Classifications { get; set; }

        [JsonPropertyName("Publishers")]
        public List<PublisherDTO> Publishers { get; set; }

        [JsonPropertyName("Publish_places")]
        public List<PublishPlaceDTO> Publish_places { get; set; }
        public string Publish_date { get; set; }

        [JsonPropertyName("Subjects")]
        public List<SubjectDTO> Subjects { get; set; }
    }

    public class OpenLibraryIdentifier
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

    public class OpenLibraryClassification
    {
        public List<string> lc_classifications { get; set; }
        public List<string> dewey_decimal_class { get; set; }
    }

    public class PublisherDTO
    {
        public string Name { get; set; }
    }

    public class PublishPlaceDTO
    {
        public string Name { get; set; }
    }
    public class SubjectDTO
    {
        public string Name { get; set; }
        // public string Url { get; set; }
    }

   
    



}
