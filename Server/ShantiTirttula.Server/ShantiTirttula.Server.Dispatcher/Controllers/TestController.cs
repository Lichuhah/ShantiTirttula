using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShantiTirttula.Server.Dispatcher.Models;
using System.Text;

namespace ShantiTirttula.Server.Dispatcher.Controllers
{
    public class TestController
    {
        public string ApiUrl;
        public TestController()
        {
            ApiUrl = Environment.GetEnvironmentVariable("API_URL");
        }

        [HttpPost("post")]
        public string post(TestEntity ent)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiUrl+"/post");
            request.Content = new StringContent(JsonConvert.SerializeObject(ent), Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = client.Send(request);
                string answer = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(answer);
                return answer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
