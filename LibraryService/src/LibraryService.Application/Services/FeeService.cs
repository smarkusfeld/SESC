using LibraryService.Application.Interfaces.Services;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryService.Application.Services
{
    public class FeeService : IFeeService
    {
        private readonly HttpClient _httpClient;

        public FeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //FIX!!!
            _httpClient.BaseAddress = new Uri("http://localhost:64195/");

            // using Microsoft.Net.Http.Headers;
            _httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/json");
        }
    }
}
