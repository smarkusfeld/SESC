using StudentPortal.Models;
using System.Text.Json;
using System.Text;
using NuGet.Common;
using NuGet.Protocol.Plugins;
using static StudentPortal.Models.LoginResponseModel;
using System.Net.Http.Json;
using System.Reflection;

namespace StudentPortal.Services
{
    /// <summary>
    /// Provides logic for interacting the Identity Microservice
    /// </summary>
    public class IdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IdentityService> _logger;

        /// <summary>
        /// Typed Http Client for interacting with Identity Microservice
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="logger"></param>
        public IdentityService(HttpClient httpClient, ILogger<IdentityService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Register a new student user using the Finance Microservice
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <seealso cref="ResponseModel"/> with the json result from the Idenity service.
        /// <br></br>If the operation was successful, the <seealso cref="ResponseModel.ResultContent"/> contains a <seealso cref="UserRegisteredModel"/> for the user
        /// <br></br>If the operation was unsuccessful, the  <seealso cref="ResponseModel.ResultContent"/> contains the public errors from the Identity Service</returns>
        public async Task<ResponseModel> RegisterStudent(UserRegistrationModel userModel)
        {
            _logger.LogInformation("Creating Registration Request for Identity Service");
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(userModel),
                Encoding.UTF8,
                "application/json");
            _logger.LogInformation("Sending Registration Request to Identity Service");
            HttpResponseMessage Res = await _httpClient.PostAsync("auth/register", jsonContent);
            var json = Res.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("Received Identity Serivce Response");
            if (Res.IsSuccessStatusCode)
            {
                return ResponseModel.SuccessResult(json);
            }
            return ResponseModel.FailedResult((int)Res.StatusCode, json);
        }

        /// <summary>
        /// Validate user login using the Identity Microservice and get a JWT token for Microservice authorization
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <seealso cref="ResponseModel"/> with the json result from the Idenity service.
        /// <br></br>If the operation was successful, the <seealso cref="ResponseModel.ResultContent"/> contains a <seealso cref="LoginResponseModel"/> for the user
        /// <br></br>If the operation was unsuccessful, the  <seealso cref="ResponseModel.ResultContent"/> contains the public errors from the Identity Service</returns>
        public async Task<ResponseModel> StudentLogin(LoginModel model)
        {
            _logger.LogInformation("Creating Login Request for Identity Service");
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
            _logger.LogInformation("Sending Login Request to Identity Service");
            HttpResponseMessage Res = await _httpClient.PostAsync("auth/login", jsonContent);
            var json = Res.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("Received Identity Serivce Response");
            if (Res.IsSuccessStatusCode)
            {
                var response = new LoginResponseModel { Username = model.Username, Token = json, UserHome = UserRoleIndex.Student };
                return ResponseModel.SuccessResult(JsonSerializer.Serialize(response));                
            }
            return ResponseModel.FailedResult((int)Res.StatusCode, json);
        }

        /// <summary>
        /// Get user profile from Identity Microservice
        /// </summary>
        /// <param name="username"></param>
        /// <returns>A <seealso cref="ResponseModel"/> with the json result from the Idenity service.
        /// <br></br>If the operation was successful, the <seealso cref="ResponseModel.ResultContent"/> contains a <seealso cref="ContactModel"/> for the user
        /// <br></br>If the operation was unsuccessful, the  <seealso cref="ResponseModel.ResultContent"/> contains the public errors from the Identity Service</returns>
        public async Task<ResponseModel> GetUserProfile(string username)
        {
            _logger.LogInformation("Requesting Profile from Identity Service");
            HttpResponseMessage Res = await _httpClient.GetAsync("manage/" + username);
             var json = Res.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("Received Identity Serivce Response");
            if (Res.IsSuccessStatusCode)
            {                
                return ResponseModel.SuccessResult(json);
            }
            return ResponseModel.FailedResult((int)Res.StatusCode, json);

        }

        /// <summary>
        /// Update the user profile from Identity Microservice
        /// </summary>
        /// <param name="model">Updated Profile</param>
        /// <returns>A <seealso cref="ResponseModel"/> with the json result from the Idenity service.
        /// <br></br>If the operation was successful, the <seealso cref="ResponseModel.ResultContent"/> contains the updated <seealso cref="ContactModel"/> for the user
        /// <br></br>If the operation was unsuccessful, the  <seealso cref="ResponseModel.ResultContent"/> contains the public errors from the Identity Service</returns>
        public async Task<ResponseModel> UpdateUserProfile(ContactModel model)
        {
            _logger.LogInformation("Creating Profile Update Request for Identity Service");
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
            _logger.LogInformation("Sending Update Request to Identity Service");
            var manage = "manage/" + model.Username;
            HttpResponseMessage Res = await _httpClient.PostAsync(manage, jsonContent);
             var json = Res.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("Received Identity Serivce Response");
            if (Res.IsSuccessStatusCode)
            {               
                return ResponseModel.SuccessResult(json);
            }
            return ResponseModel.FailedResult((int)Res.StatusCode, json);
        }

        /// <summary>
        /// Update the user profile from Identity Microservice
        /// </summary>
        /// <param name="model">Updated Profile</param>
        /// <returns>A <seealso cref="ResponseModel"/> with the json result from the Idenity service.
        /// <br></br>If the operation was unsuccessful, the  <seealso cref="ResponseModel.ResultContent"/> contains the public errors from the Identity Service</returns>
        public async Task<ResponseModel> ChangeUserPassword(ResetPasswordModel model)
        {
            _logger.LogInformation("Creating Password Update Request for Identity Service");
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json");
            _logger.LogInformation("Sending Request to Identity Service");
            var manage = model.Username + "/reset";
            HttpResponseMessage Res = await _httpClient.PostAsync(manage, jsonContent);
            var json = Res.Content.ReadAsStringAsync().Result;
            _logger.LogInformation("Received Identity Serivce Response");
            if (Res.IsSuccessStatusCode)
            {
                return ResponseModel.SuccessResult("");
            }
            return ResponseModel.FailedResult((int)Res.StatusCode, json);
        }


    }
}