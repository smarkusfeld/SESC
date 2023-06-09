using LibraryService.Application.DTOs;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace LibraryService.Application.Services
{
    public class OpenLibraryService
    {
        private readonly HttpClient _httpClient;

        public OpenLibraryService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("http://openlibrary.org/api/");

            // using Microsoft.Net.Http.Headers;
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/json");
        }
        public async Task<OpenLibraryRecord?> GetBookDetailsAsync(string isbn) 
        {
           HttpResponseMessage Res = await _httpClient.GetAsync("books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json");
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api
                var json = Res.Content.ReadAsStringAsync().Result;
                //Deserializing the response recieved from web api 
                JObject jsonObject = JObject.Parse(json);
                var data = jsonObject.SelectToken("ISBN:" + isbn).ToString();
                return JsonConvert.DeserializeObject<OpenLibraryRecord>(data, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });

            }
            return null;
        }

        public async Task<string> GetBookAsync(string isbn)
        {
            try
            {
                HttpResponseMessage Res = await _httpClient.GetAsync("books?bibkeys=ISBN:" + isbn + "&jscmd=data&format=json");
                return Res.Content.ReadAsStringAsync().Result;
            }
            catch
            {
                return null;
            }
        }
        public as
        
    }
}
