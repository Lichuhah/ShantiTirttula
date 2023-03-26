using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
namespace ShantiTirttula.Server.Dispatcher.Models.ApiModels
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }

        public ApiResponse<T> SetData(T data)
        {
            Success = true;
            Data = data;
            return this;
        }

        public ApiResponse<T> Error(string errorMessage)
        {
            Success = false;
            ErrorMessages = new List<string> { errorMessage };
            return this;
        }

        public ActionResult Result()
        {
            return new ContentResult
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(this,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                StatusCode = Success ? (int?)HttpStatusCode.OK : (int?)HttpStatusCode.OK
            };
        }
    }
}