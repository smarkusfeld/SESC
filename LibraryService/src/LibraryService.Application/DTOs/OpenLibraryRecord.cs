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
        public Dictionary<string, BookIdentifierDTO> Identifiers { get; set; }

        [JsonPropertyName("Classifications")]
        public Dictionary<string, BookClassificationDTO> Classifications { get; set; }

        [JsonPropertyName("Publishers")]
        public List<PublisherDTO> Publishers { get; set; }

        [JsonPropertyName("Publish_places")]
        public List<PublishPlaceDTO> Publish_places { get; set; }
        public string Publish_date { get; set; }

        [JsonPropertyName("Subjects")]
        public List<SubjectDTO> Subjects { get; set; }
    }




    

 

   
    



}
