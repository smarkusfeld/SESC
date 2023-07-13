using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Win32;
using System.Text.Json;
using System.Text;
using System.Diagnostics;

namespace StudentPortal.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserService> _logger;
        public UserService(HttpClient httpClient, ILogger<UserService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Register new student user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> RegisterStudent(UserRegistrationModel userModel)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(userModel),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage Res = await _httpClient.PostAsync("auth/register", jsonContent);
            var json = Res.Content.ReadAsStringAsync().Result;
            if (Res.IsSuccessStatusCode)
            {                
                return ResponseModel.Success(json);
                    //;
            }
            return ResponseModel.Failed((int)Res.StatusCode, json);
        }

    }
}