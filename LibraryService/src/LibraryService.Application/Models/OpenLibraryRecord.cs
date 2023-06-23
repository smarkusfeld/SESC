using LibraryService.Domain.Entities;
using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryService.Application.Models
{
    /// <summary>
    /// Class contains all the data from the openlibrary request
    /// </summary>
    /// 

    public class OpenLibraryRecord
    {
        

        [JsonPropertyName("title")]
        public string? Title { get; set; }        

        [JsonPropertyName("Number_of_pages")]
        public int PageCount { get; set; }

        [JsonPropertyName("pagination")]
        public string? Pagination { get; set; } 

        [JsonPropertyName("weight")]
        public string? Weight { get; set; } 

        [JsonPropertyName("Identifiers")]
        public BookIdentifierDTO Identifiers { get; set; } = new BookIdentifierDTO();

        [JsonPropertyName("Classifications")]
        public BookClassificationDTO? Classifications { get; set; }

        [JsonPropertyName("Authors")]
        public List<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();

        [JsonPropertyName("Publishers")]
        public List<PublisherDTO> Publishers { get; set; } = new List<PublisherDTO>();

        [JsonPropertyName("Publish_places")]
        public List<PublishPlaceDTO> Publish_places { get; set; } = new List<PublishPlaceDTO>();

        [JsonPropertyName("publish_date")]
        public string PublicationDate { get; set; } 

        [JsonPropertyName("Subjects")]
        public List<SubjectDTO> Subjects { get; set; } = new List<SubjectDTO>();



        private string? _isbn;
        public string Edition { get; private set; } = string.Empty;
        
        public int TotalCount { get; private set; }
        public int AvailableCopies { get; private set; }
        
        public int Year
        {
            get
            {
                //TODO fix validation
                if(PublicationDate != null && PublicationDate.Length >= 4)
                {
                    int.TryParse(PublicationDate.Substring(PublicationDate.Length - 4), out int year);
                    return year;
                }
                return 0;
                
            }            
        }
       /// <summary>
       /// ISBN property, if not set it will return the primary identifier according to the <seealso cref="BookIdentifierDTO"/>
       /// </summary>
        public string ISBN => _isbn ?? Identifiers.PrimaryIdentifier ?? string.Empty;
        
        public string PublicationLocation
        {
            get
            {
                string location = string.Empty;
                if(Publish_places.Count > 0)
                {
                    foreach (PublishPlaceDTO place in Publish_places)
                    {
                        location += place.Name + ',';
                    }
                }                
                return location;
            }
            set
            {
                var names = new List<string>(value.Split(','));
                foreach (string name in names) 
                {
                    Publish_places.Add(new PublishPlaceDTO { Name = name });
                }
                
           
            }
        }
    }




    

 

   
    



}
