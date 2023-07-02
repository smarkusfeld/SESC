using LibraryService.Application.Models;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using LibraryService.Application.Interfaces.Services;
using LibraryService.Application.Common.Exceptions;

namespace LibraryService.Application.Services
{
    public class ISBNService : IISBNService
    {
        private readonly HttpClient _httpClient;
        
        public ISBNService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://openlibrary.org/api/");

            // using Microsoft.Net.Http.Headers;
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/json");
        }
             

        public async Task<NewBookRecordDTO> GetBookDetails(string isbn)
        {
            HttpResponseMessage Res = await _httpClient.GetAsync("books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json");
            List<string> details = new()
            {
                "Resquest Message: " + Res.RequestMessage,
                "Response Header: " + Res.Headers,
                "Reponse Body: " + Res.Content.ReadAsStringAsync().Result,
            };

            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var json = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api 
                JObject jsonObject = JObject.Parse(json);
                var data = jsonObject.SelectToken("ISBN:" + isbn).ToString();
                var result = JsonConvert.DeserializeObject<NewBookRecordDTO>(data, new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore });

                if (result != null)
                {
                    return result;
                }
                throw new BadRequestException("Unable to parse open library record");
            }

            string message = Res.ReasonPhrase ?? "Unsuccessful Request to OpenLibraryApi";

            throw new InvalidResponseException(message, details);
        }

        public void Dispose() => _httpClient?.Dispose();

    }
}
